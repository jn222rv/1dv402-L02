using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text;
using System.Text.RegularExpressions;

namespace digitalvackarklocka
{
    public class ClockDisplay
    {
        private NumberDisplay _minuteDisplay;
        private NumberDisplay _hourDisplay;

        public string Time
        {
            get 
            { 
                return ToString(); 
            }
            set
            {
                Regex regex = new Regex("^(([0-1]?[0-9])|([2][0-3])):([0-5][0-9])$");
                if (regex.IsMatch(value))
                {
                    string[] words = value.Split(':');
                    _hourDisplay = new NumberDisplay(23,int.Parse(words[0]));
                    _minuteDisplay = new NumberDisplay(59,int.Parse(words[1]));
                }
                else
                {
                    throw new FormatException(value);
                }
            }
        }

        public ClockDisplay() : this(0, 0)
        { 
        
        }

        public ClockDisplay(int hour, int minute)
        {
            if (minute < 10)
            {
                Time = String.Format("{0}:0{1}", hour, minute);
            }
            else
            {
                Time = String.Format("{0}:{1}", hour, minute);
            }
        }

        public ClockDisplay(string time)
        {
            Time = time;
        }
                
        public override bool Equals(object obj)
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
            _minuteDisplay.Increment();
            if(_minuteDisplay.Number == 0)
            {
                _hourDisplay.Increment();
            }
        }

        public override string ToString()
        {
            return String.Format("{0}:{1}", _hourDisplay.ToString("0"), _minuteDisplay.ToString("00"));
        }

        public static bool operator ==(ClockDisplay a, ClockDisplay b)
        {
            if(a.Equals(b))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        public static bool operator !=(ClockDisplay a, ClockDisplay b)
        {
            if(a.Equals(b))
            {
                return false;
            }
            else
            {
                return true;
            }
        }

    }
}
