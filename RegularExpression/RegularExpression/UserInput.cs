using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace UserInput
{
    class UserInput
    {
        public enum inputType { phone = 2, name = 4, email = 6, date = 8, htmlElement = 10 }
        private const string phonePattern = @"\d{3}-\d{3}-\d{4}";
        private const string datePattern = @"\d{2}/\d{2}/\d{4}$";
        private const string namePattern = @"^[A-Z]([a-z]){0,29}$";
        private const string emailPattern = @"([A-Za-z0-9]){5,30}@[A-Za-z0-9]{5,10}\.[a-zA-Z0-9]{2,3}";
        private const string htmlElementPattern = @"^[<][a-z]{1}[0-9]{0,1}[>]{1}[a-z\s0-9;\-\.]*" +
                                                   @"(<\/)[a-z]{1}[0-9]{0,1}[>]{1}";
        
        /// <summary>
        /// Gets and return console input
        /// </summary>
        /// <param name="message"></param>
        /// <returns>string</returns>
        public static string GetUserInput(string message)
        {
            Display(message);
            string input = Console.ReadLine();

            //Requires an input from user
            if(input == string.Empty)
            {
                return GetUserInput(message);
            }
            return input;
        }
       
        /// <summary>
        /// Displays a message
        /// </summary>
        /// <param name="message"></param>
        public static void Display(string message)
        {
            Console.Write("\n\n" + message);
        }

        /// <summary>
        /// Return true if user input equals trueOption. trueOption set to "Y" by default.  
        /// </summary>
        /// <param name="message"></param>  
        public static bool UserConfirmationPrompt(string message, string trueOption="Y", string falseOption="N") 
        {
            
            string input = UserInput.GetUserInput(message);
            
            if(new Regex($"{trueOption}", RegexOptions.IgnoreCase).IsMatch(input))
            {
                return true;
            }

            if (new Regex($"{falseOption}", RegexOptions.IgnoreCase).IsMatch(input))
            {
                return false;
            }
            else
            {
                return UserConfirmationPrompt(message);
            }
        }


        public static bool IsValidUserInput(string input, UserInput.inputType inputType)
        {
            switch (inputType)
            {
                case inputType.htmlElement:

                    if (Regex.IsMatch(input, htmlElementPattern))
                    {
                        return true;
                    }
                    else
                    {
                        throw new CustomException.InvalidHtmlElementFormatException();
                    }


                case inputType.date:

                    if (Regex.IsMatch(input, datePattern))
                    {
                        return true;
                    }
                    else
                    {
                        throw new CustomException.InvalidDateFormatException();
                    }

                case inputType.email:

                    if (Regex.IsMatch(input, emailPattern))
                    {
                        return true;
                    }
                    else
                    {
                        throw new CustomException.InvalidEmailFormatException();
                    }
                case inputType.name:

                    Regex regex = new Regex(@"\b([A-Z][a-z]{1,29})\b");
                    
                        if(regex.IsMatch(input))
                        {
                            throw new CustomException.InvalidNameFormatException();
                        }

                    return true;

                case inputType.phone:

                    if (Regex.IsMatch(input, phonePattern))
                    {
                        return true;
                    }
                    else
                    {
                        throw new CustomException.InvalidPhoneFormatException();
                    }

                default:

                    return false;
            }
        }

    }
}
