using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GenericDay1
{
    public class People
    {
        public int Age { get; set; }
        public string Name { get; set; }

        public void SayHi(string name)
        {
            Console.WriteLine($"你好{name}");
        }
    }
}
