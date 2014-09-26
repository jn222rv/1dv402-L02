using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1C
{
    public class SecretNumber
    {
        GuessedNumber _guessedNumbers;
        int? _number;
        public const int MaxNumberOfGuesses = 7;

        public bool CanMakeGuess
        {
            get;
            private set;
        }
        public int Count
        {
            get; 
            private set;
        }
        public int? Guess
        {
            get; 
            private set;
        }
        public GuessedNumber[] GuessedNumbers
        {
            get;
            private set;
        }
        public int? Number
        {
            get; 
            private set;
        }
        public Outcome Outcome
        {
            get; 
            private set;
        }
        public void Initialize()
        {
            Number = 3;
            Count = 0;
            Guess = null;
            Outcome = Outcome.Indefinite;
        }
        public Outcome MakeGuess(int number)
        {
            if (number < Number)
            {
                return Outcome.Low;
            }
            else if (number > Number)
            {
                return Outcome.High;
            }
            else
            {
                return Outcome.Right;
            }
        }
        public SecretNumber()
        {
            Initialize();
        }
    }
    public enum Outcome
    {
        Indefinite,
        Low,
        High,
        Right,
        NoMoreGuesses,
        OldGuess
    }
}
