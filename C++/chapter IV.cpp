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
    system("pause");
    return 0;
}