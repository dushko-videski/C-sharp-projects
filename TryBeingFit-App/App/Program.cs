using DomainLibrary.Entities;
using DomainLibrary.Enums;
using ServicesLibrary.Helpers;
using ServicesLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace App
{
    class Program
    {
        public static User currentUser;

        public static IUiService uiSrvc = new UiService();

        public static IUserService<StandardUser> standardUserSrvc = new UserService<StandardUser>();
        public static IUserService<PremiumUser> premiumUserSrvc = new UserService<PremiumUser>();
        public static IUserService<TrainerUser> trainerUserSrvc = new UserService<TrainerUser>();

        public static ITrainingService<VideoTraining> videoTrainings = new TrainingService<VideoTraining>();
        public static ITrainingService<LiveTraining> liveTrainings = new TrainingService<LiveTraining>();


        public static void PopulateDb()
        {

            if (standardUserSrvc.IsDbEmpty() && premiumUserSrvc.IsDbEmpty() && trainerUserSrvc.IsDbEmpty())
            {
                // USERS:
                standardUserSrvc.Register(new StandardUser() { FirstName = "Bob", LastName = "Bobsky", Username = "bobob1", Password = "bobbest1" });
                premiumUserSrvc.Register(new PremiumUser() { FirstName = "Jill", LastName = "Wayne", Username = "jilllw", Password = "jillsuper26" });
                TrainerUser John = new TrainerUser() { FirstName = "John", LastName = "Johnsky", Username = "johnjj", Password = "johny55", YearsOfExperiance = 7 };
                trainerUserSrvc.Register(John);
                // VIDEO TRAININGS:
                videoTrainings.AddTraining(new VideoTraining() { Title = "30 min workout", Description = "Cool workout for beginners and intermediate users", Difficulty = Difficulty.Medium, Link = "https://www.youtube.com/watch?v=50kH47ZztHs", Rating = 4, Time = 35 });
                videoTrainings.AddTraining(new VideoTraining() { Title = "Standing ABS workout", Description = "Abs workout for people at home with standing and no equipment required", Difficulty = Difficulty.Easy, Link = "https://www.youtube.com/watch?v=Qia2ZXEzyLw", Rating = 5, Time = 11 });
                videoTrainings.AddTraining(new VideoTraining() { Title = "Full AGILITY Bodyweight", Description = "An intense workout for people that have experience working out and need a good AGILITY training", Difficulty = Difficulty.Hard, Link = "https://www.youtube.com/watch?v=tveIjnSG_8s", Rating = 2, Time = 67 });
                // LIVE TRAININGS:
                liveTrainings.AddTraining(new LiveTraining() { Title = "Workout with John", Description = "Working out can be easy when you are at home. Trust John, he is a professional!", Difficulty = Difficulty.Medium, NextSession = new DateTime(2020, 07, 20), Trainer = John, Rating = 2, Time = 25 });
                liveTrainings.AddTraining(new LiveTraining() { Title = "Quick abs with John", Description = "You want abs for the summer? You want them quick? This is the training for you!", Difficulty = Difficulty.Hard, NextSession = new DateTime(2020, 07, 24), Trainer = John, Rating = 4, Time = 40 });
            }
        }

        static void Main(string[] args)
        {
            PopulateDb();

            while (true)
            {
                if (currentUser == null)
                {
                    // I) prvo da izbere dali saka da se LOGIRA ili REGISTRIRA
                    //#####################################################
                    //Enter a number to choose one of the following:
                    // 1) Log In
                    // 2) Register
                    int userChoice = uiSrvc.LogInMenu();

                    //ako odbral da se logira LOGIN
                    //______________________________
                    if (userChoice == 1)
                    {
                        //treba da izbere vo koja uloga ke se logira
                        int userRoleChoice = uiSrvc.RoleMenu();
                        UserRole role = (UserRole)userRoleChoice;
                        Console.Clear();

                        //da vnese username i password za da se logira
                        Console.WriteLine("Enter username:");
                        string username = Console.ReadLine();
                        Console.WriteLine("Enter password:");
                        string password = Console.ReadLine();

                        //zavisno vo koja uloga da se kreira soodvete CURRENT USER
                        switch (role)
                        {
                            case UserRole.Standard:
                                currentUser = standardUserSrvc.LogIn(username, password);
                                break;
                            case UserRole.Premium:
                                currentUser = premiumUserSrvc.LogIn(username, password);
                                break;
                            case UserRole.Trainer:
                                currentUser = trainerUserSrvc.LogIn(username, password);
                                break;
                        }
                        if (currentUser == null)
                            continue;
                    }
                    //ako izbral 2 i odlucil da se registrira (SAMO KAKO STANDARD USER) REGISTER
                    //_________________________________________________
                    else
                    {
                        StandardUser newUser = new StandardUser();

                        Console.WriteLine("Enter first name:");
                        newUser.FirstName = Console.ReadLine();
                        Console.WriteLine("Enter last name:");
                        newUser.LastName = Console.ReadLine();
                        Console.WriteLine("Enter username:");
                        newUser.Username = Console.ReadLine();
                        Console.WriteLine("Enter password:");
                        newUser.Password = Console.ReadLine();

                        User user = standardUserSrvc.Register(newUser);
                        if (user == null)
                            continue;
                        currentUser = user;
                    }
                    //odkoga ke se logira ili registrira, mu se pojavuva WELCOME MESSAGE
                    uiSrvc.Welcome(currentUser);
                }
                // II) se otvara MAIN MENU, zavisno od ulogata koja ja ima CURRENT USER-ot i mu se pojavuva izborot od: 
                //#################################################################################################
                // 1) Account, 
                // 2) Log out, 
                // 3) Train, 
                // 4) Upgrade to premium ili 
                // 5) Reschedule training
                //#####################################################
                int mainManuUserChoice = uiSrvc.MainMenu(currentUser.Role);
                string mainManuUserChoiceStr = uiSrvc.MainMenuItems[mainManuUserChoice - 1];

                switch (mainManuUserChoiceStr)
                {
                    case "Account":
                        // mu se otvara sledniov izbor 
                        // 1) Change Info, 
                        // 2) Check Subscription, 
                        // 3) Change password
                        int accountUserChoice = uiSrvc.AccountMenu(currentUser.Role);
                        Console.Clear();
                        // Change Info
                        if (accountUserChoice == 1)
                        {
                            Console.WriteLine("Enter new first name:");
                            string newFirstName = Console.ReadLine();
                            Console.WriteLine("Enter new last name:");
                            string newLastName = Console.ReadLine();

                            switch (currentUser.Role)
                            {
                                case UserRole.Standard:
                                    standardUserSrvc.ChangeInfo(currentUser.Id, newFirstName, newLastName);
                                    break;
                                case UserRole.Premium:
                                    premiumUserSrvc.ChangeInfo(currentUser.Id, newFirstName, newLastName);
                                    break;
                                case UserRole.Trainer:
                                    trainerUserSrvc.ChangeInfo(currentUser.Id, newFirstName, newLastName);
                                    break;
                            }
                        }
                        // Check Subscription
                        else if (accountUserChoice == 2)
                        {
                            Console.WriteLine($"Your subscription is {currentUser.Role}");
                            Console.ReadLine();
                        }
                        // Change password
                        else
                        {
                            Console.WriteLine("Enter old password");
                            string oldPassword = Console.ReadLine();
                            Console.WriteLine("Enter new password");
                            string newPassword = Console.ReadLine();
                            switch (currentUser.Role)
                            {
                                case UserRole.Standard:
                                    standardUserSrvc.ChangePassword(currentUser.Id, oldPassword, newPassword);
                                    break;
                                case UserRole.Premium:
                                    premiumUserSrvc.ChangePassword(currentUser.Id, oldPassword, newPassword);
                                    break;
                                case UserRole.Trainer:
                                    trainerUserSrvc.ChangePassword(currentUser.Id, oldPassword, newPassword);
                                    break;
                            }
                        }
                        break;
                    case "Log Out":
                        currentUser = null;
                        break;
                    case "Train":
                        //mu se pojavuva menito so izbor:
                        // 1) Video
                        // 2) Live
                        int userTrainingsChoice = 1;
                        if (currentUser.Role == UserRole.Premium)
                        {
                            userTrainingsChoice = uiSrvc.TrainingsMenu();
                        }
                        // -Video trainings:
                        if (userTrainingsChoice == 1)
                        {
                            int videoTreiningItem = uiSrvc.TrainingMenuItems(videoTrainings.GetAllTrainings());
                            VideoTraining videoTraining = videoTrainings.GetAllTrainings()[videoTreiningItem - 1];
                            Console.WriteLine(videoTraining.Title);
                            Console.WriteLine($"Link: {videoTraining.Link}");
                            Console.WriteLine($"Rating: {videoTraining.CheckRating()}");
                            Console.WriteLine($"Time: {videoTraining.Time} minutes.");
                            Console.ReadLine();
                        }
                        // -Live trainings:
                        if (userTrainingsChoice == 2)
                        {
                            int liveTrainingItem = uiSrvc.TrainingMenuItems(liveTrainings.GetAllTrainings());
                            LiveTraining liveTraining = liveTrainings.GetAllTrainings()[liveTrainingItem - 1];
                            Console.WriteLine(liveTraining.Title);
                            Console.WriteLine($"The training starts at: {liveTraining.NextSession}");
                            Console.WriteLine($"Rating: {liveTraining.Rating}");
                            Console.WriteLine($"Time: {liveTraining.Time} minutes.");
                            Console.ReadLine();
                        }
                        break;
                    case "Upgrade to premium":
                        uiSrvc.UpgradeToPremium();
                        break;
                    case "Reschedule training":
                        List<LiveTraining> trainings = liveTrainings.GetAllTrainings().Where(x => x.Trainer.Id == currentUser.Id).ToList();

                        if (trainings.Count == 0)
                        {
                            Console.WriteLine("No trainings!");
                            Console.ReadLine();
                        }
                        else
                        {
                            int userLiveTrainingChoice = uiSrvc.ChooseEntitiesMenu(trainings);
                            Console.WriteLine("How many days wpuld you like to reschedule the training?");
                            int days = ValidationHelper.ValidateNumber(Console.ReadLine(), 100);
                            trainerUserSrvc.GetUserById(currentUser.Id).ChangeSchedule(trainings[userLiveTrainingChoice], days);
                            Console.WriteLine("Schedule changed!");
                            Console.ReadLine();
                        }
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
