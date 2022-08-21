using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MovieRecommendationApp.Business.Exceptions
{
    public class UserCreateFailedException : Exception
    {
        //duruma göre hangisini istersem.
        public UserCreateFailedException() : base(" Failed to register..!")
        {
        }

        public UserCreateFailedException(string? message) : base(message)
        {
        }
        
        public UserCreateFailedException(string? message, Exception? innerException) : base(message, innerException)
        {
        }
    }
}
