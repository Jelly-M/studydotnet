using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime;
using System.Text;
using System.Threading.Tasks;
using System.Transactions;

namespace Reflection
{
    /// <summary>
    /// 利用反射写内容相互赋值
    /// 考虑性能问题，不建议使用反射
    /// 
    /// </summary>
    internal class ReflectManager
    {
        public static TOut Trans<TIn,TOut>(TIn tIn)
        {
            TOut tout=Activator.CreateInstance<TOut>();
            foreach(var itemOut in tout.GetType().GetProperties())
            {
                foreach(var itemIn in tIn.GetType().GetProperties())
                {
                    if (itemOut.Name.Equals(itemIn.Name))
                    {
                        itemOut.SetValue(tout,itemIn.GetValue(tIn));
                        break;
                    }
                }
            }
            foreach(var itemOut in tout.GetType().GetFields())
            {
                foreach(var itemIn in tIn.GetType().GetFields())
                {
                    if (itemOut.Name.Equals(itemIn.Name))
                    {
                        itemOut.SetValue(tout, itemIn.GetValue(tIn));
                        break;
                    }
                }
            }
            return tout;
        }
        /// <summary>
        /// 改编的写法
        /// </summary>
        /// <typeparam name="TIn"></typeparam>
        /// <typeparam name="TOut"></typeparam>
        /// <param name="tIn"></param>
        /// <returns></returns>
        public static TOut Trans2<TIn, TOut>(TIn tIn)
        {
            TOut tout = Activator.CreateInstance<TOut>();
            foreach (var itemOut in tout.GetType().GetProperties())
            {
                var propIn= tIn.GetType().GetProperty(itemOut.Name);
                if (propIn != null)
                {
                    itemOut.SetValue(tout, propIn.GetValue(tIn));
                }                
            }
            foreach (var itemOut in tout.GetType().GetFields())
            {
                var fieldIn= tIn.GetType().GetField(itemOut.Name);
                if (fieldIn != null)
                {
                    itemOut.SetValue(tout, fieldIn.GetValue(tIn));
                }
            }
            return tout;
        }
    }
}
