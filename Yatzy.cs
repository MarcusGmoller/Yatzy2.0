namespace DieExample
{
    public class Yatzy
    {
        /// <summary>
        /// A list of dice used in the game of Yatzy.
        /// </summary>
        public List<Die> Dice { get; set; }

        /// <summary>
        ///  dictionary that keeps track of the scores for each category in the game of Yatzy.
        ///  The key is the name of the category and the value is the score.
        /// </summary>
        public Dictionary<string, int> ScoreBoard = new Dictionary<string, int>()
        {
            {"Ones", -1},
            {"Twos", -1},
            {"Threes", -1 },
            {"Fours", -1 },
            {"Fives", -1 },
            {"Sixes", -1},
            {"Three of a Kind", -1 },
            {"Four of a Kind", -1 },
            {"Full House", -1},
            {"Small Straight", -1},
            {"Large Straight", -1},
            {"Yatzy", -1},
            {"Chance", -1},
        };
        List<string> Score = new List<string>()
        {
            "Ones","Twos","Threes","Fours","Fives","Sixes","Three of a Kind","Four of a Kind","Full House","Small Straight",
            "Large Straight","Yatzy","Chance"
        };
        /// <summary>
        /// basic construtor, creates a new list"Dice" and populates it with 5 unbiased dices
        /// </summary>
        public Yatzy()
        {
            Dice = new List<Die>();
            for (int i = 0; i < 5; i++)
            {
                Dice.Add(new Die());
            }
        }
        /// <summary>
        /// Creates a new game of Yatzy with a customized set of dice.
        /// </summary>
        /// <param name="normalDice">The number of unbiased dice to include in the game </param>
        /// <param name="positiveDice">The number of biased dice that are more likely to roll high numbers to include in the game. dices</param>
        /// <param name="negativeDice">The number of biased dice that are more likely to roll low numbers to include in the game</param>
        public Yatzy(int normalDice, int positiveDice, int negativeDice)
        {
            Dice = new List<Die>();
            for (int a = 0; a < normalDice; a++)
            {
                Dice.Add(new Die());
            }
            for (int a = 0; a < positiveDice; a++)
            {
                Dice.Add(new BiasedDie(6, true));
            }
            for (int a = 0; a < negativeDice; a++)
            {
                Dice.Add(new BiasedDie(6, false));
            }
        }
        /// <summary>
        /// Loops through the list "dice" and rolls based on how the dices is created biased/regular
        /// </summary>
        public void RollDices()
        {
            foreach (var item in Dice)
            {
                if (item is BiasedDie biasedDie)
                {
                    biasedDie.Roll();
                }
                else
                    item.Roll();
            }
        }
        /// <summary>
        /// Loops through all dices, and adds all value of dice together.
        /// </summary>
        /// <returns>total value of all dice </returns>
        public int Chance()
        {
            int sumOfDie = 0;
            foreach (var item in Dice)
            {
                sumOfDie = sumOfDie + item.Current;
            }
            return sumOfDie;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="num"></param>
        /// <returns></returns>
        public int NumberOf(int num)
        {
            int numberOfDie = 0;
            foreach (var item in Dice)
            {
                if (num == item.Current)
                    numberOfDie = numberOfDie + 1;
            }
            return numberOfDie;
        }
        /// <summary>
        /// Shows the current state of the dice in the console.
        /// The dice that are held are displayed in green, while the dice that are not held are displayed in red.
        /// </summary>
        public void ShowDice()
        {

            Format.EasyColour("------------------------Rolled Dice-------------------------", ConsoleColor.Cyan);
            Console.WriteLine("A B C D E");

            foreach (var item in Dice)
            {
                if (item.ifHold)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.Write(item.Current + " ");
                    Console.ResetColor();
                }
                if (item.ifHold == false)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.Write(item.Current + " ");
                    Console.ResetColor();
                }
            }
            Format.EasyColour("\n------------------------------------------------------------", ConsoleColor.Cyan);
        }
        /// <summary>
        /// Loops through the dice, 5 times, if 3 numbers are the samme 
        /// </summary>
        /// <returns></returns>
        public int ThreeOfAKind()
        {
            for (int i = 1; i <= 6; i++)
            {
                if (NumberOf(i) == 3)
                {
                    return Chance();
                }
            }
            return 0;
        }
        /// <summary>
        /// Calculates the score for the "Four of a Kind" category in a Yatzy game.
        /// </summary>
        /// <returns> The score for the "Four of a Kind" category.</returns>
        public int FourOfAKind()
        {
            for (int i = 1; i <= 6; i++)
            {
                if (NumberOf(i) == 4)
                {
                    return Chance();
                }
            }
            return 0;
        }
        /// <summary>
        /// Calculates the score for the "Five of a Kind" (Yatzy) category in a Yatzy game.
        /// </summary>
        /// <returns>The score for the "Five of a Kind" category</returns>
        public int FiveOfAKind()
        {
            for (int i = 1; i <= 6; i++)
            {
                if (NumberOf(i) == 5)
                {
                    return 50;
                }
            }
            return 0;
        }
        /// <summary>
        /// Calculates the score for the "Full House"  category in a Yatzy game.
        /// </summary>
        /// <returns>The score for the "Full House" category</returns>
        public int FullHouse()
        {
            for (int i = 1; i <= 6; i++)
            {
                if (NumberOf(i) == 3)
                    for (int a = 1; a <= 6; a++)
                    {
                        if (NumberOf(a) == 2 && a != i)
                        {
                            return 25;
                        }
                    }
                {
                }
            }
            return 0;
        }
        /// <summary>
        /// Calculates the score for the "Small Straight" category in a Yatzy game.
        /// </summary>
        /// <returns>The score for the "Small Straight" category</returns>
        public int SmallStraight()
        {
            HashSet<int> set = new HashSet<int>();
            foreach (var item in Dice)
            {
                set.Add(item.Current);
            }
            for (int i = 0; i < 3; i++)
            {
                if (set.Contains(i) && set.Contains(i + 1) && set.Contains(i + 2) && set.Contains(i + 3))
                {
                    return 30;
                }
            }
            return 0;
        }
        /// <summary>
        /// Calculates the score for the "Large Straight" category in a Yatzy game.
        /// The dice are added to a HashSet to remove duplicates and check for straights.
        /// </summary>
        /// <returns>The score for the "Large Straight" category.</returns>
        public int LargeStraight()
        {
            HashSet<int> set = new HashSet<int>();
            foreach (var item in Dice)
            {
                set.Add(item.Current);
            }
            for (int i = 0; i < 3; i++)
            {
                if (set.Contains(i) && set.Contains(i + 1) && set.Contains(i + 2) && set.Contains(i + 3)
                    && set.Contains(i + 4))
                {
                    return 40;
                }
            }
            return 0;
        }
        /// <summary>
        /// Prompts the user to choose which dice to hold or release for the next roll in a Yatzy game.
        /// The user can input the dice as a comma-separated list (e.g. "A,B,E").
        /// </summary>
        public void Hold()
        {
            while (true)
            {
                Console.Write("What dice to hold(eg - A,B,E)? ");
                string diceToHold = Console.ReadLine().ToUpper();
                string[] choices = diceToHold.Split(',');
                bool inputCheck = true;
                foreach (var item in choices)
                {
                    int dieOutput = item switch
                    {
                        "A" => 0,
                        "B" => 1,
                        "C" => 2,
                        "D" => 3,
                        "E" => 4,
                        _ => -1,
                    };
                    if (diceToHold == "")
                    {
                        break;
                    }
                    if (dieOutput < 0)
                    {
                        inputCheck = false;
                        break;
                    }
                    else
                    {
                        Dice[dieOutput].ifHold = !Dice[dieOutput].ifHold;
                    }
                }
                if (inputCheck)
                {
                    break;
                }
                else
                {
                    Format.EasyColour("Please choose a dice from A to E or press enter to continue", ConsoleColor.Red);
                }
            }
        }
        /// <summary>
        /// Calculates the score for a given category in a Yatzy game.
        /// </summary>
        /// <param name="scoreOf">The name of the category to calculate the score for.</param>
        /// <returns>The score for the given category.</returns>
        private int CalculateScoreOf(string scoreOf)
        {
            int value = scoreOf switch
            {
                "Ones" => NumberOf(1),
                "Twos" => NumberOf(2) * 2,
                "Threes" => NumberOf(3) * 3,
                "Fours" => NumberOf(4) * 4,
                "Fives" => NumberOf(5) * 5,
                "Sixes" => NumberOf(6) * 6,
                "Three of a Kind" => ThreeOfAKind(),
                "Four of a Kind" => FourOfAKind(),
                "Yatzy" => FiveOfAKind(),
                "Small Straight" => SmallStraight(),
                "Large Straight" => LargeStraight(),
                "Full House" => FullHouse(),
                "Chance" => Chance(),
            };
            return value;
        }
        /// <summary>
        /// Prompts the user to choose a score to save, and saves the score for the chosen category in a Yatzy game.
        /// </summary>
        public void WriteScore()
        {
            while (true)
            {
                {
                    Console.Write("Which score would you like to save?");
                    string input = Console.ReadLine();
                    bool wordFinder = false;
                    string foundWord = "";
                    foreach (string item in Score)
                    {
                        if (item.Equals(input, StringComparison.OrdinalIgnoreCase))
                        {
                            wordFinder = true;
                            foundWord = item;
                            break;
                        }
                    }
                    if (wordFinder)
                    {
                        if (ScoreBoard.TryGetValue(foundWord, out int value))
                        {
                            if (value == -1)
                            {
                                ScoreBoard[foundWord] = CalculateScoreOf(foundWord);
                                break;
                            }
                            else
                            {
                                Format.EasyColour("Score already saved", ConsoleColor.Red);
                            }
                        }
                    }
                    else if (input == "")
                    {
                        Format.EasyColour("You must save a score", ConsoleColor.Red);
                    }
                    else
                    {
                        Format.EasyColour("Invalid score. Try again", ConsoleColor.Red);
                    }
                }
            }

        }
        /// <summary>
        /// Displays the scores for each category in a Yatzy game.
        /// Scores that have not been saved are shown in their calculated value.
        /// Scores that have been saved are displayed in blue.
        /// </summary>
        public void ShowScores()
        {
            foreach (var item in ScoreBoard)
            {
                if (item.Value == -1)
                {
                    Console.WriteLine($"{item.Key}: {CalculateScoreOf(item.Key)}");
                }
                if (item.Value != -1)
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine($"{item.Key}: {item.Value}");
                }
                Console.ResetColor();
            }
            Console.WriteLine();
        }
        /// <summary>
        /// Calculates the final score in a Yatzy game by summing the scores for all categories.
        /// </summary>
        /// <returns>The final score in the Yatzy game.</returns>
        public int FinalScoreCalculted()
        {
            int totalScore = 0;
            foreach (var item in ScoreBoard)
            {
                totalScore += item.Value;
            }
            return totalScore;
        }
    }
}
