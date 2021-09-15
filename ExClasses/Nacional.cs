using System;
using System.Collections.Generic;
using System.Text;

namespace ExClasses
{
    class Nacional : Cartao
    {
        public Nacional() : base(true) { }
        public Nacional(double saldoConta):base(true,saldoConta) { }
    }
}
