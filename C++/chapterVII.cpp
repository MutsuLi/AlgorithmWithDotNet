#include <iostream>
#include <vector>
#include <cstring>
#include <cstdlib>
using namespace std;

class Sales_data
{
public: // access specifier added
    Sales_data() = default;
    Sales_data(const std::string &s, unsigned n, double p) : bookNo(s), units_sold(n), revenue(p * n) {}
    Sales_data(const std::string &s) : bookNo(s) {}
    Sales_data(std::istream &);
    std::string isbn() const { return this->bookNo; }
    Sales_data &combine(const Sales_data &);
    Sales_data &Sales_data::combine(const Sales_data &rhs)
    {
        units_sold += rhs.units_sold; // add the members of rhs into
        revenue += rhs.revenue;       // the members of ''this'' object
        return *this;                 // return the object on which the function was called
    }

private: // access specifier added
    double avg_price() const
    {
        return units_sold ? revenue / units_sold : 0;
    }
    std::string bookNo;
    unsigned units_sold = 0;
    double revenue = 0.0;
};