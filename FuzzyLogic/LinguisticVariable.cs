using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace FuzzyLogic
{
    internal class LinguisticVariable
    {
        public string Name { get; set; }
        public FuzzyVariable Variable { get; set; }

        public LinguisticVariable(string name, FuzzyVariable variable)
        {
            this.Name = name;
            this.Variable = variable;
        }
    }
}