namespace GameOfWar
{
    public class Card
    {

        
        public string Suit { get; private set; }

        public int Rank { get; private set; }

        public Card(string suit, int rank)
        {
            Suit = suit;
            Rank = rank;
        }

        
        public static bool operator >(Card card1, Card card2)
        {
            return card1.Rank > card2.Rank;
        }

        public static bool operator <(Card card1, Card card2)
        {
            return card1.Rank < card2.Rank;
        }


        public string RankString()
        {
            if (Rank >= 0 && Rank <= 8)
            {
                return (Rank + 2).ToString();
            }

            switch (Rank)
            {
                case 0: return "2";
                case 1: return "3";
                case 2: return "4";
                case 3: return "5";
                case 4: return "6";
                case 5: return "7";
                case 6: return "8";
                case 7: return "9";
                case 8: return "10";
                case 9: return "Jack";
                case 10: return "Queen";
                case 11: return "King";
                case 12: return "Ace";
                default: return "Unknown";
            }
        }
    }
}