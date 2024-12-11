using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDay1.eg.Attributes
{
    [AttributeUsage(AttributeTargets.Property|AttributeTargets.Field)]
    public class ValidLengthAttribute : AbstractValidAttribute
    {
        private int min = 0;
        private int max = 0;
        public ValidLengthAttribute(int min, int max)
        {
            this.min = min;
            this.max = max;
        }
        public override bool Valide(object value)
        {
            if (value != null && !string.IsNullOrWhiteSpace(value.ToString()))
            {
                if (long.TryParse(value.ToString(), out long result))
                {
                    if (result > min && result < max)
                    {
                        return true;
                    }
                }
            }
            return false;
        }
    }
}
