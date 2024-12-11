using AttributeDay1.eg;
using AttributeDay1.eg.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDay1
{
    /// <summary>
    /// 特性如何声明在类上面
    /// 如果是构造函数，直接传值，如果是参数或者字段需要带上名称
    /// </summary>
    [Custom("构造参数",Desc ="属性传参",remark ="字段传参")]
    public class Student
    {
        [Custom]
        public int Id { get; set; }
        [ValidLength(1,100)]
        public string Name { get; set; }

        public void Study()
        {
            Console.WriteLine($"{this.Name}开始学习特性知识。");
        }
    }
}
