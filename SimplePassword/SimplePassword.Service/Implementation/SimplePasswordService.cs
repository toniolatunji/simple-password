using SimplePassword.Service.Contract;
using SimplePassword.Service.DataTransferObjects;
using System.Linq;

namespace SimplePassword.Service.Implementation
{
    public class SimplePasswordService : ISimplePasswordService
    {
        public SimplePasswordResponseDto SimplePassword(string password)
        {
            if (!password.Any(char.IsUpper))
            {
                return new SimplePasswordResponseDto { IsValid = false, Error = "Password must have a capital letter" };
            }

            if (!password.Any(char.IsDigit))
            {
                return new SimplePasswordResponseDto { IsValid = false, Error = "Password must contain at least one number" };
            }

            if (!password.Any(char.IsPunctuation) && !password.Any(char.IsSymbol))
            {
                return new SimplePasswordResponseDto { IsValid = false, Error = "Password must contain a punctuation mark or mathematical symbol" };
            }

            if (password.ToLower().Contains("password"))
            {
                return new SimplePasswordResponseDto { IsValid = false, Error = "Password cannot have the word \"password\" in the string" };
            }

            if (password.Length <= 7 || password.Length >= 31)
            {
                return new SimplePasswordResponseDto { IsValid = false, Error = "Password must be longer than 7 characters and shorter than 31 characters" };
            }

            return new SimplePasswordResponseDto { IsValid = true, Error = string.Empty };
        }
    }
}
