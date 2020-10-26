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

    //Defining and Initializing vectors
    vector<string> ivec = {"a", "b", "c"};
    vector<string> ivec2({"a", "b", "c"});
    vector<int> instanse3(5, 1);
    vector<int> instanse4{10};
    //3.4 Iterators
    string s = "some string";
    if (s.begin() != s.end()) // make sure s is not empty
    {
        auto it = s.begin(); // it denotes the first character in s
        ++it;
        --it;
        it++;
        *it = toupper(*it); // make that character uppercase
    }
    cout << s << endl;
    // process characters in s until we run out of characters or we hit a whitespace
    for (auto it = s.begin(); it != s.end() && !isspace(*it); ++it)
        *it = toupper(*it); // capitalize the current character
    cout << s << endl;

    vector<int> v;
    const vector<int> cv;
    // auto it1 = v.begin();  // it1 has type vector<int>::iterator
    // auto it2 = cv.begin(); // it2 has type vector<int>::const_iterator
    // auto it3 = v.cbegin(); // it3 has type vector<int>::const_iterator

    //the -> operator
    vector<string> text = {"a", "b", "c", "1"};
    for (auto it = text.cbegin(); it != text.cend() && !it->empty(); ++it)
        cout << *it << endl;

    //3.5. Arrays
    const unsigned sz = 3;
    int ia1[sz] = {0, 1, 2};      // array of three ints with values 0, 1, 2
    int a2[] = {0, 1, 2};         // an array of dimension 3
    int arr[10] = {0, 1, 2};      // equivalent to a3[] = {0, 1, 2, 0, 0}
    string a4[3] = {"hi", "bye"}; // same as a4[] = {"hi", "bye", ""}
    int *ptrs[10];                // ptrs is an array of ten pointers to int
    int(*Parray)[10] = &arr;      // Parray points to an array of ten ints
    int(&arrRef)[10] = arr;       // arrRef refers to an array of ten ints
    system("pause");
    return 0;
}