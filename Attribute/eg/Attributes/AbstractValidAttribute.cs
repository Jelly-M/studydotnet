using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDay1.eg.Attributes
{
    public abstract class AbstractValidAttribute : Attribute
    {
        public abstract bool Valide(object value);
    }
}
