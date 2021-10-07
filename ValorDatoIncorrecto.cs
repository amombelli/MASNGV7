using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tecser.Business.MainApp
{
    public class ValorDatoIncorrecto : Exception
    {
        public ValorDatoIncorrecto(string message)
            : base(message)
        {

        }
    }
}
