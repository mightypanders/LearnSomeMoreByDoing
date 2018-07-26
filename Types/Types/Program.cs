using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Types
{
    class Program
    {
        static void Main(string[] args)
        {
            var d = new Deck();
            for (int i = 0; i < d.Cards.Count; i++)
            {
                Console.WriteLine(d[i]);
            }
            Console.WriteLine(d[4]);
            Console.ReadLine();
        }
    }

    class Deck
    {

        public Deck()
        {
            Cards = new List<Card>();
            for (int i = 0; i < 53; i++)
            {
                Cards.Add(new Card(i));
            }
        }
        public Card this[int index]
        {
            get { return Cards.ElementAt(index); }
        }
        public ICollection<Card> Cards { get; set; }

    }

    class Card
    {
        int _num = 0;
        public Card(int n)
        {
            Number = n;
        }

        public override string ToString()
        {
            return String.Format("Card Number: {0}", this.Number);
        }
        public int Number { get { return _num; } set { _num = value; } }
    }
}
