using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDay1
{
    public class SportBase : ISports
    {
        public void Running()
        {
            Console.WriteLine("开始跑步了");
        }
    }
}
