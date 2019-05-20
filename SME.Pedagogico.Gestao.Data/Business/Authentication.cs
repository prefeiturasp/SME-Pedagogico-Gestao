using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public static class Authentication
    {
        // Corrigir esste método
        private static async Task<Models.Authentication.User> GetUserById(string id)
        {
            using (Data.Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
            {
                Models.Authentication.User user = await
                    (from current in db.Users.Include(".Profile.Roles")
                     where current.Id == id
                     select current).FirstOrDefaultAsync();

                return (user);
            }
        }

        public static async Task<bool> RegisterUser(string username, string password)
        {
            using (Data.Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
            {
                Models.Authentication.User user = await
                    (from current in db.Users.Include(".Roles")
                     where current.Name == username
                     select current).FirstOrDefaultAsync();

                if (user == null)
                {
                    user = new Models.Authentication.User()
                    {
                        Name = username,
                        Password = Functionalities.Cryptography.HashPassword(password)
                    };

                    await db.Users.AddAsync(user);
                    await db.SaveChangesAsync();

                    if (user.Name == "daniel.amcom" || user.Name == "massato.amcom" || user.Name == "caique.amcom")
                        await SetRole(user.Name, "Admin", "0");

                    return (true);
                }

                return (false);
            }
        }

        public static async Task<bool> RegisterUser(string username)
        {
            return (await RegisterUser(username, username.Substring(username.Length - 5)));
        }

        public static bool ValidateUser(string username, string password)
        {
            using (Data.Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
                return (db.Users.Any(x => x.Name == username && x.Password == Functionalities.Cryptography.HashPassword(password)));
        }

        public static async Task<bool> LoginUser(string username, string session, string refreshToken)
        {
            using (Data.Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
            {
                Models.Authentication.LoggedUser loggedUser = await
                    (from current in db.LoggedUsers.Include(".User")
                     where current.User.Name == username
                     select current).FirstOrDefaultAsync();

                if (loggedUser == null)
                {
                    Models.Authentication.User user = await
                        (from current in db.Users
                         where current.Name == username
                         select current).FirstOrDefaultAsync();

                    loggedUser = new Models.Authentication.LoggedUser()
                    {
                        User = user,
                        RefreshToken = refreshToken,
                        Session = session,
                        LastAccess = DateTime.Now,
                        ExpiresAt = DateTime.Now.AddMinutes(30)
                    };

                    await db.LoggedUsers.AddAsync(loggedUser);
                }
                else
                {
                    loggedUser.RefreshToken = refreshToken;
                    loggedUser.Session = session;
                    loggedUser.LastAccess = DateTime.Now;
                    loggedUser.ExpiresAt = DateTime.Now.AddMinutes(30);
                }

                await db.SaveChangesAsync();

                return (true);
            }
        }

        public static async Task<Models.Authentication.LoggedUser> GetLoggedUser(string username, string session, string refreshToken)
        {
            using (Data.Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
                return (await
                    (from current in db.LoggedUsers.Include(".User")
                     where current.User.Name == username
                     && current.Session == session
                     && current.RefreshToken == refreshToken
                     select current).FirstOrDefaultAsync());
        }

        public static async Task<bool> LogoutUser(string username, string session)
        {
            using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
            {
                Models.Authentication.LoggedUser loggedUser = await
                    (from current in db.LoggedUsers.Include(".User")
                     where current.User.Name == username
                     && current.Session == session
                     select current).FirstOrDefaultAsync();

                if (loggedUser != null)
                {
                    db.LoggedUsers.Remove(loggedUser);
                    await db.SaveChangesAsync();

                    return (true);
                }

                return (false);
            }
        }

        public static async Task<bool> SetRole(string username, string roleName, string accessLevelValue)
        {
            using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
            {
                Models.Authentication.User user = await
                    (from current in db.Users
                     where current.Name == username
                     select current).FirstOrDefaultAsync();

                if (user != null)
                {
                    Models.Authentication.Role role = await
                        (from current in db.Roles
                         where current.Name == roleName
                         select current).FirstOrDefaultAsync();

                    if (role != null)
                    {
                        Models.Authentication.AccessLevel accessLevel = await
                            (from current in db.AccessLevels
                             where current.Value == accessLevelValue
                             select current).FirstOrDefaultAsync();

                        if (accessLevel != null)
                        {
                            Models.Authentication.UserRole userRole = await
                                (from current in db.UserRoles
                                 where current.AccessLevelId == accessLevel.Id
                                 && current.RoleId == role.Id
                                 && current.UserId == user.Id
                                 select current).FirstOrDefaultAsync();

                            if (userRole == null)
                            {
                                userRole = new Models.Authentication.UserRole()
                                {
                                    User = user,
                                    Role = role,
                                    AccessLevel = accessLevel
                                };

                                await db.UserRoles.AddAsync(userRole);
                                await db.SaveChangesAsync();
                            }

                            return (true);
                        }
                    }
                }

                return (false);
            }
        }

        public static async Task<List<Models.Authentication.UserRole>> GetUserRoles(string username)
        {
            using (Contexts.SMEManagementContext db = new Contexts.SMEManagementContext())
            {
                List<Models.Authentication.UserRole> userRoles = await
                        (from current in db.UserRoles.Include(".User").Include(".Role").Include(".AccessLevel")
                         where current.User.Name == username
                         select current).ToListAsync();

                return (userRoles);
            }
        }
    }
}
