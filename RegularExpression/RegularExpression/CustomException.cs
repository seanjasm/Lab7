using System;
using System.Collections.Generic;
using System.Text;

namespace CustomException
{
    class InvalidNameFormatException : Exception
    {
        public string Message { get; private set; }

        public InvalidNameFormatException()
        {
            Message = "Name should begin with a capital letter, and have 30 letters max!";
        }

        public InvalidNameFormatException(string message)
        {
            Message = message;
        }
    }

    class InvalidEmailFormatException : Exception
    {
        public string Message { get; private set; }

        public InvalidEmailFormatException()
        {
            Message = "The email address format is not valid";
        }

        public InvalidEmailFormatException(string message)
        {
            Message = message;
        }
    }

    class InvalidPhoneFormatException : Exception
    {
        public string Message { get; private set; }

        public InvalidPhoneFormatException()
        {
            Message = "Enter the phone number in this format with the dashes: 555-555-5555";
        }

        public InvalidPhoneFormatException(string message)
        {
            Message = message;
        }
    }

    class InvalidHtmlElementFormatException : Exception
    {
        public string Message { get; private set; }

        public InvalidHtmlElementFormatException()
        {
            Message = "Invalid html element format. Use format <p></p>";
        }

        public InvalidHtmlElementFormatException(string message)
        {
            Message = message;
        }
    }

    class InvalidDateFormatException : Exception
    {
        public string Message { get; private set; }

        public InvalidDateFormatException()
        {
            Message = "Invalid date. Enter the date in format mm/dd/yyyy";
        }

        public InvalidDateFormatException(string message)
        {
            Message = message;
        }
    }
}
