using GenericDay1;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generic
{
    /// <summary>
    /// 泛型约束
    /// 不同的参数类型都能进来；任何类型都能过来，程序怎么知道传入的是哪个类？
    /// 没有约束，没有自由
    /// 泛型约束---基类的约束：保证了T一定是某个类或者子类
    /// 1.这样传入的泛型就可以用基类的一切方法和属性--权力
    /// 2.强制保证了T一定是基类或者基类的子类。--义务
    /// </summary>
    public class Constraint
    {
        /// <summary>
        /// 基类约束
        /// 扩展知识点，约束是可以叠加的，就是People后面是可以添加其他约束的，这样子传入的param就是多样化的
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="param"></param>
        public static void Show<T>(T param) 
            where T : People
        {
            Console.WriteLine($"{param.Age},{param.Name}");
            param.SayHi(param.Name);
        }
        /// <summary>
        /// 接口约束
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        public static T GetNameList<T>(T t) 
            where T : ISports //接口约束
            //where T : class //引用类型约束
            //where T :struct //值类型约束
            //where T :new()    //无参数构造函数约束
        {
            t.Running();//传入接口的实现类，实现的方法
            T tnew = default(T);//会根据T的不同，赋予默认值
            //T tnew1 = new T();//这个是必须有无参构造函数约束
            return t;
        }

    }
}
