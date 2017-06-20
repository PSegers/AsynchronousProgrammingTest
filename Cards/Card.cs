using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Card
    {
        public int Number { get; set; }
        //public Symbool Symbool { get; set; }

        public Card (int number)
        {
            this.Number = number;
            //this.Symbool = symbool;
        }

        public override String ToString()
        {
            return String.Format($"card: {this.Number}");
    }
    }
}
