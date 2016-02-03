using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConnectTable.Model
{
    public class RowFilterTable
    {
        public string fieldName { get; set; }
        public string textValue { get; set; }
        public string Operator {get; set;}
    }
}
