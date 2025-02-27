using System;

namespace mybookapp
{
    /// <summary>
    /// main program that starts the book manager service
    /// </summary>
    public class Program
    {
        /// <summary>
        /// entry point of the app
        /// </summary>
        public static void Main(string[] args)
        {
            Bookmanagerservice service = new Bookmanagerservice();
            service.start();
        }
    }
}
