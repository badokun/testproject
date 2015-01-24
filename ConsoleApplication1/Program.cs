using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ConsoleApplication1
{
    class Program
    {
        static void Main(string[] args)
        {
            var currentTime = DateTime.ParseExact("07:19", "HH:mm", null);

            var t = new Timing();
            t.BusStart = DateTime.ParseExact("07:25", "HH:mm", null);
            t.Calculate();

            var t2 = new Timing();
            t2.BusStart = DateTime.ParseExact("07:38", "HH:mm", null);
            t2.Calculate();

            for (int i = 0; i < 100; ++i)
            {
                if (t.StartWalk > currentTime)
                {
                    Console.Write("\rCurrent Time: {0} ETA: {1}", (t.StartWalk - currentTime).ToString(), t.EndWalk.ToString("HH:mm"));
                }
                else
                {
                    Console.Write("\rCurrent Time: {0} ETA: {1}", (t2.StartWalk - currentTime).ToString(), t2.EndWalk.ToString("HH:mm"));
                
                }
                currentTime = currentTime.AddSeconds(10);
                Thread.Sleep(1000);
            }
        }
    }

    public class Timing
    {
        public void Calculate()
        {
            TrainStart = GoogleToDetermineRouteStart(MiddleWalkEnd);
            TrainEnd = GoogleToDetermineRouteEnd(MiddleWalkEnd);
        }

        private DateTime GoogleToDetermineRouteEnd(DateTime MiddleWalk)
        {
            return TrainEnd = TrainStart.AddMinutes(50);
        }

        private DateTime GoogleToDetermineRouteStart(DateTime MiddleWalk)
        {
            return MiddleWalkEnd.AddMinutes(1);
        }

        public DateTime StartWalk
        {
            get
            {
                return BusStart.AddMinutes(StartWalkMinute * -1);
            }
        }
        private int StartWalkMinute = 5;
        public DateTime BusStart;
        public DateTime BusStop
        {
            get
            {
                return BusStart.AddMinutes(busDuration);
            }
        }
        public DateTime MiddleWalkEnd
        {
            get
            {
                return BusStop.AddMinutes(MiddleWalkMinute);
            }
        }

        private const int MiddleWalkMinute = 5;

        public DateTime TrainStart
        {
            get;
            private set;
        }
        public DateTime TrainEnd
        {
            get;
            private set;
        }
        public DateTime EndWalk
        {
            get
            {
                return TrainEnd.AddMinutes(EndWalkMinute);
            }
        }

        private int EndWalkMinute = 5;
        private int busDuration = 10;
    }
}
