using IdentityServer4.Test;
using System.Collections.Generic;
using System.Security.Claims;

namespace IdentityServerHost.Quickstart.UI
{
    /// <summary>
    /// Test Users class
    /// </summary>
    public class TestUsers
    {
        protected TestUsers()
        {

        }

        #region Public Methods        
        /// <summary>
        /// Gets the users.
        /// </summary>
        /// <value>
        /// The users.
        /// </value>
        public static List<TestUser> Users
        {
            get
            {
                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "d860efca-22d9-47fd-8249-791ba61b07c7",
                        Username = "Frank",
                        Password = "password",
                        Claims = new List<Claim>
                        {
                            new Claim("given_name", "Frank"),
                            new Claim("family_name", "Underwood"),
                            new Claim("address", "Main Road 1"),
                            new Claim("role", "Member")
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "b7539694-97e7-4dfe-84da-b4256e1ff5c7",
                        Username = "Claire",
                        Password = "password    ",
                        Claims = new List<Claim>
                        {
                            new Claim("given_name", "Claire"),
                            new Claim("family_name", "Underwood"),
                            new Claim("address", "Main Road 1"),
                            new Claim("role", "RegisteredUser")
                        }
                    }
                };
            }
        }
        #endregion Public Methods
    }
}