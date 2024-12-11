using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDay1.eg.Attributes
{
    public class RemarkAttribute : Attribute
    {
        private string Remark;
        public RemarkAttribute(string remark)
        {
            Remark = remark;
        }
        public string GetDescption()
        {
            return Remark;
        }
    }
}
