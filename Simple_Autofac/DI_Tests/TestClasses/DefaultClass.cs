using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Tests
{
    public class DefaultClass : IDefaultClassA, IDefaultClassB
    {
        public void DefaultWriteA()
        {
            Console.WriteLine("Default Write A");
        }

        public void DefaultWriteB()
        {
            Console.WriteLine("Default Write B");
        }
    }
}
