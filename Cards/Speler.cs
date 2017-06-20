using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KaartenSpel
{
    public class Speler
    {
        public int ID { get; set; }
        //public List<Kaart> Kaarten { get; set; }
        public int huidigeKaart { get; set; }

        public Speler(int id)
        {
            this.ID = id;
            this.huidigeKaart = 0;
        }

        public override String ToString()
        {
            return String.Format($"Speler: {this.ID}");
        }
    }
}
