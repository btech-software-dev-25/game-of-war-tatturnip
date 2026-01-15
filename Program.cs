using GameOfWar;


namespace GameOfWar
{

    class Program
    {
        static void Main(string[] args)
        {
            // Create an instance of the GameState class
            GameState state = new GameState();

            // Shuffle CardDeck within your instance
            state.CardDeck.Shuffle();

            // Deal 26 cards each from CardDeck to your instance's PlayerDeck and ComputerDeck
            state.PlayerDeck.PushCards(state.CardDeck.Deal(26));
            state.ComputerDeck.PushCards(state.CardDeck.Deal(26));

            // Call Lib.RunGame(), passing two parameters: the state object you instantiated above and the name of your PlayCards function
            Lib.RunGame(state, PlayCards);
        }


        // Create a function with the signature: static bool PlayCards(GameState state, int playerCardIndex)
        static bool PlayCards(GameState state, int playerCardIndex)
        {
            //     Pull the card at playerCardIndex from state.PlayerDeck
            Card playerCard = state.PlayerDeck.PullCardAtIndex(playerCardIndex);
            //     Pull the card at index 0 from state.ComputerDeck
            Card computerCard = state.ComputerDeck.PullCardAtIndex(0);


            //     Compare the two cards
            if (playerCard > computerCard)
            {
                //         If the player card is higher, the player gets both cards along with any in state.TableDeck
                state.PlayerDeck.PushCard(playerCard);
                state.PlayerDeck.PushCard(computerCard);
                state.PlayerDeck.PushCards(state.TableDeck.PullAllCards());
            }
            else if (playerCard < computerCard)
            {
                //         If the computer card is higher, the computer gets both cards along with any in state.TableDeck
                state.ComputerDeck.PushCard(playerCard);
                state.ComputerDeck.PushCard(computerCard);
                state.ComputerDeck.PushCards(state.TableDeck.PullAllCards());
            }
            else
            {

                //         If the player and computer cards are the same, both cards go into state.TableDeck

                state.TableDeck.PushCard(playerCard);
                state.TableDeck.PushCard(computerCard);
            }
            //     Check whether either state.PlayerDeck or state.ComputerDeck are empty
            if (state.PlayerDeck.Count == 0)
            {
                //         If the computer deck is empty, the player wins and state.Winner should be set to "Computer"
                state.Winner = "Computer";
                return true;
            }

            if (state.ComputerDeck.Count == 0)
            {
                //         If the player deck is empty, the computer wins and state.Winner should be set to "Player"
                state.Winner = "Player";
                return true;
            }

            return false;

        }
    }


    public class GameState
    {
        // Create a public Deck property called CardDeck
        public Deck CardDeck { get; set; }

        // Create a public Deck property called PlayerDeck
        public Deck PlayerDeck { get; set; }

        // Create a public Deck property called ComputerDeck
        public Deck ComputerDeck { get; set; }

        // Create a public Deck property called TableDeck
        public Deck TableDeck { get; set; }

        // Create a public string property called Winner
        public string Winner { get; set; }

        // Create a public constructor that accepts no parameters. It should:
        //    Initialize Winner to be empty (not null)
        //    Initialize CardDeck to be a new, fresh deck of 52 cards
        //    Initialize PlayerDeck, ComputerDeck, and TableDeck to be empty Deck objects (no cards)

        public GameState()
        {
            Winner = "";
            CardDeck = new Deck(new List<Card>(), false);
            PlayerDeck = new Deck(new List<Card>(), true);
            ComputerDeck = new Deck(new List<Card>(), true);
            TableDeck = new Deck(new List<Card>(), true);
        }
    }
}