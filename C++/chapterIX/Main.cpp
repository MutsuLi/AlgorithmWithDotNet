#include <stdio.h>
#include <windows.h>
#include <iostream>
#include <deque>
#include <list>
#include <vector>
#include <forward_list>
#include <array>

using namespace std;
int main()
{
     list<string> a = {"Milton", "Shakespeare", "Austen"};
     auto it1 = a.begin();   // list<string>::iterator
     auto it2 = a.rbegin();  // list<string>::reverse_iterator
     auto it3 = a.cbegin();  // list<string>::const_iterator
     auto it4 = a.crbegin(); // list<string>::const_reverse_iterator
     // each container has three elements, initialized from the given initializers

     list<string> authors = {"Milton", "Shakespeare", "Austen"};
     vector<const char *> articles = {"a", "an", "the"};
     list<string> list2(authors); // ok: types match
     // deque<string> authList(authors); // error: container types don't match
     // vector<string> words(articles);  // error: element types must match
     // ok: converts const char* elements to string
     forward_list<string> words;
     words.assign(articles.begin(), articles.end());

     //array
     array<int, 10> ia1;                                  // ten default-initialized ints
     array<int, 10> ia2 = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}; // list initialization
     array<int, 10> ia3 = {42};                           // ia3[0] is 42, remaining elements are 0
     int digs[10] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
     //int cpy[10] = digs; // error: no copy or assignment for built-in arrays
     array<int, 10> digits = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
     array<int, 10> copy = digits; // ok: so long as array types match => deep clone?

     //compare
     vector<int> v1 = {1, 3, 5, 7, 9, 12};
     vector<int> v2 = {1, 3, 9};
     vector<int> v3 = {1, 3, 5, 7};
     vector<int> v4 = {1, 3, 5, 7, 9, 12};
     cout << (v1 < v2) << endl;  // true; v1 and v2 differ at element [2]: v1[2] is less than v2[2]
     cout << (v1 < v3) << endl;  // false; all elements are equal, but v3 has fewer of them;
     cout << (v1 == v4) << endl; // true; each element is equal and v1 and v4 have the same size()
     cout << (v1 == v2) << endl; // false; v2 has fewer elements than v1

     //9.3
     forward_list<int> flst = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
     auto prev = flst.before_begin(); // denotes element "off the start" of flst
     auto curr = flst.begin();        // denotes the first element in flst
     while (curr != flst.end())
     {
          // while there are still elements toprocess
          if (*curr % 2)                      // if the element is odd
               curr = flst.erase_after(prev); // erase it and move curr
          else
          {
               prev = curr; // move the iterators to denote the next
               ++curr;      // element and one before the next element
          }
     }
     //cout << (75) / (1.85 * 1.85) << endl;
     system("pause");
     return 0;
}