using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;

namespace UnitTest
{
    public class Problems<T>
    {
        public int id;
        public string name;
        public List<T> ParamsList;
        public Problems(int id, string name, List<T> ParamsList)
        {
            this.id = id;
            this.name = name;
            this.ParamsList = ParamsList;
        }
        public static void prepareParams()
        {
            
        }
    }

}