using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reflection
{
    /// <summary>
    /// 单列模式，在程序中只有一个实例
    /// </summary>
    public sealed class Singleton
    {
        /// <summary>
        /// 定义一个静态实例
        /// </summary>
        private static Singleton _singleton;
        /// <summary>
        /// 构造函数私有化，别人就不能进行构造
        /// </summary>
        private Singleton()
        {
            Console.WriteLine("Singleton被构造");
        }
        /// <summary>
        /// 静态构造函数初始化，它是在程序创建时自动调用
        /// </summary>
        static Singleton()
        {
            _singleton = new Singleton();
        }
        /// <summary>
        /// 对外提供构造方法，外部调用构造方法进行创建对象
        /// </summary>
        /// <returns></returns>
        public static Singleton GetInstance()
        {
            return _singleton;
        }
    }
}
