using AttributeDay1.eg;
using AttributeDay1.eg.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDay1.eg.Extension
{
    /// <summary>
    /// 验证的扩展，用于特性的行为
    /// </summary>
    public static class ValidateExt
    {
        public static bool Validate(this object obj)
        {
            Type type = obj.GetType();
            foreach(var prop in type.GetProperties())
            {
                if (prop.IsDefined(typeof(AbstractValidAttribute), true))
                {
                    object[] attributeArray=prop.GetCustomAttributes(typeof(AbstractValidAttribute), true);
                    foreach(AbstractValidAttribute attrbute in attributeArray)
                    {
                        AbstractValidAttribute attribute = (AbstractValidAttribute)prop.GetCustomAttribute(typeof(AbstractValidAttribute), true);
                        if (!attribute.Valide(prop.GetValue(obj)))
                        {
                            return false;//表示在foreach中进行终止
                        }
                    }                    
                }
            }
            return true;
        }
    }
}
