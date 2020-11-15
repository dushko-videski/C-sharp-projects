namespace ServicesLibrary.Helpers
{
    public static class ValidationHelper
    {

        // 1)---VALIDATE NUMBER---
        public static int ValidateNumber(string number, int range)
        {
            bool isNumber = int.TryParse(number, out int num);
            if (!isNumber)
                return -1;
            if (num <= 0 || num > range)
                return -1;

            return num;
        }

        // 2) ---VALIDATE FIRST NAME / LAST NAME----
        public static string ValidateFirstLastName(string str)
        {
            str = str.Trim();

            if (str.Length < 2)
                return null;

            bool hasNumber = false;

            foreach (char character in str)
            {
                if (int.TryParse(character.ToString(), out int number))
                    hasNumber = true;
            }
            if (hasNumber)
                return null;

            return str;
        }

        // 3) -------------VALIDATE USERNAME----------------
        public static string ValidateUsername(string username)
        {
            username = username.Trim();

            if (username.Length < 6)
                return null;

            return username;
        }

        // 4) -------------VALIDATE PASSWORD-----------------
        public static string ValidatePassword(string password)
        {
            password = password.Trim();

            if (password.Length < 6)
                return null;

            bool hasNumber = false;

            foreach (char character in password)
            {
                if (int.TryParse(character.ToString(), out int number))
                    hasNumber = true;
            }
            if (!hasNumber)
                return null;

            return password;
        }
    }
}
