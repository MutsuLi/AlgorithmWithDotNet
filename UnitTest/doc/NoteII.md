# 读书笔记--C#并发编程经典实例--同步

## 1. 同步

### 简述

> 同步的类型主要有两种：通信和数据保护。当一段代码把某些情况（例如收到新消息）通知给另一段代码时，就得用到通信。在后面的有关案例中会详细讲述通信。本章的概述部分主要讨论数据保护。
> 同步的条件: 
>> (1) 多段代码正在并发运行。
>> (2) 这几段代码在访问（读或写）同一个数据。
>> (3) 至少有一段代码在修改（写）数据。

## 2. 阻塞锁(同步)

### 使用场景

> 多个线程需要安全地读写共享数据。

### 解决方案

>> 决解方案这种情况最好的办法是使用lock语句。
>> 一个线程进入锁后，在锁被释放之前其他线程是无法进入的：

``` 
class MyClass
{
    // 这个锁会保护_value。        
    private readonly object _mutex = new object();
    private int _value;
    public void Increment()
    {
        lock (_mutex)
        { _value = _value + 1; }
    }
}
```

>> . NET框架中还有很多其他类型的锁，如Monitor、SpinLock、ReaderWriterLockSlim.
>> 对大多数程序来说，这些类型的锁基本上用不到。尤其是程序员会习惯性地使用ReaderWriterLockSlim，即使没必要用那么复杂的技术。
>> 基本的lock语句就可以很好地处理99%的情况了.

### 使用限制

> 1. 关于锁的使用，有四条重要的规则:
>> 要尽量限制锁的作用范围。应该把lock语句使用的对象设为私有成员，并且永远不要暴露给非本类的方法。每个类型通常最多只有一个锁。如果一个类型有多个锁，可考虑通过重构把它分拆成多个独立的类型。可以锁定任何引用类型，但是我建议为lock语句定义一个专用的成员，就像最后的例子那样。尤其是千万不要用lock(this)，也不要锁定Type或string类型的实例。因为这些对象是可以被其他代码访问的，这样锁定会产生死锁.
>> 要在文档中描述锁定的内容。这种做法在最初编写代码时很容易被忽略，但是在代码变得复杂后就会变得很重要。
>> 在锁定时执行的代码要尽可能得少。要特别小心阻塞调用。在锁定时不要做任何阻塞操作。
>> 在锁定时绝不要调用随意的代码。随意的代码包括引发事件、调用虚拟方法、调用委托。如果一定要运行随意的代码，就在释放锁之后运行。
> 2. lock语句是用来保护共享数据的，而不是在线程间发送信号.
> 3. lock语句与await并不兼容.

### 使用场景

``` 
var stack = ImmutableStack<int>.Empty;
stack = stack.Push(13);
var biggerStack = stack.Push(7);
// 先显示“7”，接着显示“13”。
foreach (var item in biggerStack)
Trace.WriteLine(item);
// 只显示“13”。
foreach (var item in stack)
Trace.WriteLine(item);
```

## 2.1. 异步锁

### 使用场景

> 多个代码块需要安全地读写共享数据，并且这些代码块可能使用await语句。

### 解决方案

>> . NET 4.5对框架中的SemaphoreSlim类进行了升级以兼容async。可以这样使用：

``` 
class MyClass
{         // 这个锁保护_value。        
     private readonly SemaphoreSlim _mutex = new SemaphoreSlim(1);
     private int _value;
     public async Task DelayAndIncrementAsync()
     {
        await _mutex.WaitAsync();
        try
        {
            var oldValue = _value; await Task.Delay(TimeSpan.FromSeconds(oldValue)); _value = oldValue + 1;
        }
        finally 
        {
             _mutex.Release(); 
        }
     }
 }
```

>> 一个线程进入锁后，在锁被释放之前其他线程是无法进入的：

## 3. 阻塞信号

### 使用场景

> 需要从一个线程发送信号给另一个线程。

### 解决方案

> 最常见和通用的跨线程信号是ManualResetEventSlim。一个人工重置的事件处于这两种状态其中之一：标记的（signaled）或未标记的（unsignaled）。每个线程都可以把事件设置为signaled状态，也可以把它重置为unsignaled状态。线程也可等待事件变为signaled状态。
> 下面的两个方法被两个独立的线程调用，一个线程等待另一个线程的信号：

``` 
class MyClass
{
    private readonly ManualResetEventSlim _initialized = new ManualResetEventSlim();
    private int _value;
    public int WaitForInitialization()
     {
          _initialized.Wait(); 
          return _value;
    }
    public void InitializeFromAnotherThread()
    {
        value = 13; 
        _initialized.Set();
    }
}
```

### 小结

> ManualResetEventSlim是功能强大、通用的线程间信号，但必须合理地使用。如果这个信号其实是一个线程间发送小块数据的消息，那可考虑使用生产者/消费者队列。
> 另一方面，如果信号只是用来协调对共享数据的访问，那可改用锁。

## 3.1 异步信号

### 使用场景

> 需要在代码的各个部分间发送通知，并且要求接收方必须进行异步等待。

### 解决方案

> 如果该通知只需要发送一次，那可用TaskCompletionSource<T>异步发送。发送代码调用TrySetResult，接收代码等待它的Task属性：

``` 
class MyClass
{
    private readonly TaskCompletionSource<object> _initialized = new TaskCompletionSource<object>();
    private int _value1; private int _value2;
    public async Task<int> WaitForInitializationAsync() 
    {
      await _initialized.Task; return _value1 + _value2;
    }
    public void Initialize()
    {
         _value1 = 13;
         _value2 = 17;
         _initialized.TrySetResult(null);
    }
}
```

### 小结

> 信号是一种通用的通知机制。但如果这个“信号”是一个用来在代码段之间发送数据的消息，那就考虑使用生产者/消费者队列。
> 同样，不要让通用的信号只是用来协调对共享数据的访问。那种情况下，可使用锁。

> 在所有情况下都可以用TaskCompletionSource\<T>来异步地等待：本例中，通知来自于另一部分代码。如果只需要发送一次信号，这种方法很适合。但是如果要打开和关闭信号，这种方法就不大合适了

## 4. 限流

### 使用场景

> 有一段高度并发的代码，由于它的并发程度实在太高了，需要有方法对并发性进行限流。代码并发程度太高，是指程序中的一部分无法跟上另一部分的速度，导致数据项累积并消耗内存。这种情况下对部分代码进行限流，可以避免占用太多内存。

### 解决方案

> 根据代码的并发类型，解决方法各有不同。这些解决方案都是把并发性限制在某个范围之内。响应式扩展有更多功能强大的方法可以选择，例如滑动时间窗口。
> 并行代码自带的对并发性限流的方法:

``` 
// 使用Parallel类    
void ParallelRotateMatrices(IEnumerable<Matrix> matrices, float degrees)
{
    var options = new ParallelOptions { MaxDegreeOfParallelism = 10 };
    Parallel.ForEach(matrices, options, matrix => matrix.Rotate(degrees));
}
```

> 并发性异步代码可以用SemaphoreSlim来限流:

``` 
async Task<string[]> DownloadUrlsAsync(IEnumerable<string> urls)
{
    var httpClient = new HttpClient();
    var semaphore = new SemaphoreSlim(10);
    var tasks = urls.Select(async url =>{
        await semaphore.WaitAsync();
        try
        {
            return await httpClient.GetStringAsync(url);
        }
        finally 
        {
            semaphore.Release(); 
        }
    }).ToArray();
    return await Task.WhenAll(tasks);
}
```

### 小结

> 如果发现程序使用的资源（例如CPU或网络连接）太多，说明可能需要使用限流了。需要牢记一点，最终用户的电脑性能可能不如开发者的电脑，因此限流得稍微严格一点，比限流不充分要好
