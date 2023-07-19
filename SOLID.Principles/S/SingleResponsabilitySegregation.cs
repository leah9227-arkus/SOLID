using System;
using System.Collections.Generic;
using System.Text;

namespace SOLID.Principles.S
{
    /// <summary>
    /// Single responsability segregation.
    /// </summary>
    public class SingleResponsabilitySegregation
    {
        public interface IUserRepository
        {
            public void RegisterUser(string username, string password);
        }

        public class UserRepositoryPrincipleBroken : IUserRepository
        {
            public void RegisterUser(string username, string password)
            {
                // open connection to database
                var connection = "Connection to database";

                // hash the password
                var arrayData = Encoding.ASCII.GetBytes(password);
                var passwordHashed = Convert.ToBase64String(arrayData);

                // save to database
                connection = "save to database";
            }
        }

        class UserRepositoryPrincipleOk : IUserRepository
        {
            public void RegisterUser(string username, string password)
            {
                // open connection to database
                var connection = "Connection to database";

                // hash the password
                var passwordHashed = PasswordHasher.HashPassword(password);

                // save to database
                connection = "save to database";
            }

            // Single resposability (fully testable)
            public class PasswordHasher
            {
                /// <summary>
                /// Converts the password into 64 base string.
                /// </summary>
                /// <param name="password"></param>
                /// <returns></returns>
                public static string HashPassword(string password)
                {
                    var arrayData = Encoding.ASCII.GetBytes(password);
                    var passwordHashed = Convert.ToBase64String(arrayData);

                    return passwordHashed;
                }
            }
        }
    }
}
