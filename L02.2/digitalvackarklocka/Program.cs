using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digitalvackarklocka
{
    class Program
    {
        const string HorizontalLine = "———————————————";
        static void Main(string[] args)
        {
            ViewTestHeader("Test 1.\nDefault Konstruktor");
            AlarmClock ac = new AlarmClock();
            Console.WriteLine(ac.ToString());
            Console.WriteLine();

            ViewTestHeader("Test 2.\nKonstruktor med 2 parametrar");
            AlarmClock ac1 = new AlarmClock(9,42);
            Console.WriteLine(ac1.ToString());
            Console.WriteLine();

            ViewTestHeader("Test 3.\nKonstruktor med 4 parametrar");
            AlarmClock ac3 = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(ac3.ToString());
            Console.WriteLine();

            ViewTestHeader("Test 4.\nKonstruktor med variablet parametrar []");
            AlarmClock ac4 = new AlarmClock("7:07", "7:10", "7:15", "7:30");
            Console.WriteLine(ac4.ToString());
            Console.WriteLine();

            ViewTestHeader("Test 5.\nTestar TickTock()");
            AlarmClock ac5 = new AlarmClock("23:58", "7:10", "7:15", "7:30");
            Run(ac5, 13);
            Console.WriteLine();

            ViewTestHeader("Test 6.\nTickTock med Alarm");
            AlarmClock ac6 = new AlarmClock(6, 12, 6, 15);
            Run(ac6, 6);
            Console.WriteLine();

            ViewTestHeader("Test 7.\nTest på fel värde");
            AlarmClock ac7 = new AlarmClock(12, 13, 14, 15);
            try
            {
                ac7.Time = "24:89";
            }
            catch(ArgumentException ex)
            {
                ViewErrorMessage(String.Format("Stängen '{0}' kan inte tolkas som en tid på formatet HH:mm.", ex.Message));
            }
            catch (FormatException ex)
            {
                ViewErrorMessage(String.Format("Stängen '{0}' kan inte tolkas som en tid på formatet HH:mm.", ex.Message));
            }
            try
            {
                string[] str = new string[] {"7:69"};
                ac7.AlarmTimes = str;
            }
            catch (ArgumentException ex)
            {
                ViewErrorMessage(String.Format("Stängen '{0}' kan inte tolkas som en tid på formatet HH:mm.", ex.Message));
            }
            catch(FormatException ex)
            {
                ViewErrorMessage(String.Format("Stängen '{0}' kan inte tolkas som en tid på formatet HH:mm.", ex.Message));
            }
            Console.WriteLine();
            
            ViewTestHeader("Test 8.\nTest kontruktor om fel");
            try
            {
                AlarmClock ac8 = new AlarmClock(32, 03, 27, 00);
            }
            catch (FormatException ex)
            {
                ViewErrorMessage(String.Format("Stängen '{0}' kan inte tolkas som en tid på formatet HH:mm.", ex.Message));
            }
            try
            {
                AlarmClock ac8 = new AlarmClock(0, 0, 27, 00);
            }
            catch (FormatException ex)
            {
                ViewErrorMessage(String.Format("Stängen '{0}' kan inte tolkas som en tid på formatet HH:mm.", ex.Message));
            }
            Console.WriteLine();
        }

        private static void Run(AlarmClock ac, int minute)
        {
            Console.WriteLine();
            Console.BackgroundColor = ConsoleColor.DarkRed;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(" {0}{1}{2}", (char)0x2554,AddChar((char)0x2550,32),(char)0x2557);
            Console.WriteLine(" {0}   Pro Extrem Keep Time Delux{1}  {2}", (char)0x2551, (char)0x00A9, (char)0x2551);
            Console.Write(" {0}      ", (char)0x2551);
            Console.ForegroundColor = ConsoleColor.Gray;
            Console.Write("Modellnr.: 1337420BLZ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("     {0}", (char)0x2551);
            Console.WriteLine(" {0}{1}{2}", (char)0x255A,AddChar((char)0x2550,32),(char)0x255D);
            Console.ResetColor();

            bool flag = false;
            for (int i = 0; i < minute; i++)
            {
                ac.TickTock();
                for (int j = 0; j < ac.AlarmTimes.Length; j++ )
                {
                    if (ac.Time == ac.AlarmTimes[j])
                    {
                        flag = true; ;
                    }
                }
                if(flag)
                {
                    Console.BackgroundColor = ConsoleColor.DarkBlue;
                    Console.Write(" {0}  ", (char)14);
                    Console.Write(ac.ToString());
                    Console.WriteLine("  BEEP! BEEP! BEEP!");
                    Console.ResetColor();
                }
                else
                {
                    Console.Write("    ");
                    Console.WriteLine(ac.ToString());
                }
                flag = false;
                Console.ResetColor();
            }
        }
        private static string AddChar(char c, int number)
        {
            string str = "";
            for(int i = 0; i < number; i++)
            {
                str += c;
            }
            return str;
        }
        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        private static void ViewTestHeader(string header)
        {
            Console.WriteLine(HorizontalLine);
            Console.WriteLine(header);
        }
    }
}
