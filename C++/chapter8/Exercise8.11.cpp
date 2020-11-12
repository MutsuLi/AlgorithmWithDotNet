#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>
#include <string>

using namespace std;

struct PersonInfo
{
    string name;
    vector<string> phones;
};
int main()
{
    string line, word;
    vector<PersonInfo> people; // will hold all the records from the input
    istringstream record;
    // read the input a line at a time until cin hits end-of-file (or another error)
    while (getline(cin, line))
    {
        PersonInfo info; // create an object to hold this record's data
        record.clear();
        record.str(line);
        record >> info.name;             // read the name
        while (record >> word)           // read the phone numbers
            info.phones.push_back(word); // and store them
        people.push_back(info);          // append this record to people
    }
    for (auto &p : people)
    {
        std::cout << p.name << " ";
        for (auto &s : p.phones)
            std::cout << s << " ";
        std::cout << std::endl;
    }
    system("pause");
    return 0;
}