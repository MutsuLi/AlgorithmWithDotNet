# C#并发编程经典实例--读书笔记--集合
## 1. 不可变集合
### 简述
> 不可变集合是永远不会改变的集合。只读操作（如枚举）直接访问不可变集合实例。写入操作（如增加一个项目）会返回一个新的不可变集合实例，而不是修改原来的实例。乍一听上去，这种做法浪费存储空间，但不可变集合之间通常共享了大部分存储空间，因此其实浪费并不大。并且不可变集合有个优势，多个线程访问是安全的。
>>  以下是常用的不可变集合:
>> * ImmutableStack\<T>
>> * ImmutableQueue\<T>
>> * ImmutableList\<T>
>> * ImmutableHashSet\<T>
>> * ImmutableSortedSet\<T>
>> * ImmutableDictionary<TKey,TValue>
>> * ImmutableSortedDictionary<TKey,TValue>

### 1.2 不可变队列与栈(ImmutableStack && ImmutableQueue)
#### 简述
> 不可变集合的一个实例是永远不改变的。
> 因为不会改变，所以是绝对线程安全的。
> 对不可变集合使用修改方法时，返回修改后的集合。
不可变集合非常适用于共享状态，但不适合用来做交换数据的通道。特别是在线程间的通
信中不要使用不可变队列，可以改用生产者/ 消费者队列，以获得更好的效果。

> 如下所示,修改/新增值时,原始集合未发生改变
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

### 1.3 不可变列表(ImmutableList)
#### 简述
> 不可变列表的内部是用二叉树组织数据的。这么做是为了让不可变列表的实例之间共享的内
存最大化,但同时造成了性能上的降低.
> 不可变列表的性能差异

action | List<T> | ImmutableList<T>
-----|-------|---------
Add | O(1) | O(log N)
Insert | O(N) | O(log N)
RemoveAt | O(N) | O(log N)
Item[index] | O(1) | O(log N)

应该尽量使用foreach 而不是用for。对ImmutableList<T> 进行foreach 循环的耗
时是O(N)，而对同一个集合进行for 循环的耗时是O(N*logN)：
```
// 遍历ImmutableList<T> 的最好方法。
foreach (var item in list)
Trace.WriteLine(item);
// 这个方法运行正常，但速度会慢得多。
for (int i = 0; i != list.Count; ++i)
Trace.WriteLine(list[i]);
```

### 1.4 不可变Set(ImmutableHashSet && ImmutableSortedSet)
#### 简述
> 有两种不可变Set 集合类型：ImmutableHashSet<T> 只是一个不含重复元素的集合，
ImmutableSortedSet<T> 是一个已排序的不含重复元素的集合。
> 不可变Set的性能差异

action | ImmutableHashSet<T> | ImmutableSortedSet<T>
-----|-------|---------
Add | O(log N) | O(log N)
RemoveAt | O(log N) | O(log N)
Item[index] | / | O(log N)

同理,由于Item[Index] 性能较差,使用ImmutableSortedSet<T> 时，应该尽量用foreach 而不是用for。

应该尽量使用foreach 而不是用for。对ImmutableList<T> 进行foreach 循环的耗
时是O(N)，而对同一个集合进行for 循环的耗时是O(N*logN)：
#### 总结
>不可变Set 集合是非常实用的数据结构，但是填充较大不可变Set 集合的速度会很慢。大
多数不可变集合有特殊的构建方法，可以先快速地以可变方式构建，然后转换成不可变集
合

### 1.5 不可变字典(ImmutableDictionary && ImmutableSortedDictionary)
#### 简述
> 适用场景: 不经常修改且可被多个线程安全访问的键/ 值集合。

> 不可变字典的性能差异:

action | ImmutableHashSet<T> | ImmutableSortedSet<T>
-----|-------|---------
Add | O(log N) | O(log N)
SetItem  | O(log N) | O(log N)
Remove | O(log N) | O(log N)
Item[key] | O(log N) | O(log N)

> 未排序字典和已排序字典在性能上差别不大,未排序字典的速度稍微快一点。但未排序字典可以使用任何键类型，而已排序字典要求键的类型必须是完全可比较的。因此推荐适用使用未排序字典.

#### 总结
> 字典是处理应用状态时很普遍又实用的工具。它能用在任何类型的键/ 值或询。跟其他不可变集合一样，不可变字典有一个在元素较多时进行快速构建的机制。例如，想要在启动时装载初始参考数据，就可以使用这种构建机制构造出初始的不可变字典。相反，如果参考数据是在程序运行时逐步构建的，那可以使用常规的Add方法。



## 2 线程安全集合
### 描述
> 线程安全集合是可同时被多个线程修改的可变集合。线程安全集合混合使用了细粒度锁定和无锁技术，以确保线程被阻塞的时间最短（通常情况下是根本不阻塞）。对很多线程安全集合进行枚举操作时，内部创建了该集合的一个快照（snapshot），并对这个快照进行枚举操作。线程安全集合的主要优点是多个线程可以安全地对其进行访问，而代码只会被阻塞很短的时间，或根本不阻塞。

>>  以下是常用的线程安全集合:
>> * ConcurrentDictionary<TKey, TValue>
>> * BlockingCollection<T>
>> * ConcurrentStack<T>
>> * ConcurrentQueue<T> 
>> * ConcurrentBag<T>

### 2.1 线程安全字典
#### 简述
> 适用场景: 需要有一个键/值集合，多个线程同时读写时仍能保持同步。
> ConcurrentDictionary<TKey, TValue>是线程安全的，混合使用了细粒度锁定和无锁技术，以确保绝大多数情况下能进行快速访问.
#### 总结
>ConcurrentDictrionary<TKey,TValue>并不适合于所有场合。如果多个线程读写一个共享集合，使用ConcurrentDictrionary<TKey,TValue> 是最合适的。如果不会频繁修改（很少修改），那更适合使用ImmutableDictionary<TKey, TValue>.
>ConcurrentDictrionary<TKey,TValue> 最适合用在需要共享数据的场合，即多个线程共享同一个集合。如果一些线程只添加元素，另一些线程只移除元素，那最好使用生产者/ 消费者集合。

### 2.2 阻塞队列
#### 简述
> 适用场景: 适用于独立的线程（如线程池线程）作为生产者或消费者.如果要以异步方式访问管道,例如UI线程作为消费者，用阻塞队列就不大合适了。
> BlockingCollection<T> 默认是阻塞队列，具有“先进先出”的特征,但它也可以作为任何类型的生产者/ 消费者集合。
> 可以在创建BlockingCollection<T> 实例时指明规则，可选择后进先出（栈）或无序（包），如下例所示：
```
BlockingCollection<int> _blockingStack = new BlockingCollection<int>(
new ConcurrentStack<int>());
BlockingCollection<int> _blockingBag = new BlockingCollection<int>(
new ConcurrentBag<int>());
```
> 由于要被多个线程共用，通常把它定义成私有和只读.
```
private readonly BlockingCollection<int> _blockingQueue =
new BlockingCollection<int>();
```
> 生产者线程通过调用Add 方法来添加项目，所有项目都已经添加完毕后调用CommpleteAdding方法,然后该集合会通知消费者线程.
> 消费者线程通过调用GetConsumingEnumerable或take消费一个项目,前者用一个循环使用所有的项目,后者每次只会消费一个项目.
> 除非能保证消费者的速度总是比生产者快，使用这种管道时，都要考虑一旦生产者比消费者快，会发生什么情况。如果生产者的速度比消费者快，就需要对队列进行限流。
```
下面的例子把集合的项目数量限制为1 个：
BlockingCollection<int> _blockingQueue = new BlockingCollection<int>(boundedCapacity: 1);
```
#### 总结
> ConcurrentDictrionary<TKey,TValue>并不适合于所有场合。如果多个线程读写一个共享集合，使用ConcurrentDictrionary<TKey,TValue> 是最合适的。如果不会频繁修改（很少修改），那更适合使用ImmutableDictionary<TKey, TValue>.
> ConcurrentDictrionary<TKey,TValue> 最适合用在需要共享数据的场合，即多个线程共享同一个集合。如果一些线程只添加元素，另一些线程只移除元素，那最好使用生产者/ 消费者集合。


