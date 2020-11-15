using Lottary.Entities;
using System;
using Lottary.Helpers;
using Lottary.Enums;


namespace Lottary
{
    class Program
    {
        static void Main(string[] args)
        {
            //Create structure
            //Create modles

            var user = new User()
            {
                FullName = "Igor Dzambazov"
            };

            user.SetAge(55);

            var ticket = new Ticket()
            {
                Combination = new int[] { 1, 2, 3, 4, 5, 6, 7 },
                User = user
            };

            var firstSesion = new FirstSession()
            {
                Tickets = new Ticket[] { }
            };

            firstSesion.StarSession();
            var matches = LottaryHelpers.CheckTicket(firstSesion.WinningCombination, ticket.Combination);
            
            switch (matches)
            {
                case (int)Prize.TV:
                    Console.WriteLine(Prize.TV);
                    break;
                case 5:
                    Console.WriteLine(Prize.Vacation);
                    break;
                default:
                    break;
            };



            //firstSesion.GetRandomTicket();




            Console.ReadLine();

        }
    }
}
