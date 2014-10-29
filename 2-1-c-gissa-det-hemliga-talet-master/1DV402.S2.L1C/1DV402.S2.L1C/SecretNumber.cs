using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1DV402.S2.L1C
{
    public class SecretNumber
    {
        private GuessedNumber[] _guessedNumbers;
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
                return _guessedNumbers.ToArray();
            }
        }
        public int? Number
        {            
            get 
            {
                return CanMakeGuess ? null : _number;
            }
            private set 
            { 
                _number = value;
            }
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

            for (int i = 0; i < _guessedNumbers.Length; i++)
            {
                _guessedNumbers[i].Number = 0;
                _guessedNumbers[i].Outcome = Outcome.Indefinite;
            }
            
            Random random = new Random();
            _number = random.Next(1, 101);
        }
        public Outcome MakeGuess(int number)
        {
            Guess = number;
            Count += 1;

            if (Guess < 1 || Guess > 100)
            { 
                throw new ArgumentOutOfRangeException();
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

            if (Count > MaxNumberOfGuesses)
            {
                Outcome = Outcome.NoMoreGuesses;
                Number = _number;
                CanMakeGuess = false;
                Count = 7;
                return Outcome;
            }
            
            if (Guess < _number)
            {
                if (Count == MaxNumberOfGuesses)
                {
                    Outcome = Outcome.NoMoreGuesses;
                    Number = _number;
                    CanMakeGuess = false;
                    Count = 7;
                    return Outcome;
                }
                Outcome = Outcome.Low;
                _guessedNumbers[Count - 1].Number = Guess;
                _guessedNumbers[Count - 1].Outcome = Outcome;
                return Outcome;
            }
            else if (Guess > _number)
            {
                if (Count == MaxNumberOfGuesses)
                {
                    Outcome = Outcome.NoMoreGuesses;
                    Number = _number;
                    CanMakeGuess = false;
                    Count = 7;
                    return Outcome;
                }
                Outcome = Outcome.High;
                _guessedNumbers[Count - 1].Number = Guess;
                _guessedNumbers[Count - 1].Outcome = Outcome;
                return Outcome;
            }
            else
            {
                Outcome = Outcome.Right;
                _guessedNumbers[Count - 1].Number = Guess;
                _guessedNumbers[Count - 1].Outcome = Outcome;
                CanMakeGuess = false;
                return Outcome;
            }

        }
        public SecretNumber()
        {
            Outcome = new Outcome();
            _guessedNumbers = new GuessedNumber[7] { new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber(), new GuessedNumber() };
          
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
