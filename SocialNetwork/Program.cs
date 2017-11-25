using System;
using System.Linq;

namespace SocialNetwork
{
    public class Program
    {
        public static void Main(string[] parametres)
        {
            TextMethod();
        }

        private static void TextMethod()
        {
            using (var db = new EntityFrameworkDbContext())
            {
                var user = db.Users.First(name => name.NickName == "Marcello");

                    foreach (var friend in user.RequestedFriendships)
                    {
                        Console.WriteLine(user == friend.User1 ? friend.User2.NickName : friend.User1.NickName);
                    }
                    Console.WriteLine("_____________________________________________________");
                    foreach (var friend in user.AcceptedFriendships)
                    {
                        Console.WriteLine(user == friend.User1 ? friend.User2.NickName : friend.User1.NickName);
                    }
            }
        }
    }
}