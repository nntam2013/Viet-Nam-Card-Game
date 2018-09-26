using System;
using System.ComponentModel;

namespace Cards
{
    [Serializable]
    public class Card : IComparable, INotifyPropertyChanged
    {
        private const int WIDTH = 72;
        private const int HEIGHT = 96;
        private int value;
        public string ImageSource { get; set; }
        public int Value
        {
            set
            {
                if (value >= 3 && value <= 15)
                {
                    this.value = value;
                }
            }
            get { return this.value; }
        }
        private int power;

        public int Power
        {
            set
            {
                if (value >= 1 && value <= 4)
                {
                    this.power = value;
                }

            }
            get { return this.power; }
        }
        public bool IsSelected { get; set; }
        public Card(int value, int power)
        {
            Value = value;
            Power = power;
            ImageSource = CreateUriImageCard();
            IsSelected = false;
        }

        public Card(string stringCard)
        {
            try
            {
                string[] cardInfo = stringCard.Split('-');
                Value = int.Parse(cardInfo[0]);
                Power = int.Parse(cardInfo[1]);
                ImageSource = CreateUriImageCard();
                IsSelected = false;
                Console.WriteLine(Value + "-" + Power);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.StackTrace);
            }

        }
        public event PropertyChangedEventHandler PropertyChanged;

        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is Card))
            {
                return false;
            }
            else
            {
                return this.Value == ((Card)obj).Value && this.Power == ((Card)obj).Power;
            }
        }
        public bool EqualsValue(object obj)
        {
            if (obj == null || !(obj is Card))
            {
                return false;
            }
            else
            {
                return this.Value == ((Card)obj).Value;
            }
        }
        public override string ToString()
        {
            return this.Value.ToString() + "-" + this.Power.ToString();
        }

        public int CompareTo(object obj)
        {
            if (obj == null) return 1;
            Card card = obj as Card;
            if (card != null)
            {
                if (this.Value == card.Value)
                {
                    return this.Power.CompareTo(card.Power);
                }
                else
                {
                    return this.Value.CompareTo(card.Value);
                }
            }
            else
            {
                throw new ArgumentException("Object is not a Card");
            }
        }
        public bool IsSameCardValue(Card card2, Card card3 = null, Card card4 = null)
        {
            if (card2 == null)
            {
                return false;
            }
            if (card3 == null && card4 == null)
            {
                return this.Equals(card2);
            }
            if (card4 == null)
            {
                return this.Equals(card2) && card2.Equals(card3);
            }
            return this.Equals(card2) && card2.Equals(card3) && card3.Equals(card4);
        }
        private string CreateUriImageCard()
        {
            string uri = this.Value + "_" + this.Power + ".png";
            return uri;
        }
    }
}
