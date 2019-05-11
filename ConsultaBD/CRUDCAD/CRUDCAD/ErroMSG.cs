using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCAD
{
    class ErroMSG:Exception
    {
        public ErroMSG()
        { }

        public ErroMSG
            (string msg) : base(msg)
        { }
    }
}
