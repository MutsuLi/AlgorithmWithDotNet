#include <iostream>
#include <vector>
#include <list>
#include <forward_list>
#include <deque>
#include <stack>

using namespace std;
int e918()
{
    deque<string> input;
    for (string str; cin >> str; input.emplace_back(str))
        ;
    for (auto &each : input)
    {
        cout << each << endl;
    }
    return 0;
}
int e920()
{
    list<int> list{1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    deque<int> odd;
    deque<int> even;
    for (auto i : list)
        (i & 0x1 ? odd : even).push_back(i);
    cout << "odd:" << endl;
    for (auto i : odd)
        cout << i << " " << endl;
    cout << "even:" << endl;
    for (auto i : even)
        cout << i << " " << endl;
    return 0;
}
int e926()
{
    int ia[] = {0, 1, 1, 2, 3, 5, 8, 13, 21, 55, 89};
    vector<int> even(ia, end(ia));
    list<int> odd(ia, end(ia));
    for (auto it = even.begin(); it != even.end();)
    {
        if (!(*it & 0x1))
        {
            it = even.erase(it);
        }
        else
        {
            it++;
        }
    }
    for (auto it = odd.begin(); it != odd.end();)
    {
        if (*it & 0x1)
        {
            it = odd.erase(it);
        }
        else
        {
            it++;
        }
    }
    //! print
    cout << "odd : ";
    for (auto i : odd)
        cout << i << " " << endl;
    cout << "even : ";
    for (auto i : even)
        cout << i << " " << endl;
    return 0;
}
int e927()
{
    forward_list<int> fl{1, 2, 3, 4, 5, 6, 7, 8, 9, 10};
    auto prev = fl.before_begin();
    auto curr = fl.begin();
    while (curr != fl.end())
    {
        if (*curr & 0x1)
        {
            curr = fl.erase_after(prev);
        }
        else
        {
            prev = curr;
            ++curr;
        }
    }
    for (auto i : fl)
        cout << i << " " << endl;
    return 0;
}
int e928(forward_list<string> &list, const string &to_find, const string &to_add)
{
    auto prev = list.before_begin();
    auto size = std::distance(list.begin(), list.end());
    for (auto curr = list.begin(); curr != list.end(); curr++)
    {
        if (*curr == to_find)
            list.insert_after(curr, to_add);
        if (size == std::distance(list.begin(), list.end()))
            list.insert_after(prev, to_add);
        prev = curr;
    }
    for (auto i : list)
        cout << i << " " << endl;
    return 0;
}
int e931()
{
    cout << "list:" << endl;
    list<int> vi = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    auto iter = vi.begin();
    while (iter != vi.end())
    {
        if (*iter % 2)
        {
            iter = vi.insert(iter, *iter);
            advance(iter, 2);
        }
        else
            iter = vi.erase(iter);
    }
    for (auto i : vi)
        cout << i << endl;

    cout << "foward_list:" << endl;
    forward_list<int> fl = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    auto prev = fl.before_begin();

    for (auto curr = fl.begin(); curr != fl.end();)
    {
        if (*curr % 2)
        {
            curr = fl.insert_after(prev, *curr);
            advance(curr, 2);
            advance(prev, 2);
        }
        else
            curr = fl.erase_after(prev);
    }
    for (auto j : fl)
        cout << j << endl;
    return 0;
}
int e932()
{
    vector<int> vi = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    auto iter = vi.begin();
    while (iter != vi.end())
    {
        if (*iter % 2)
        {
            iter = vi.insert(iter, *iter++);
            iter += 2;
        }
        else
            iter = vi.erase(iter);
    }

    for (auto i : vi)
        cout << i << " ";

    return 0;
}

void Replace(string &s, const string &oldVal, const string &newVal)
{
    for (auto beg = s.begin(); std::distance(beg, s.end()) >=
                               std::distance(oldVal.begin(), oldVal.end());)
    {
        if (string{beg, beg + oldVal.size()} == oldVal)
        {
            beg = s.erase(beg, beg + oldVal.size());
            beg = s.insert(beg, newVal.cbegin(), newVal.cend());
            std::advance(beg, newVal.size());
        }
        else
            ++beg;
    }
}
int e938()
{
    string str{"To drive straight thru is a foolish, tho courageous act."};
    Replace(str, "thru", "through");
    Replace(str, "tho", "though");
    std::cout << str << std::endl;
    return 0;
}
void ReplaceII(string &s, const string &oldVal, const string &newVal)
{
    for (string::size_type i = 0; i != s.size(); ++i)
        if (s.substr(i, oldVal.size()) == oldVal)
        {
            s.replace(i, oldVal.size(), newVal);
            i += newVal.size() - 1;
        }
}
int e944()
{
    string str{"To drive straight thru is a foolish, tho courageous act."};
    ReplaceII(str, "thru", "through");
    ReplaceII(str, "tho", "though");
    std::cout << str << std::endl;
    return 0;
}
int e945(string name, string preffix, string subffix)
{
    string ret(name);
    ret.insert(ret.begin(), preffix.begin(), preffix.end());
    ret.append(subffix);
    cout << ret << endl;
    return 0;
}
int e946(string name, string preffix, string subffix)
{
    string ret(name);
    ret.insert(0, preffix);
    ret.insert(ret.size(), subffix);
    cout << ret << endl;
    return 0;
}
int e947()
{
    string numbers{"0123456789"};
    string alphabet{"abcdefghijklmnopqrstuvwxyzABCDEFGHIJKLMNOPQRSTUVWXYZ"};
    string str{"ab2c3d7R4E6"};
    vector<char> numberResult;
    vector<char> alphaResult;
    cout << "numeric characters: ";
    for (string::size_type pos = 0; (pos = str.find_first_of(numbers, pos)) != string::npos; ++pos)
        cout << str[pos] << " ";
    cout << "alpha characters: ";
    for (string::size_type pos = 0; (pos = str.find_first_of(alphabet, pos)) != string::npos; ++pos)
        cout << str[pos] << " ";
    cout << endl;
    return 0;
}
int e950()
{
    vector<string> v = {"1", "2", "3", "4.5"};
    int sum1 = 0;
    for (auto &each : v)
    {
        sum1 += stoi(each);
    }
    float sum2 = 0;
    for (auto &each : v)
    {
        sum2 += stof(each);
    }
    cout << sum1 << endl;
    cout << sum2 << endl;
    return 0;
}
int e952()
{
    string expr = "This is (Mooophy(awesome)((((wooooooooo))))) and (ocxs) over";
    auto repl = '#';
    bool flag = false;
    stack<char> stk;
    for (auto &each : expr)
    {
        stk.push(each);
        if (each == '(')
            flag = true;
        if (flag && each == ')')
        {
            while (stk.top() != '(')
            {
                stk.pop();
            }
            stk.pop();
            stk.push(repl);
            flag = false;
        }
    }
    // Test
    string output;
    for (; !stk.empty(); stk.pop())
        output.insert(output.begin(), stk.top());
    cout << output << endl; // "This is # and # over"
    return 0;
}
int main()
{
    vector<string> svec; // empty vector
    try
    {
        //svec[0]; // run-time error: there are no elements in svec! //segment fault can't be caught.
        cout << svec.at(0); // throws an out_of_range exception
    }
    catch (std::out_of_range &exc)
    {
        std::cerr << exc.what() << std::endl;
    }
    catch (...)
    {
        std::cerr << "error" << '\n';
    }
    //9.5.3
    string::size_type pos = 0;
    string numbers("0123456789"), name("r2d2");
    // each iteration finds the next number in name
    while ((pos = name.find_first_of(numbers, pos)) != string::npos)
    {
        cout << "found number at index: " << pos
             << " element is " << name[pos] << endl;
        ++pos; // move to the next character
    }
    // cout << "9.18: " << endl;
    // e918();
    cout << "9.20: " << endl;
    e920();
    cout << "9.26: " << endl;
    e926();
    cout << "9.27: " << endl;
    e927();
    cout << "9.31: " << endl;
    e931();
    e938();
    //e932();
    e945(" Ricardo ", "Mr.", "Jr.");
    e946(" Ricardo ", "Mr.", "Jr.");
    e947();
    e950();
    e952();
    system("pause");
    return 0;
}