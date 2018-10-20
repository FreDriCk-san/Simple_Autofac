using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DI_Tests
{
    public class ConstructorClass : IConstructorClass
    {
        public ConstructorClass(IDefaultClassA _defaultClassA)
        {

        }

        public void ConstructorWriteA()
        {
            Console.WriteLine("Constructor Write A");
        }
    }
}
