using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalvackarklocka
{
    public class NumberDisplay
    {
        private int _maxNumber;
        private int _number;

        public int MaxNumber
        {
            get { return _maxNumber; }
            set 
            {
                if (value > 0)
                {
                    _maxNumber = value;
                }
                else
                {
                    throw new ArgumentException(String.Format("{0}",value));
                }
            }
        }

        public int Number
        {
            get { return _number; }
            set
            {
                if (value >= 0 && value <= MaxNumber)
                {
                    _number = value;
                }
                else
                {
                    throw new ArgumentException(String.Format("{0}", value));
                }
            }
        }
        public override bool Equals (object obj)
        {
            if(this.ToString() == obj.ToString())
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    
        public override int GetHashCode()
        {
            string str = ToString();
            int i = str.GetHashCode();
            return i;
        }

        public void Increment()
        {
            if(Number + 1 > MaxNumber)
            {
                Number = 0;
            }
            else
            {
                Number++;
            }
        }
        
        public NumberDisplay(int maxNumber) : this(maxNumber, 0)
        {

        }

        public NumberDisplay(int maxNumber, int number)
        {
            MaxNumber = maxNumber;
            Number = number;
        }

        public override string ToString()
        {
            return String.Format("{0}",Number);
        }

        public string ToString(string format)
        {
            if (format == "0" || format == "G")
            {
                return String.Format("{0}", Number);
            }
            else if(format == "00")
            {
                if (Number < 10)
                {
                    return String.Format("0{0}",Number);
                }
                else
                {
                    return String.Format("{0}", Number);
                }
            }
            else
            {
                throw new FormatException();
            }
        }
    }
}
