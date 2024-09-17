namespace DieExample
{
    /// <summary>
    /// A class representing a biased die that has a tendency to roll higher or lower numbers.
    /// </summary>
    class BiasedDie : Die
    {
        private bool _biasedPositive;

        /// <summary>
        /// Gets or sets a value indicating whether the die is biased towards rolling higher numbers.
        /// </summary>
        public bool BiasedPositive
        {
            get => _biasedPositive;
            set => _biasedPositive = value;
        }
        /// <summary>
        /// Initializes a new instance of the <see cref="BiasedDie"/> class with a given number of sides and bias.
        /// </summary>
        /// <param name="numberOfSides">The number of sides on the die.</param>
        /// <param name="biasedPositive">A value indicating whether the die is biased towards rolling higher numbers.</param>
        public BiasedDie(int numberOfSides, bool biasedPositive) : base(numberOfSides)
        {
            BiasedPositive = biasedPositive;
        }
        /// <summary>
        /// Rolls the biased die and sets the <see cref="Die.Current"/> value to the result.
        /// If the die is biased towards rolling higher numbers, the roll will be biased towards higher values.
        /// If the die is biased towards rolling lower numbers, the roll will be biased towards lower values.
        /// If the die is held, the roll is not performed and the <see cref="Die.Current"/> value remains unchanged.
        /// </summary>
        public new void Roll()
        {
            int diceRoll;
            if (BiasedPositive)
            {
                diceRoll = RandomDiceNumber.Next(Current, NumberOfSides + 1);
            }
            else
            {
                diceRoll = RandomDiceNumber.Next(1, Current + 1);
            }
            if (!ifHold)
            {
                Current = diceRoll;
            }
        }
    }
}
