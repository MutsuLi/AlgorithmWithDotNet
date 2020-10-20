#include <stdio.h>
#include <windows.h>
#include <iostream>

using namespace std;
int main()
{
    unsigned u1 = {10};
    unsigned u2 = {42};
    int i1 = 10;
    int i2 = 42;
    int &alias = i1;
    cout << i1 - i2 << "\n"
         << endl;
    cout << i2 - i1 << "\n"
         << endl;
    cout << i1 - u1 << "\n"
         << endl;
    cout << u1 - u2 << "\n"
         << endl;
    cout << "abcd"
            "\n"
            "efgh"
         << endl;
    alias = i2;
    alias = 100;
    cout << alias
         << endl;
    cout << i2
         << endl;
    cout << i1
         << endl;

    //pointer
    int *ptr = nullptr;
    if (ptr == nullptr)
    {
    }
    system("pause");
    return 0;
}