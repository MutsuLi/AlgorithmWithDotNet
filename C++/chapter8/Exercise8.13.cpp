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
bool valid(const string &str)
{
    return isdigit(str[0]);
}

string format(const string &str)
{
    return str.substr(0, 3) + "-" + str.substr(3, 3) + "-" + str.substr(6);
}

void ReadFiletoVector(const string &fileName, vector<PersonInfo> &vec)
{
    ifstream ifs(fileName);
    if (!ifs)
    {
        cerr << "no phone numbers?" << endl;
    }
    string buffer;
    istringstream record;
    while (getline(ifs, buffer))
    {
        PersonInfo info; // create an object to hold this record's data
        record.clear();
        record.str(buffer);
        record >> info.name;               // read the name
        while (record >> buffer)           // read the phone numbers
            info.phones.push_back(buffer); // and store them
        vec.push_back(info);               // append this record to people
    }
    for (const auto &entry : vec)
    {
        ostringstream formatted, badNums;
        for (const auto &nums : entry.phones)
            if (!valid(nums))
                badNums << " " << nums;
            else
                formatted << " " << format(nums);
        if (badNums.str().empty())
            cout << entry.name << " " << formatted.str() << endl;
        else
            cerr << "input error: " << entry.name << " invalid number(s) "
                 << badNums.str() << endl;
    }
}
int main()
{
    string fileName("./C++/chapterVIII/data/phonebook.txt");
    vector<PersonInfo> people; // will hold all the records from the input
    ReadFiletoVector(fileName, people);
    system("pause");
    return 0;
}