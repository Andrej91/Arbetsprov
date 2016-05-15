using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MessageApplication
{
    class Program
    {
        static string _typeagain = "";
        static string _input = "";

        static void Main(string[] args)
        {
            Console.WriteLine("##### WELCOME #####\n");
            EnterMessage();
        }


        /// <summary>
        /// Handles the users message
        /// </summary>
        private static void EnterMessage()
        {
            Console.WriteLine("Type a Message");
            _input = Console.ReadLine();

            while (true)
            {
                if (!string.IsNullOrWhiteSpace(_input))
                {
                    break;
                }

                if (string.IsNullOrWhiteSpace(_input))
                {
                    Console.WriteLine("You must write something!");
                    _input = Console.ReadLine();
                }
            }

            if (SaveToDb())
            {
                EnterAgain();
            }
            EnterMessage();
        }


        /// <summary>
        /// Ask´s the user if he/she wants to enter a new message
        /// </summary>
        private static void EnterAgain()
        {
            Console.WriteLine("Would you like to enter a new message? y/n");
            _typeagain = Console.ReadLine().ToLower();

            while (_typeagain != "n")
            {
                if (_typeagain != "y" && _typeagain != "n")
                {
                    Console.WriteLine("\nYou must choose y or n");
                    _typeagain = Console.ReadLine().ToLower();
                }

                if (_typeagain == "y")
                {
                    Console.Clear();
                    EnterMessage();
                }
            }
            Environment.Exit(0);
        }


        /// <summary>
        /// Saves the message into the database
        /// </summary>
        private static bool SaveToDb()
        {
            try
            {
                using (MessageDatabaseEntities db = new MessageDatabaseEntities())
                {
                    var newMessage = new Messages()
                    {
                        message = _input,
                        time = DateTime.Now.ToString("yyyy-MM-dd HH:mm")
                    };

                    db.Messages.Add(newMessage);
                    db.SaveChanges();
                }
                Console.Clear();
                Console.WriteLine("Message stored into database");
                return true;
            }
            catch (Exception ex)
            {
                Console.Clear();
                Console.WriteLine("Something went wrong!\n" + ex.Message + "\nPress enter to contiue");
                Console.ReadKey();
                Console.Clear();
                return false;
            }

        }
    }
}

