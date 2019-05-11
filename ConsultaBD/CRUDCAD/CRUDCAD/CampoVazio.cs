using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUDCAD
{
    class CampoVazio:Exception
    {
        public CampoVazio()
        { }

        public CampoVazio(string msg):base(msg)
        { }
    }
}
