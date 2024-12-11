using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using AttributeDay1.eg.Attributes;

namespace AttributeDay1.eg.Extension
{
    /// <summary>
    /// 枚举的扩展，用于特性的信息
    /// </summary>
    public static class EnumExt
    {
        public static string GerRemark(this Enum value)
        {
            string desc = string.Empty;
            Type valueType=value.GetType();
            FieldInfo field= valueType.GetField(value.ToString());
            if (field.IsDefined(typeof(RemarkAttribute), true))
            {
                RemarkAttribute remarkAttribute= (RemarkAttribute)field.GetCustomAttribute(typeof(RemarkAttribute), true);
                desc=remarkAttribute.GetDescption();
                return desc;
            }
            else
            {
                return value.ToString();
            }            
        }
    }
}
