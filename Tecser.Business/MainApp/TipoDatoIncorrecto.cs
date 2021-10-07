using System;

namespace Tecser.Business.MainApp
{
    public class TipoDatoIncorrecto : Exception
    {
        public TipoDatoIncorrecto(string message)
            : base(message)
        {

        }
    }
}

