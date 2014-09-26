using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1C
{
    public class SecretNumber
    {
        //GuessedNumber[] _guessedNumbers;    

        private GuessedNumber[] _guessedNumbers = new GuessedNumber[7] { new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), };
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
            CanMakeGuess = true;
            Count = 0;
            Guess = null;
            Outcome = Outcome.Indefinite;

            Random random = new Random();
            Number = random.Next(1,100);
        }
        public Outcome MakeGuess(int number)
        {
            Guess = number;
            Count += 1;

            if (Guess < _number)
            {
                Outcome = Outcome.Low;
                return Outcome.Low;
            }
            else if (Guess > _number)
            {
                Outcome = Outcome.High;
                return Outcome.High;
            }
            else if (Guess == _number)
            {
                Outcome = Outcome.Right;
                CanMakeGuess = false;
                return Outcome.Right;
            }
            if (Count == MaxNumberOfGuesses)
            {
                Outcome = Outcome.NoMoreGuesses;
                Number = _number;
                return Outcome.NoMoreGuesses;
            }
            else
            {
                for (int i = 0; i < _guessedNumbers.Length; i++)
                {
                    if (_guessedNumbers[i].Number == number)
                    {
                        Outcome = Outcome.OldGuess;
                        return Outcome.OldGuess;
                    }
                }
                return Outcome.OldGuess;
            }
        }
        public SecretNumber()
        {
            for (int i = 0; i < 7; i++)
            {
                GuessedNumber[] GuessedNumbers = new GuessedNumber[7] { new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), };
            }
            Outcome = new Outcome();
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
