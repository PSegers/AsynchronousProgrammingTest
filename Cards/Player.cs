using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CardGame
{
    public class Player
    {
        public int ID { get; set; }
        //public List<card> carden { get; set; }
        public int CurrentCard { get; set; }

        public Player(int id)
        {
            this.ID = id;
            this.CurrentCard = 0;
        }

        public override String ToString()
        {
            return String.Format($"Player: {this.ID}");
        }
    }
}
