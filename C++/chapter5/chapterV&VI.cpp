#include <iostream>
#include <vector>
#include <cstring>
#include <cstdlib>

using namespace std;
/*
* Chapter 5. Statements && Chapter 6. Functions
*/
// returns the index of the first occurrence of c in s
// the reference parameter occurs counts how often c occurs
string::size_type find_char(const string &s, char c, string::size_type &occurs)
{
    auto ret = s.size(); // position of the first occurrence, if any
    occurs = 0;          // set the occurrence count parameter
    for (decltype(ret) i = 0; i != s.size(); ++i)
    {
        if (s[i] == c)
        {
            if (ret == s.size())
                ret = i; // remember the first occurrence of c
            ++occurs;    // increment the occurrence count
        }
    }
    return ret; // count is returned implicitly in occurs
}

void error_msg(initializer_list<string> il)
{
    for (auto beg = il.begin(); beg != il.end(); ++beg)
        cout << *beg << " ";
    cout << endl;
}
bool lengthCompare(const string &, const string &);
int main()
{
    //Chapter 5
    try
    {
        for (int i = 0; i < 100; i++)
        {
            if (i == 99)
            {
                throw runtime_error("Data must refer to same ISBN");
            }
        }
    }
    catch (const std::exception &e)
    {
        cerr << e.what() << '\n';
    }
    //Chapter 6
    string::size_type ctr = 0;
    cout << find_char("Hello World!", 'o', ctr) << endl;
    error_msg({"functionX", "okay"});
    // Func and Func2 have function type
    typedef bool Func(const string &, const string &);
    typedef decltype(lengthCompare) Func2; // equivalent type
    // FuncP and FuncP2 have pointer to function type
    typedef bool (*FuncP)(const string &, const string &);
    typedef decltype(lengthCompare) *FuncP2; // equivalent type
    // equivalent declarations of useBigger using type aliases
    void useBigger(const string &, const string &, Func);
    // the compiler will automatically convert the function type represented by Func to a pointer.
    void useBigger(const string &, const string &, FuncP2);

    system("pause");
    return 0;
}
