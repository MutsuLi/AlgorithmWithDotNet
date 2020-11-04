#include <fstream>
#include <iostream>
#include "../chapterVII/ex7_26_sales_data.h"
using namespace std;

void Read(const string &fileName)
{
    std::ifstream input(fileName); // use "./C++/chapterVIII/data/book.txt"

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
                print(std::cout, total) << std::endl;
                total = trans;
            }
        }
        print(std::cout, total) << std::endl;
    }
    else
    {
        std::cerr << "No data?!" << std::endl;
    }
}
int main()
{
    Read("./C++/chapterVIII/data/book.txt");
    system("pause");
    return 0;
}
/*
 *! Output:
 *! 0-201-78345-X 5 110
 *! 0-201-78346-X 9 839.2
 */