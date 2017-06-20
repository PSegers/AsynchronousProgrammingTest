using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaartenSpel
{
    public class Kaart
    {
        public int Nummer { get; set; }
        //public Symbool Symbool { get; set; }

        public Kaart (int nummer)
        {
            this.Nummer = nummer;
            //this.Symbool = symbool;
        }

        public override String ToString()
        {
            return String.Format($"Kaart: {this.Nummer}");
    }
    }
}
