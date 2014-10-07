using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1C
{
    public class SecretNumber
    {
        private GuessedNumber[] _guessedNumbers = new GuessedNumber[7] { new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber() };
        private int? _number;
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
            get             
            {
                GuessedNumber[] copyArray = new GuessedNumber[7] { new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber() };
                copyArray = _guessedNumbers;

                return copyArray;
            }
        }
        public int? Number
        {            
            get 
            { 
                if(CanMakeGuess)
                {
                    return null;
                }
                else
                {
                    return _number;
                }
            }
            private set { _number = value; }
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
            Number = null;
            Outcome = Outcome.Indefinite;

            Random random = new Random();
            _number = random.Next(1,100);
        }
        public Outcome MakeGuess(int number)
        {
            Guess = number;
            Count += 1;

            if (Guess < 1 || Guess > 100)
            { 
                throw new ArgumentOutOfRangeException();
            }


            if (Count > MaxNumberOfGuesses)
            {
                Outcome = Outcome.NoMoreGuesses;
                Number = _number;
                CanMakeGuess = false;
                Count = 7;
                return Outcome;
            }
            for (int i = 0; i < Count - 1; i++)
            {
                if (GuessedNumbers[i].Number == Guess)
                {
                    Outcome = Outcome.OldGuess;
                    Count -= 1;
                    return Outcome;
                }
            }

            if (Guess < _number)
            {
                if (Count == MaxNumberOfGuesses)
                {
                    Outcome = Outcome.NoMoreGuesses;
                    Number = _number;
                    CanMakeGuess = false;
                    return Outcome;
                }
                Outcome = Outcome.Low;
                GuessedNumbers[Count - 1].Number = Guess;
                GuessedNumbers[Count - 1].Outcome = Outcome;
                return Outcome.Low;
            }
            else if (Guess > _number)
            {
                if (Count == MaxNumberOfGuesses)
                {
                    Outcome = Outcome.NoMoreGuesses;
                    Number = _number;
                    CanMakeGuess = false;
                    return Outcome;
                }
                Outcome = Outcome.High;
                GuessedNumbers[Count - 1].Number = Guess;
                GuessedNumbers[Count - 1].Outcome = Outcome;
                return Outcome;
            }
            else
            {
                Outcome = Outcome.Right;
                GuessedNumbers[Count - 1].Number = Guess;
                GuessedNumbers[Count - 1].Outcome = Outcome;
                CanMakeGuess = false;
                return Outcome;
            }

        }
        public SecretNumber()
        {
            Outcome = new Outcome();
            for (int i = 0; i < 7; i++)
            {
                GuessedNumber[] GuessedNumbers = new GuessedNumber[7] { new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber() };
            }
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
