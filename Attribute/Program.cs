// See https://aka.ms/new-console-template for more information
using AttributeDay1;
using AttributeDay1.eg;
using AttributeDay1.eg.Extension;

Console.WriteLine("开始学习特性!");
Student student = new Student();
student.Name = "张三";
student.Id = 1;
Management.InClassRoom(student);

Console.WriteLine("特性的使用");
{
    Console.WriteLine(UserStateEnum.Normal.GerRemark());
    Console.WriteLine(UserStateEnum.Deleted.GerRemark());
    Console.WriteLine(UserStateEnum.Forzen.GerRemark());
}

Console.WriteLine("结束学习特性!");



