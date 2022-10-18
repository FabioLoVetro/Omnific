using System.Runtime.CompilerServices;
using System;
using Microsoft.EntityFrameworkCore;

namespace Omnific.Model
{
    /// <summary>
    /// Rapresents a log for an user
    /// </summary>
    public class Log
    {
        public int Id { get; set; }
        public int IdUser { get; set; }
        public DateTime DateTimeIn { get; set; }
        public DateTime DateTimeOut { get; set; }
        public bool IsLoggedIn { get; set; }
        /// <summary>
        /// Constructor
        /// </summary>
        /// <param name="idUser"></param>
        /// <param name="dateTimeIn"></param>
        /// <param name="dateTimeOut"></param>
        /// <param name="isLoggedIn"></param>
        public Log(int idUser, DateTime dateTimeIn, DateTime dateTimeOut, bool isLoggedIn)
        {
            IdUser = idUser;
            DateTimeIn = dateTimeIn;
            DateTimeOut = dateTimeOut;
            IsLoggedIn = isLoggedIn;
        }
    }
}