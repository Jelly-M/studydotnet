using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDay1
{
    /// <summary>
    /// 特性就是一个类，直接或者简介集成Attribute
    /// 一般是以Attribute结尾，声明的时候是可以省略的
    /// 可以声明当前特性作用范围是否可以重复，一个类上面可以添加多个同样的特性就重复
    /// </summary>
    [AttributeUsage(AttributeTargets.Class|AttributeTargets.Module|AttributeTargets.Property,AllowMultiple =true)]
    public class CustomAttribute:System.Attribute
    {
        public CustomAttribute() { }
        public CustomAttribute(string name) { }
        public string Desc { get; set; }
        public string remark = string.Empty;

        public void Show()
        {
            Console.WriteLine($"this is {nameof(CustomAttribute)}");
        }
    }
}
