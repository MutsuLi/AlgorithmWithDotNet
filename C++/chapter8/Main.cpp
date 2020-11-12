#include <stdio.h>
#include <windows.h>
#include <iostream>

using namespace std;
int main()
{
     cin.tie(&cout); // illustration only: the library ties cin and cout for us
     std::string buf;
     while (cin >> buf)
          std::cout << buf << std::endl;
     // old_tie points to the stream (if any) currently tied to cin
     ostream *old_tie = cin.tie(nullptr); // cin is no longer tied
     // ties cin and cerr; not a good idea because cin should be tied to cout
     cin.tie(&cerr);   // reading cin flushes cerr, not cout
     cin.tie(old_tie); // reestablish normal tie between cin and cout
     system("pause");
     return 0;
}