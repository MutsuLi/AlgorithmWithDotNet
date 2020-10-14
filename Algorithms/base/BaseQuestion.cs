using System;
using System.Collections.Generic;

namespace Algorithms
{
    public class BaseQuestion
    {
        protected int id;
        protected string name;
        protected string answer;
        public string showResult()
        {
            return $"{this.id}.{this.name}: {this.answer}";
        }
    }
}