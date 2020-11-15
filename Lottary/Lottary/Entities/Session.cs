using LottoServices;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lottary.Entities
{
    public class Session
    {

        static int counter = 0;

        public Session()
        {
            counter += 1;
            SessionId = counter;
            WinningCombination = new int[7];
        }

        private int SessionId { get; set; }

        public Ticket[] TicketsWithoutWin { get; set; }

        public Ticket[] TicketsWithWin { get; set; }

        public int[] WinningCombination { get; set; } 

        public Ticket[] Tickets { get; set; }


        //METHOD
        public void StarSession()
        {
            WinningCombination = LottoNumbersGenerator.GenerateNumbers();
            //for testing:
            //foreach (var number in WinningCombination)
            //{
            //    Console.WriteLine(number);
            //}
        }



    }
}
