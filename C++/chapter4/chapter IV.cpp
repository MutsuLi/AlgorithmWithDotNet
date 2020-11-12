#include <iostream>
#include <vector>
#include <cstring>

using namespace std;
/*
* Chapter 4. Expressions
*/
int main()
{
    string s1 = "a string", *p = &s1;
    auto n = s1.size(); // run the size member of the string s1
    n = (*p).size();    // run size on the object to which p points
    n = p->size();      // equivalent to (*p).size()
    unsigned num = 2;
    num <<= 2;
    cout << num << endl;
    num = num + ~num;
    cout << num << endl;
    // 4.11.3. Explicit Conversions
    // static_cast, dynamic_cast, const_cast, and reinterpret_cast.
    const char *cp;
    // error: static_cast can't cast away const
    //char *q = static_cast<char *>(cp);
    static_cast<string>(cp); // ok: converts string literal to string
    const_cast<char *>(cp);  // error: const_cast only changes constness

    int *ip;
    char *pc = reinterpret_cast<char *>(ip);
    //
    int *ip;
    char *pc = reinterpret_cast<char *>(ip);
    string str(pc);
    system("pause");
    return 0;
}