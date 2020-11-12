#include <iostream>
#include <fstream>
#include <sstream>
#include <vector>
#include <string>

using namespace std;

void ReadFiletoVector(const string &fileName, vector<string> &vec)
{
    ifstream ifs(fileName);
    if (ifs)
    {
        string buffer;
        while (getline(ifs, buffer))
        {
            vec.push_back(buffer);
        }
        for (auto &each : vec)
        {
            istringstream iss(each);
            string word;
            while (iss >> word)
                cout << word << endl;
        }
    }
}
int main()
{
    vector<string> vec;
    ReadFiletoVector("./C++/chapterVIII/data/test.txt", vec);
    system("pause");
    return 0;
}