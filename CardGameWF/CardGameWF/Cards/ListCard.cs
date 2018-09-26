using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using System.ComponentModel;
using System.Collections.ObjectModel;

namespace Cards
{
    [Serializable]
    public class ListCard : INotifyPropertyChanged
    {

        /// <summary>
        /// Initialize List of Cards
        /// </summary>
        /// 
        public List<Card> listCards { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public ListCard()
        {
            listCards = new List<Card>();
        }

        /// <summary>
        /// Initialize List of Cards by byte array
        /// </summary>
        public ListCard(byte[] byteArray)
        {
            using (var memStream = new MemoryStream())
            {
                var binaryFormatter = new BinaryFormatter();
                memStream.Write(byteArray, 0, byteArray.Length);
                memStream.Seek(0, SeekOrigin.Begin);
                List<Card> obj = (List<Card>)binaryFormatter.Deserialize(memStream);
                this.listCards = obj;
            }
        }

        public ListCard(string stringListCard)
        {
            listCards = new List<Card>();
            string[] stringCards = stringListCard.Split('|');
            for (int i = 0; i < stringCards.Length; i++)
            {
                if (!String.IsNullOrEmpty(stringCards[i]))
                {
                    try
                    {
                        AddCardToList(new Card(stringCards[i]));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex.StackTrace);
                    }
                }
            }
        }
        public void AddCardToList(Card c)
        {
            listCards.Add(c);
        }

        /// <summary>
        /// Create list with 52 elements
        /// </summary>
        public void CreateListCards()
        {
            for (int value = 3; value <= 15; value++)
            {
                for (int power = 1; power <= 4; power++)
                {
                    Card newCard = new Card(value, power);
                    listCards.Add(newCard);
                }
            }
            DisplayCard();
        }
        public void DisplayCard()
        {
            foreach (var item in listCards)
            {
                Console.WriteLine(item.Value.ToString() + "-" + item.Power.ToString());
            }
        }
        //Get list of cards
        public List<Card> GetListCards()
        {
            return listCards;
        }
        //Get card at index in list of cards
        public Card GetCardAt(int index)
        {
            return listCards.ElementAt(index);
        }

        //Remove card from list
        public bool RemovedCardAt(int postionIndex)
        {
            this.listCards.RemoveAt(postionIndex);
            return true;
        }

        //Get lenght of list cards
        public int CountCards()
        {
            return listCards.Count();
        }

        private void RandomPostionCards()
        {
            Random rad = new Random();
            for (int i = 0; i < listCards.Count; i++)
            {
                int j = rad.Next(51);
                int k = rad.Next(51);
                Card c = listCards[j];
                listCards[j] = listCards[k];
                listCards[k] = c;
            }
        }
        //Dead card for 4 players and return a list of listcards
        public List<ListCard> DealCard(int players)
        {
            List<ListCard> listCardsForPlayers = new List<ListCard>();
            Random rand = new Random();
            ListCard fullListCard = new ListCard();
            fullListCard.CreateListCards();
            fullListCard.RandomPostionCards();
            for (int i = 0; i < players; i++)
            {
                ListCard cardsForPlayer = new ListCard();
                while (cardsForPlayer.CountCards() < 13)
                {
                    int j = rand.Next(fullListCard.CountCards());
                    Card randomCard = fullListCard.GetCardAt(j);
                    cardsForPlayer.AddCardToList(randomCard);
                    fullListCard.RemovedCardAt(j);
                }
                cardsForPlayer.Sort();
                cardsForPlayer.DisplayCard();
                listCardsForPlayers.Add(cardsForPlayer);
            }
            return listCardsForPlayers;
        }

        // Convert list card to bytes array
        public byte[] ConvertToByteArray()
        {
            BinaryFormatter binaryFormatter = new BinaryFormatter();
            using (var memoryStream = new MemoryStream())
            {
                binaryFormatter.Serialize(memoryStream, this.listCards);
                return memoryStream.ToArray();
            }
        }

        public void Sort()
        {
            if (listCards.Count > 1 && listCards != null)
            {
                listCards.Sort(delegate (Card x, Card y)
                {
                    if (x.Value == y.Value)
                    {
                        return x.Power.CompareTo(y.Power);
                    }
                    return x.CompareTo(y);
                });
            }
        }

        public int Contains(Card card)
        {
            for (int i = 0; i < listCards.Count; i++)
            {
                if (listCards.ElementAt(i).Equals(card))
                {
                    return i;
                }
            }
            return -1;
        }

        public bool IsEmpty()
        {
            return listCards.Count() == 0;
        }


        public bool Equals(ListCard otherCards)
        {
            Console.WriteLine("In equals listcard function ");
            Console.WriteLine("Cards is " + this.CountCards());
            if (this.CountCards() != otherCards.CountCards())
            {
                return false;
            }
            for (int i = 0; i < this.CountCards(); i++)
            {
                Console.WriteLine(i);
                Console.WriteLine(this.GetCardAt(i).ToString());
                Console.WriteLine(otherCards.GetCardAt(i).ToString());

                if (!this.GetCardAt(i).Equals(otherCards.GetCardAt(i)))
                {
                    return false;
                }


            }
            return true;
        }
        public string ToString()
        {
            string result = String.Empty;
            foreach (var card in listCards)
            {
                result += card.ToString() + "|";
            }

            return result;
        }
    }
}
