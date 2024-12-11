using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDay1.eg.Attributes
{
    public class ValidLongAttribute : AbstractValidAttribute
    {
        private int min = 0;
        private int max = 0;
        public ValidLongAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
        public override bool Valide(object value)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                int length = value.ToString().Length;
                if (length > min && length < max)
                {
                    return true;
                }
            }
            return false;
        }
    }
}
