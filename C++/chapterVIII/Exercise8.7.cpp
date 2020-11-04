#include <fstream>
#include <iostream>
#include "../chapterVII/ex7_26_sales_data.h"
using namespace std;

void ReadAndSave(const string &fileName, const string &OutFile)
{
    ifstream input(fileName); // use "./C++/chapterVIII/data/book.txt"
    ofstream output(OutFile);
    Sales_data total;
    if (read(input, total))
    {
        Sales_data trans;
        while (read(input, trans))
        {
            if (total.isbn() == trans.isbn())
                total.combine(trans);
            else
            {
                print(output, total) << std::endl;
                total = trans;
            }
        }
        print(output, total) << std::endl;
    }
    else
    {
        std::cerr << "No data?!" << std::endl;
    }
}
int main()
{
    ReadAndSave("./C++/chapterVIII/data/book.txt", "./C++/chapterVIII/data/out.txt");
    system("pause");
    return 0;
}
