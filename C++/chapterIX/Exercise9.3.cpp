#include <iostream>
#include <vector>
#include <list>
#include <forward_list>

using namespace std;
int main()
{
    vector<string> svec; // empty vector
    try
    {
        //svec[0]; // run-time error: there are no elements in svec! //segment fault can't be caught.
        cout << svec.at(0); // throws an out_of_range exception
    }
    catch (std::out_of_range &exc)
    {
        std::cerr << exc.what() << std::endl;
    }
    catch (...)
    {
        std::cerr << "error" << '\n';
    }
    //9.5.3
    string::size_type pos = 0;
    string numbers("0123456789"), name("r2d2");
    // each iteration finds the next number in name
    while ((pos = name.find_first_of(numbers, pos)) != string::npos)
    {
        cout << "found number at index: " << pos
             << " element is " << name[pos] << endl;
        ++pos; // move to the next character
    }
    system("pause");
    return 0;
}