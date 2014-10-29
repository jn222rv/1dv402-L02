using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalvackarklocka
{
    class AlarmClock
    {
        private ClockDisplay[] _alarmTimes;
        private ClockDisplay _time;

        public string[] AlarmTimes
        {
            get 
            {
                string[] arr = new String[_alarmTimes.Length];
                for(int i = 0; i < _alarmTimes.Length; i++)
                {
                     arr[i] = _alarmTimes[i].ToString();
                }
                return arr;
            }
            set 
            {
                _alarmTimes = new ClockDisplay[value.Length];
                for(int i = 0; i < value.Length; i++)
                {
                    string[] str = value[i].Split(':');
                    _alarmTimes[i] = new ClockDisplay(int.Parse(str[0]),int.Parse(str[1]));
                }
            }
        }
        public string Time
        {
            get { return _time.ToString();}
            set { _time.Time = value;}
        }

        public AlarmClock() : this(0, 0)
        {

        }

        public AlarmClock(int hour, int minute) : this(hour, minute, 0, 0)
        {

        }

        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            _time = new ClockDisplay(hour, minute);

            string[] alarm = new String[] {String.Format("{0}:{1}",alarmHour,alarmMinute) };
            AlarmTimes = alarm;
        }

        public AlarmClock(string time, params string[] alarmTimes)
        {
            string[] str = time.Split(':');
            _time = new ClockDisplay(int.Parse(str[0]), int.Parse(str[1]));
            AlarmTimes = alarmTimes;
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

        public bool TickTock()
        {           
            _time.Increment();
            return true;
        }
        public override string ToString()
        {
            string str1 = Time;
            string str2 = "";

            for(int i = 0; i < AlarmTimes.Length; i++)
            {
                if (i < AlarmTimes.Length - 1)
                {
                    str2 += String.Format("{0}, ", AlarmTimes[i]);
                }
                else
                {
                    str2 += String.Format("{0}", AlarmTimes[i]);
                }

            }
            return String.Format("{0} ({1})",str1, str2);
        }
        
        public static bool operator ==(AlarmClock a, AlarmClock b)
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
        
        public static bool operator !=(AlarmClock a, AlarmClock b)
        {
            if (a.Equals(b))
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
