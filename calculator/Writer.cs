using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class Writer : IWriter
    {
        public void Write(string output)
        {
            Console.WriteLine( output);
        }
    }
}
