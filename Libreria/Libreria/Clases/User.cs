using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Clases
{
    public class Users
    {
        private string _nombre = "Pice";
        private string _password = "Password";
        private TarjetaDeCredito _creditCard;
        private double _dinero;

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        public string Password
        {
            get { return _password; }
            set { _password = value; }
        }

        public double Cash { get { return _dinero; } set { _dinero = value; } }
    }
}