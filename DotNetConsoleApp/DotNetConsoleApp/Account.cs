using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DotNetConsoleApp
{
    public class Account : IAccount
    {
        public double balance { get; set; }
        public string number { get; set; }
    }
}
