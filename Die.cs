namespace DieExample
{
    /// <summary>
    /// A class representing a die with a given number of sides.
    /// </summary>
    public class Die
    {

        /// <summary>
        /// Gets or sets a value indicating whether the die is held and will not be rolled.
        /// </summary>
        public bool ifHold { get; set; }

        private int _numberOfSides;

        /// <summary>
        /// Gets a random number generator used to roll the die.
        /// </summary>
        protected Random _randomDiceNumber;

        /// <summary>
        /// Gets a random number generator used to roll the die.
        /// </summary>
        public Random RandomDiceNumber
        {
            get => _randomDiceNumber;

        }
        /// <summary>
        /// Gets or sets the current value of the die.
        /// </summary>
        public int Current { get; set; }

        public Die(int numberOfSides = 6)
        {
            _randomDiceNumber = new Random();
            ifHold = false;
            NumberOfSides = numberOfSides;
            Current = _randomDiceNumber.Next(1, _numberOfSides + 1);
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Die"/> class with a given number of sides.
        /// The number of sides must be between 2 and 99, inclusive. If an invalid number of sides is provided,
        /// the die is initialized with 6 sides.
        /// </summary>
        /// <param name="numberOfSides">The number of sides on the die.</param>
        public int NumberOfSides
        {
            get { return _numberOfSides; }
            set
            {
                if (value < 2 || value > 99)
                    _numberOfSides = 6;
                else
                    _numberOfSides = value;
            }
        }

        /// <summary>
        /// Rolls the die. If the die is not held, its current value is set to a random number between 1 and the number of sides on the die, inclusive.
        /// </summary>
        public void Roll()
        {
            int diceRoll = _randomDiceNumber.Next(1, _numberOfSides + 1);
            if (!ifHold)
            {
                Current = diceRoll;
            }
        }

        /// <summary>
        /// Returns a string representation of the current state of the die, including its current value and hold status.
        /// </summary>
        public override string ToString()
        {
            return "Current value: " + Current + ", Hold status: " + ifHold;
        }
    }
}
