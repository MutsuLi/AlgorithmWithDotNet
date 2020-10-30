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
     //int *ptr = nullptr;
     //const
     int dvl = 3;
     const int &ri = dvl;
     int &dvl2 = dvl;
     cout << ++dvl2
          << endl;
     cout << ri
          << endl;

     //1.pointer to const
     int errNumb = 0;
     const int *curErr = &errNumb;
     int errNumb2 = 1;
     errNumb = 10;
     //*curErr = errNumb2; forbidden
     curErr = &errNumb2;
     // *curErr = 2; fobidden
     cout << *curErr << endl;
     //2.const pointer
     int a1 = 10;
     int *const pp = &a1;
     *pp = 120;
     a1 = 100;
     cout << *curErr << endl;
     // const pointer to a const
     const int p1 = 1;
     const int *const pp = &p1;
     const int p2 = 1;
     //pp = &p2;
     //*pp = 2;
     constexpr int *q = nullptr;
     *q = 0;
     system("pause");
     return 0;
}