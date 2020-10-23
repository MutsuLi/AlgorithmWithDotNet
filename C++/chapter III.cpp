#include <iostream>
#include <vector>

using namespace std;
/*
* Chapter 3. Strings, Vectors, and Arrays
*/
int main()
{
    //String 大同小异
    string test = string("test");
    test.append("a");
    for (auto each : test)
    {
        cout << each << endl;
    }
    cout << test.length() << endl;
    cout << test << endl;

    //Vectors
    vector<string> ivec = {"a", "b", "c"};
    vector<string> ivec2({"a", "b", "c"});
    system("pause");
    return 0;
}