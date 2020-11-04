#include <fstream>
#include <iostream>
#include <vector>


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
    }
}
int main()
{
    vector<string> vec;
    ReadFiletoVector("./C++/chapterVIII/data/test.txt", vec);
    for (const auto &str : vec)
        cout << str << endl;
    system("pause");
    return 0;
}