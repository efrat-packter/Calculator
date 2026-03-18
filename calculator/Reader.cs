using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace calculator
{
    public class Reader : IReader
    {

        public string Read()
        {
          return  Console.ReadLine(); 
        }
    }
}
