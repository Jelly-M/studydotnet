using AttributeDay1.eg.Extension;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AttributeDay1
{
    public class Management
    {
        public static void InClassRoom(Student student)
        {
            //这是判断特性是否加在类型上面
            Type type = typeof(Student);
            if (type.IsDefined(typeof(CustomAttribute), true)) //先判断是否定义有自定义特性
            {
                CustomAttribute attribute = (CustomAttribute)type.GetCustomAttribute(typeof(CustomAttribute), true);
                Console.WriteLine($"{attribute.Desc}_{attribute.remark}");
                attribute.Show();
            }
            //这是特性加下字段上

            PropertyInfo propertyInfo= type.GetProperty("Id");
            if (propertyInfo.IsDefined(typeof(CustomAttribute), true)) 
            {
                CustomAttribute attribute = (CustomAttribute)propertyInfo.GetCustomAttribute(typeof(CustomAttribute), true);
                Console.WriteLine($"{attribute.Desc}_{attribute.remark}");
                attribute.Show();
            }
            student.Validate();
            //同理方法上面也是可以加的
            student.Study();
        }
    }
}
