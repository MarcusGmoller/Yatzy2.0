namespace DieExample
{
    /// <summary>
    /// Plays a game of Yatzy.
    /// </summary>
    public class Game
    {
        public Yatzy yatzy;
        public void Play()
        {
            Console.WriteLine(Format.WriteMessage($"WELCOME TO YATZY!"));
            GamePick();
            while (yatzy.ScoreBoard.ContainsValue(-1))
            {
                int roundCount = 0;
                while (roundCount < 2)
                {
                    if (roundCount == 0)
                    {
                        Console.Clear();
                        Console.WriteLine(Format.WriteMessage($"Roll {roundCount + 1}/3"));
                        yatzy.ShowScores();
                        yatzy.ShowDice();
                        yatzy.Hold();
                        roundCount++;
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine(Format.WriteMessage($"Roll {roundCount + 1}/3"));
                        yatzy.RollDices();
                        yatzy.ShowScores();
                        yatzy.ShowDice();
                        yatzy.Hold();
                        roundCount++;
                    }
                }
                Console.Clear();
                Console.WriteLine(Format.WriteMessage($"Roll {roundCount + 1}/3 : You must save a score! "));
                yatzy.ShowScores();
                yatzy.ShowDice();
                yatzy.WriteScore();
                foreach (var dice in yatzy.Dice)
                {
                    dice.Current = dice.RandomDiceNumber.Next(1, dice.NumberOfSides + 1);
                    dice.ifHold = false;
                }
            }
            Format.EasyColour($"Your Final Score Was: {yatzy.FinalScoreCalculted()}", ConsoleColor.Yellow);
            Console.WriteLine("press any key to continue");
            Console.ReadKey();
            PlayAgain();


        }
        private void GamePick()
        {
            while (true)
            {
                Console.Write("What type of game do you want to play(1=Regular, 2=Biased)? ");
                string gameChoiceInput = Console.ReadLine();
                if (int.TryParse(gameChoiceInput, out int choiceNumber))
                {
                    if (choiceNumber == 1)
                    {
                        RegularGame();
                        break;
                    }
                    else if (choiceNumber == 2)
                    {
                        BiasedGame();
                        break;
                    }
                    else
                    {
                        Format.EasyColour("Must choose 1 or 2. Try again", ConsoleColor.Red);
                    }
                }
                else
                {
                    Format.EasyColour("Must choose 1 or 2. Try again", ConsoleColor.Red);

                }
            }
        }
        /// <summary>
        /// Prompts the user to choose between playing a regular game or a biased game, and initializes the game accordingly.
        /// </summary>
        /// <exception cref="FormatException">Thrown if the user provides an invalid input (i.e., something other than "1" or "2").</exception>
        private void RegularGame()
        {
            yatzy = new Yatzy();
        }

        private void BiasedGame()
        {
            int regular = 0;
            int positive = 0;
            int negative = 0;
            int totalDiceCount = 0;
            string[] diceType = { "Regular", "Positive", "Negative" };
            for (int i = 0; i < 3; i++)
            {
                Console.Write($"How many {diceType[i]} dice? ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int dicenumber))
                {
                    if (dicenumber >= 0 && dicenumber <= 5)
                    {
                        if (i == 0)
                        {
                            regular = regular + dicenumber;
                        }
                        if (i == 1)
                        {
                            positive = positive + dicenumber;
                        }
                        if (i == 2)
                        {
                            negative = negative + dicenumber;
                        }

                    }
                    else
                    {
                        Format.EasyColour("Pick a valid dice number (0-5)", ConsoleColor.Red);
                        i = -1;
                        regular = 0;
                        positive = 0;
                        negative = 0;
                        totalDiceCount = 0;
                    }
                }
                else
                {
                    Format.EasyColour("You must choose a number", ConsoleColor.Red);
                    i = -1;
                    regular = 0;
                    positive = 0;
                    negative = 0;
                    totalDiceCount = 0;
                }
                totalDiceCount = negative + positive + regular;
                if (totalDiceCount == 5)
                {
                    yatzy = new Yatzy(regular, positive, negative);
                    break;
                }
                else if (totalDiceCount > 5)
                {
                    i = -1;
                    regular = 0;
                    positive = 0;
                    negative = 0;
                    totalDiceCount = 0;
                    Format.EasyColour("Too many dices. Must choose 5 total dices", ConsoleColor.Red);
                }
                else if (totalDiceCount < 5 && i == 2)
                {
                    i = -1;
                    regular = 0;
                    positive = 0;
                    negative = 0;
                    totalDiceCount = 0;
                    Format.EasyColour("Too few dices need 5 total dices", ConsoleColor.Red);
                }
            }
        }
        /// <summary>
        /// Prompts the user to decide whether to play the game again.
        /// If the user selects "y", the game restarts. If the user selects "n", the program exits.
        /// </summary>
        private void PlayAgain()
        {
            while (true)
            {
                Console.Write("Do you want to play again(y/n)? ");
                string choice = Console.ReadLine().ToLower();
                if (choice == "y")
                {
                    Play();
                    break;
                }
                else if (choice == "n")
                {
                    Console.WriteLine("Games over");
                    Environment.Exit(0);
                    break;
                }
                else
                {
                    Format.EasyColour("Not an available option", ConsoleColor.Red);
                }
            }
        }

    }
}
