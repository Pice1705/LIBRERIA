using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Libreria.Clases
{
    public class TarjetaDeCredito
    {
        private string _numeroTarjeta = "1234";
        private DateTime _fechaVencimiento = new DateTime(2020, 1, 1);
        private string _codigoSeguridad = "012";
        private double _saldo = 345.70;

        public string NumberTarjeta
        {
            get { return _numeroTarjeta; }
            set { _numeroTarjeta = value; }
        }

        public string SecurityCode
        {
            get { return _codigoSeguridad; }
            set { _codigoSeguridad = value; }
        }

        public DateTime FechaVenc
        {
            get { return _fechaVencimiento; }
            set { _fechaVencimiento = value; }
        }

        public double Saldo
        {
            get { return _saldo; }
            set { _saldo = value; }
        }
    }
}