using System;

namespace Login_Register_App
{
    class Program
    {
        static void Main(string[] args)
        {
            string[] userNames = new string[1] { "admn@admindomain.com" };
            string[] passWords = new string[1] { "Ad#mi8$s@a" };

            while (true)
            {
                Console.WriteLine("Please enter '1' to REGISTER or '2' for LOGIN!");
                string userInput = Console.ReadLine().Trim();
                //REGISTERING
                #region USER ENTERES 1 - REGISTRATION
                if (userInput == "1")
                {
                    //ENTERING USERNAME
                    Console.WriteLine("Please enter a username/email to register!");
                    string username = Console.ReadLine().Trim();
                    //USERNAME VALIDATION
                    if (username.ToLower().Contains("@") &&
                        username.ToLower().Contains(".") &&
                        username.Length <= 30 &&
                        !char.IsDigit(username[username.Length - 1]) &&
                        !char.IsDigit(username[0]) &&
                        char.IsLetterOrDigit(username[username.Length - 1]) &&
                        char.IsLetterOrDigit(username[0])
                        )
                    {
                        //adding username to the userNames Array
                        Array.Resize(ref userNames, userNames.Length + 1);
                        userNames[userNames.Length - 1] = username;
                        //ENTERING PASSWORD
                        Console.WriteLine("Please enter a password to register");
                        string password = Console.ReadLine().Trim();

                        char[] passwordArray = password.ToCharArray();
                        bool hasUpperCaseLetter = false;
                        bool hasLowerCaseLetter = false;
                        bool hasDigit = false;
                        char[] symbols = new char[] { };

                        foreach (var item in passwordArray)
                        {
                            if (char.IsUpper(item)) hasUpperCaseLetter = true;
                            if (char.IsLower(item)) hasLowerCaseLetter = true;
                            if (char.IsDigit(item)) hasDigit = true;
                            if (!char.IsLetterOrDigit(item))
                            {
                                Array.Resize(ref symbols, symbols.Length + 1);
                                symbols[symbols.Length - 1] = item;
                            }
                        }
                        //PASSWORD VALIDATION
                        if (hasUpperCaseLetter &&
                            hasLowerCaseLetter &&
                            hasDigit &&
                            password.Length >= 10 &&
                            symbols.Length >= 2
                            )
                        {
                            Console.WriteLine("You have successfuly registered!");
                            //adding password to passWords Array
                            Array.Resize(ref passWords, passWords.Length + 1);
                            passWords[passWords.Length - 1] = password;
                            continue;
                        }
                        else
                        {
                            Console.WriteLine("Invalid password format!");
                            continue;
                        }
                    }
                    else
                    {
                        Console.WriteLine("Invalid username/email format!");
                        continue;
                    }
                }
                #endregion
                //LOGING IN...
                #region USER ENTERES 2 - LOGIN
                else if (userInput == "2")
                {
                    for (int i = 1; i <= 3; i++)
                    {
                        Console.WriteLine("Please enter your username/email to login!");
                        string user = Console.ReadLine().Trim();
                        if (user == "logout")
                            continue;
                        if (user == "exit")
                            Environment.Exit(0);
                        bool doesItExist = Array.Exists(userNames, element => element == user);
                        int indexOfUser = Array.IndexOf(userNames, user);
                        //USER VALIDATION
                        if (
                            user.ToLower().Contains("@") &&
                            user.ToLower().Contains(".") &&
                            user.Length <= 30 &&
                            !char.IsDigit(user[user.Length - 1]) &&
                            !char.IsDigit(user[0]) &&
                            char.IsLetterOrDigit(user[user.Length - 1]) &&
                            char.IsLetterOrDigit(user[0])
                            )
                        {
                            Console.WriteLine("Please enter your password to login!");
                            string pass = Console.ReadLine().Trim();
                            char[] passArray = pass.ToCharArray();
                            bool hasUpperCase = false;
                            bool hasLowerCase = false;
                            bool hasDig = false;
                            int indexOfPass = Array.IndexOf(passWords, pass);
                            char[] symb = new char[] { };
                            foreach (var item in passArray)
                            {
                                if (char.IsUpper(item)) hasUpperCase = true;
                                if (char.IsLower(item)) hasLowerCase = true;
                                if (char.IsDigit(item)) hasDig = true;
                                if (!char.IsLetterOrDigit(item))
                                {
                                    Array.Resize(ref symb, symb.Length + 1);
                                    symb[symb.Length - 1] = item;
                                }
                            }
                            if (
                                //PASSWORD VALIDATION
                                hasUpperCase &&
                                hasLowerCase &&
                                hasDig &&
                                pass.Length >= 10 &&
                                symb.Length >= 2
                                )
                            {
                                if (//FINAL, MATCH-VALIDATION OF USERNAME AND PASSWORD
                                    //checking if username exists in userNames Array
                                    doesItExist &&
                                    //checking if password exist in passWord Array
                                    indexOfPass != -1 &&
                                    indexOfPass == indexOfUser
                                    )
                                {
                                    Console.WriteLine("Welcome! You have successfuly loged in!");
                                    if (user != userNames[0] || pass != passWords[0])
                                    {
                                        foreach (var item in userNames)
                                        {
                                            Console.WriteLine(item);
                                        }
                                        //Console.ReadLine();
                                        //break;
                                    }
                                    //IF ADMINISTRATOR LOGS IN
                                    else if (user == userNames[0] || pass == passWords[0])
                                    {
                                        Console.WriteLine("Please enter:\n1 --- List of all users\n2 --- Delete user");
                                        string listOrDelete = Console.ReadLine().Trim();
                                        if (listOrDelete == "1")
                                        {
                                            foreach (var item in userNames)
                                            {
                                                Console.WriteLine(item);
                                            }
                                        }
                                        else if (listOrDelete == "2")
                                        {
                                            Console.WriteLine("Enter user's e-mail address to delete the user!");
                                            string userToDelete = Console.ReadLine();
                                            int indexUser = Array.IndexOf(userNames, userToDelete);
                                            if (userToDelete == userNames[0])
                                            {
                                                Console.WriteLine("You can not delete the Administrator!!!");
                                                continue;
                                            }
                                            else if (indexUser != -1 && userToDelete != userNames[0])
                                            {
                                                //userNames[indexUser] = null;
                                                userNames = Array.FindAll(userNames, i => i != userToDelete);

                                                foreach (var item in userNames)
                                                {
                                                    Console.WriteLine(item);
                                                }
                                            }
                                        }
                                    }
                                }
                                else
                                //END POINT, go back to top 3 times, and then break outside the for
                                {
                                    Console.WriteLine("Invalid username/password!");
                                    continue;
                                }
                            }
                            else
                            {
                                Console.WriteLine("Invalid password format!");
                                //continue;
                            }
                        }
                        else
                        {
                            Console.WriteLine("Invalid user/email format!");
                            //continue;
                        }
                    } //FOR LOOP END
                    Console.WriteLine("You have entered inalid username and/or password 3 times! You will be blocked!");
                    Console.ReadLine();
                    break;
                }//IF 1 ELSE IF 2
                #endregion
                //USER ENTERS NEITHER 1 OR 2
                else
                {
                    Console.WriteLine("You entered invalid character!!!");
                    continue;
                }
            }
        }
    }
}
