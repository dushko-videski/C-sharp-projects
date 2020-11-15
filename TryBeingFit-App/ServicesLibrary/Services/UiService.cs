using DomainLibrary.Entities;
using DomainLibrary.Enums;
using ServicesLibrary.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ServicesLibrary.Services
{
    public class UiService : IUiService
    {
        //SERVIS KOJ GI POKAZUVA MENIATA NA USERTO VO KOSOLA OD KOI TOJ TREBA DA IZBIRA SO PRITISKANJE NA SOODVETNATA BROJKA PRED PONUDENIOT IZBOT

        public List<string> MainMenuItems { get; set; }
        public List<string> AccountMenuItems { get; set; }

        //-----------------CHOOSE MENU--------------------
        public int ChooseMenu<T>(List<T> items)
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter a number to choose one of the following:");
                for (int i = 0; i < items.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {items[i]}");
                }
                int userChoice = ValidationHelper.ValidateNumber(Console.ReadLine(), items.Count);
                if (userChoice == -1)
                {
                    MessageHelper.Color("[ERROR] Incoret input! Please try again!", ConsoleColor.Red);
                    continue;
                }
                return userChoice;
            }
        }
        //---------------------Choose Entities Menu------------
        public int ChooseEntitiesMenu<T>(List<T> entities) where T : IBaseEntity
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter a number to choose one of the following:");
                for (int i = 0; i < entities.Count; i++)
                {
                    Console.WriteLine($"{i + 1}) {entities[i].Info()}"); //razlikata so prethodniot metod e samo vo .Info()
                }
                int userChoice = ValidationHelper.ValidateNumber(Console.ReadLine(), entities.Count);
                if (userChoice == -1)
                {
                    MessageHelper.Color("[ERROR] Incoret input! Please try again!", ConsoleColor.Red);
                    continue;
                }
                return userChoice;
            }
        }
        //-------------------LOG IN / REGISTER MENU------------------
        public int LogInMenu()
        {
            List<string> logInRegisterMenu = new List<string>() { "Log In", "Register" };
            return ChooseMenu(logInRegisterMenu);
        }
        //---------------------ROLE MENU---------------------------
        public int RoleMenu()
        {
            List<string> rolesMenu = Enum.GetNames(typeof(UserRole)).ToList();
            return ChooseMenu(rolesMenu);
        }

        //----------------MAIN MENU (USER'S MENU)---------------------
        public int MainMenu(UserRole role)
        {
            MainMenuItems = new List<string>() { "Account", "Log Out" };

            switch (role)
            {
                case UserRole.Standard:
                    MainMenuItems.Insert(0, "Train");
                    MainMenuItems.Insert(0, "Upgrade to premium");
                    break;
                case UserRole.Premium:
                    MainMenuItems.Insert(0, "Train");
                    break;
                case UserRole.Trainer:
                    MainMenuItems.Insert(0, "Reschedule training");
                    break;
            }
            return ChooseMenu(MainMenuItems);
        }
        //-------------------ACCOUNT MENU------------------------------
        public int AccountMenu(UserRole role)
        {
            AccountMenuItems = new List<string>() { "Change Info", "Check Subscription", "Change password" };
            return ChooseMenu(AccountMenuItems);
        }
        //--------------TRAININGS MENU-----------------------------------
        public int TrainingsMenu()
        {
            Console.Clear();
            List<string> trainingsMenu = new List<string>() { "Video", "Live" };
            Console.WriteLine("Choose what type of training you want:");
            return ChooseMenu(trainingsMenu);
        }
        //--------------------TRAINING MENU ITEMS--------------------------
        public int TrainingMenuItems<T>(List<T> trainings) where T : Training
        {
            Console.Clear();
            Console.WriteLine("Choose a training:");
            return ChooseEntitiesMenu(trainings);
        }
        //------------------UPGRADE TO PREMIUM-----------------------------
        public void UpgradeToPremium()
        {
            Console.Clear();
            Console.WriteLine("Upgrade to premium to get these features:");
            Console.WriteLine("* Live trainings");
            Console.WriteLine("* Newsletter in your mail");
            Console.WriteLine("* Discounts at sports equipment stores");
            Console.ReadLine();
        }
        //--------------------------WELCOME MESSAGE----------------------
        public void Welcome(User user)
        {
            Console.Clear();
            Console.WriteLine($"Welcome to the fitness app {user.Username}");

            switch (user.Role)
            {
                case UserRole.Standard:
                    Console.WriteLine("If you enjoy the app, consider our Premium subscription!");
                    break;
                case UserRole.Premium:
                    Console.WriteLine("We are so glad you are part of our community!");
                    break;
                case UserRole.Trainer:
                    Console.WriteLine("We are so glad to have you as a partner!");
                    break;
            }
            Console.ReadLine();
        }

    }
}
