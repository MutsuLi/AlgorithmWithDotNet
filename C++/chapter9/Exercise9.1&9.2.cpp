#include <iostream>
#include <vector>
#include <list>
#include <forward_list>

using namespace std;
//exercise 9.1

bool find(vector<int>::iterator beg, vector<int>::iterator end, int value)
{
    for (auto iter = beg; iter != end; ++iter)
        if (*iter == value)
            return true;
    return false;
}

vector<int>::iterator findII(vector<int>::iterator beg, vector<int>::iterator end, int value)
{
    for (auto iter = beg; iter != end; ++iter)
        if (*iter == value)
            return iter;
    return end;
}
void compareListandVector(vector<int> v1, list<int> l1)
{
    cout << boolalpha << (vector<int>(l1.begin(), l1.end()) == v1) << endl;
}
int main()
{
    // list<int> lst1;
    // list<int>::iterator iter1 = lst1.begin(), iter2 = lst1.end();
    // while (iter1 < iter2)
    //9.12
    //Exercise 9.12 Explain the differences between the constructor that takes a container to copy and the constructor that takes two iterators.

    // The constructor that takes another container as an
    // argument(excepting array) assumes the container type and element type of both containers are identical.It will also copy all the elements of the received container into the new one :
    list<int> numbers = {1, 2, 3, 4, 5};
    list<int> numbers2(numbers); // ok, numbers2 has the same elements as numbers
    // vector<int> numbers3(numbers);  // error: no matching function for call...
    // list<double> numbers4(numbers); // error: no matching function for call...
    //The constructor that takes two iterators as arguments does not require the container types to be identical.Moreover, the element types in the new and original containers can differ as long as it is possible to convert the elements we’re copying to the element type of the container we are initializing.It will also copy only the object delimited by the received iterators.list<int> numbers = {1, 2, 3, 4, 5};
    list<int> numbers3(numbers.begin(), numbers.end());           // ok, numbers2 has the same elements as numbers
    vector<int> numbers4(numbers.begin(), --numbers.end());       // ok, numbers3 is {1, 2, 3, 4}
    list<double> numbers5(++numbers.begin(), --numbers.end());    // ok, numbers4 is {2, 3, 4}
    forward_list<float> numbers6(numbers.begin(), numbers.end()); // ok, number5 is {1, 2, 3, 4, 5}

    //9.14
    std::list<const char *> l{"Mooophy", "pezy", "Queeuqueg"};
    std::vector<std::string> v;
    v.assign(l.cbegin(), l.cend());

    for (const auto &ch : v)
        std::cout << ch << std::endl;

    //9.16
    vector<int> v1 = {1, 2, 3, 4, 5};
    list<int> l1 = {1, 2, 3, 4, 5};
    compareListandVector(v1, l1);
    system("pause");
    return 0;
}
