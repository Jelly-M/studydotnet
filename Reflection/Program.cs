// See https://aka.ms/new-console-template for more information
using Reflection;
using System.Reflection;

Console.WriteLine("Hello, World!");

Console.WriteLine(typeof(int));
Console.WriteLine(typeof(string));
Singleton singleton = Singleton.GetInstance();
Singleton singleton2 = Singleton.GetInstance();
Singleton singleton3 = Singleton.GetInstance();
//hashcode值是一样的，说明是同一个对象
Console.WriteLine(singleton.GetHashCode());
Console.WriteLine(singleton2.GetHashCode());
Console.WriteLine(singleton3.GetHashCode());
{
    //无参构造
    Assembly assembly = Assembly.Load("");//加载程序集，只需要一个名称即可，不需要后缀名还有其他方法比如可以是全路径还可以程序集名称加后缀名
    Type type = assembly.GetType("");//拿到类型
    Singleton obj = (Singleton)Activator.CreateInstance(type, true);
}
{
    //有参构造
    Assembly assembly = Assembly.Load("");//加载程序集，只需要一个名称即可，不需要后缀名还有其他方法比如可以是全路径还可以程序集名称加后缀名
    Type type = assembly.GetType("");//拿到类型
    object obj1 = (object)Activator.CreateInstance(type);
    object obj2 = (object)Activator.CreateInstance(type, new object[] { 123 });
    object obj3 = (object)Activator.CreateInstance(type, new object[] { "123" });

}
{
    //泛型
    Assembly assembly = Assembly.Load("");//加载程序集，只需要一个名称即可，不需要后缀名还有其他方法比如可以是全路径还可以程序集名称加后缀名
    Type type = assembly.GetType("xxxxClass`3");//拿到类型,这里一定要指定泛型的个数，也就是占位符
    Type newType = type.MakeGenericType(new Type[] { typeof(int), typeof(string), typeof(DateTime) });
    object obj1 = (object)Activator.CreateInstance(newType);
}
{
    //方法调用
    Assembly assembly = Assembly.Load("");
    Type type = assembly.GetType("");
    object o = Activator.CreateInstance(type);
    MethodInfo methodInfo = type.GetMethod("show1");
    methodInfo.Invoke(o, null);//代表没有参数
}
{
    //方法调用
    Assembly assembly = Assembly.Load("");
    Type type = assembly.GetType("");
    object o = Activator.CreateInstance(type);
    MethodInfo methodInfo = type.GetMethod("show1");
    methodInfo.Invoke(o, new object[] { 123, "123" });//代表第一个入参是整形，第二个是字符串
}
{
    //静态方法的调用
    Assembly assembly = Assembly.Load("");
    Type type = assembly.GetType("");
    object o = Activator.CreateInstance(type);
    MethodInfo methodInfo = type.GetMethod("show1");
    methodInfo.Invoke(o, new object[] { 123, "123" });//代表第一个入参是整形，第二个是字符串
    //或者
    methodInfo.Invoke(null, new object[] { "静态方法调用" });
}
{
    //反射调用泛型类泛型方法
    Assembly assembly = Assembly.Load("");
    Type type = assembly.GetType("xxxxClass`1");
    Type newType = type.MakeGenericType(new Type[] { typeof(int) });
    object oGeneric = Activator.CreateInstance(newType);
    MethodInfo method = newType.GetMethod("show");//调用泛型方法
    if (method.IsGenericMethod)
    {
        method.MakeGenericMethod(new Type[] { typeof(string) });//这是泛型方法的参数
        method.Invoke(oGeneric, new object[] { "泛型方法第一个参数" });
    }
}
Console.WriteLine("Hello, World!");
