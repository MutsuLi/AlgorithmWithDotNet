#include <iostream>
#include <vector>
#include <cstring>
#include <cstdlib>
using namespace std;

class Sales_data
{
    // friend declarations for nonmember Sales_data operations added
    friend Sales_data add(const Sales_data &, const Sales_data &);
    friend std::istream &read(std::istream &, Sales_data &);
    friend std::ostream &print(std::ostream &, const Sales_data &);

public: // access specifier added
    Sales_data() = default;
    Sales_data(const std::string &s, unsigned n, double p) : bookNo(s), units_sold(n), revenue(p * n) {}
    Sales_data(const std::string &s) : bookNo(s) {}
    Sales_data(std::istream &);
    std::string isbn() const { return this->bookNo; }
    Sales_data &combine(const Sales_data &);
    Sales_data &Sales_data::combine(const Sales_data &rhs) //c
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

class ConstRef
{
public:
    ConstRef(int ii);

private:
    int i;
    const int ci;
    int &ri;
};
// error: ci and ri must be initialized
ConstRef::ConstRef(int ii) : i(ii), ci(ii), ri(ii)
{ // assignments:
}
struct X
{
    int rem, base;
    X(int i, int j) : base(i), rem(base % j) {}
};