using System;

namespace RegularExpression
{
    class Program
    {
        static void Main(string[] args)
        {
            bool _continue = true;
            string name, phone, email, date, htmlElement;

            date = name = phone = email = htmlElement = string.Empty;
            
            while (_continue)
            {
                try
                {
                    if (name == string.Empty)
                    {
                        name = UserInput.UserInput.GetUserInput("Enter a name: ");

                        if (UserInput.UserInput.IsValidUserInput(name, UserInput.UserInput.inputType.name))
                        {
                            UserInput.UserInput.Display($"{name} is valid!");
                        }
                    }
                    if (email == string.Empty)
                    {
                        email = UserInput.UserInput.GetUserInput("Enter an email address: ");

                        if (UserInput.UserInput.IsValidUserInput(email, UserInput.UserInput.inputType.email))
                        {
                            UserInput.UserInput.Display($"{email} is valid!");
                        }
                    }

                    if (phone == string.Empty)
                    {
                        phone = UserInput.UserInput.GetUserInput("Enter a phone(555-555-5555): ");

                        if (UserInput.UserInput.IsValidUserInput(phone, UserInput.UserInput.inputType.phone))
                        {
                            UserInput.UserInput.Display($"{phone} is valid!");
                        }
                    }

                    if (date == string.Empty)
                    {
                        date = UserInput.UserInput.GetUserInput("Enter a date(mm/dd/yyyy): ");

                        if (UserInput.UserInput.IsValidUserInput(date, UserInput.UserInput.inputType.date))
                        {
                            UserInput.UserInput.Display($"{date} is valid!");
                        }
                    }

                    if (htmlElement == string.Empty)
                    {
                        htmlElement = UserInput.UserInput.GetUserInput("Enter a html element: ");

                        if (UserInput.UserInput.IsValidUserInput(htmlElement, UserInput.UserInput.inputType.htmlElement))
                        {
                            UserInput.UserInput.Display($"{htmlElement} is valid!");
                        }
                    }
                }
                catch (CustomException.InvalidHtmlElementFormatException e)
                {
                    UserInput.UserInput.Display(e.Message);
                    htmlElement = string.Empty;
                }
                catch (CustomException.InvalidDateFormatException e)
                {
                    UserInput.UserInput.Display(e.Message);
                    date = string.Empty;
                }
                catch (CustomException.InvalidEmailFormatException e)
                {
                    UserInput.UserInput.Display(e.Message);
                    email = string.Empty;
                }
                catch (CustomException.InvalidPhoneFormatException e)
                {
                    UserInput.UserInput.Display(e.Message);
                    phone = string.Empty;
                }
                catch (CustomException.InvalidNameFormatException e)
                {
                    UserInput.UserInput.Display(e.Message);
                    name = string.Empty;
                }

                _continue = UserInput.UserInput.UserConfirmationPrompt("Continue?(Y/N) ");
            }//end while

        }
    }
}
