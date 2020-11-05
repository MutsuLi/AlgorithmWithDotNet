#include <iostream>
#include <vector>

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
