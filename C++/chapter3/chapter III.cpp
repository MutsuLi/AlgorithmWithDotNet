#include <iostream>
#include <vector>
#include <cstring>

using namespace std;
/*
* Chapter 3. Strings, Vectors, and Arrays
*/
constexpr unsigned txt_size()
{
    return 10;
}
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
    cout << *Parray[0] << endl;
    int(&arrRef)[10] = arr; // arrRef refers to an array of ten ints

    constexpr unsigned number = 10;
    string test123[txt_size()];

    //3.5.3. Pointers and Arrays
    int ia[] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9}; // ia is an array of ten ints
    auto ia2 = ia;                             // ia2 is an int* that points to the first element in ia
    *ia2 = 42;                                 // error: ia2 is a pointer, and we can't assign an int to a pointer

    int arrs[] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9};
    for (int *b = begin(arrs); b != end(arrs); ++b)
        cout << *b << endl; // print the elements in arr

    const char ca[] = {'h', 'e', 'l', 'l', 'o'};
    const char *cp = ca;
    while (*cp)
    {
        cout << *cp << endl;
        ++cp;
    }
    //3.5.5. Interfacing to Older Code
    string s2("Hello World");
    //char *str = s;               // error: can't initialize a char* from a string
    const char *str = s2.c_str(); // ok
    int int_arr[] = {0, 1, 2, 3, 4, 5};
    // ivec has six elements; each is a copy of the corresponding element in int_arr
    vector<int> ivec22(begin(int_arr), end(int_arr));
    //3.6. Multidimensional Arrays
    int arr2[10][20][30] = {0};
    int ia3[3][4] = {
        {0, 1, 2, 3},
        {4, 5, 6, 7},
        {8, 9, 10, 11}};
    //int ia[3][4] = {0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11};
    //int ia[3][4] = {{ 0 }, { 4 }, { 8 }};
    //int ix[3][4] = {0, 3, 6, 9}; //initializes the elements of the first row.
    // assigns the first element of arr to the last element in the last row of ia
    ia3[2][3] = arr2[0][0][0];
    int(&row)[4] = ia3[1]; // binds row to the second four-element array in ia
    cout << row[3] << endl;
    system("pause");
    return 0;
}