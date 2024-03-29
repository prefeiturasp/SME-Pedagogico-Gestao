﻿using Microsoft.EntityFrameworkCore;
using MoreLinq.Extensions;
using SME.Pedagogico.Gestao.Data.Contexts;
using SME.Pedagogico.Gestao.Data.DataTransfer;
using SME.Pedagogico.Gestao.Data.DTO;
using SME.Pedagogico.Gestao.Data.Integracao;
using SME.Pedagogico.Gestao.Infra;
using SME.Pedagogico.Gestao.Models.Authentication;
using SME.Pedagogico.Gestao.WebApp.Models.Auth;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Cryptography = SME.Pedagogico.Gestao.Data.Functionalities.Cryptography;

namespace SME.Pedagogico.Gestao.Data.Business
{
    public static class Authentication
    {
        // Corrigir esste método
        private static async Task<Models.Authentication.User> GetUserById(string id)
        {
            using (Data.Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
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
            using (Data.Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
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
            using (SMEManagementContextData db = new SMEManagementContextData())
                return (db.Users.Any(x => x.Name == username && x.Password == Cryptography.HashPassword(password)));
        }

        public static bool ValidateUser(string username)
        {
            try
            {
                using (SMEManagementContextData db = new SMEManagementContextData())
                    return (db.Users.Any(x => x.Name == username));
            }
            catch (Exception ex)
            {
                throw ex;
            }
            
        }

        public static async Task SetPrivilegedAccess(string login, IEnumerable<PrivilegedAccess> lista)
        {
            using (SMEManagementContextData db = new SMEManagementContextData())
            {
                var listaBanco = db.PrivilegedAccess.Where(x => x.Login.Equals(login));

                var listaDeletar = listaBanco.Where(x => !lista.Any(y => y.OccupationPlaceCode == x.OccupationPlaceCode));

                var listaAdicionar = lista.Where(x => !listaBanco.Any(y => y.OccupationPlaceCode == x.OccupationPlaceCode));

                if (!listaDeletar.Any() && !listaAdicionar.Any())
                    return;

                if (listaDeletar.Any())
                {
                    foreach (var deletar in listaDeletar)
                    {
                        db.PrivilegedAccess.Remove(deletar);
                    }
                }

                if (listaAdicionar.Any())
                {
                    foreach (var adicionar in listaAdicionar)
                    {
                        db.PrivilegedAccess.Add(adicionar);
                    }
                }

                await db.SaveChangesAsync();
            }
        }

        public static PrivilegedAccessModel ValidatePrivilegedUser(string username)
        {
            using (Data.Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                var user = db.PrivilegedAccess.Where(x => x.Login == username).FirstOrDefault();

                if (user != null)
                {
                    var userPrivileged = new PrivilegedAccessModel()
                    {
                        Login = user.Login,
                        Name = user.Name,
                        OccupationPlace = user.OccupationPlace,
                        OccupationPlaceCode = user.OccupationPlaceCode,
                    };

                    return userPrivileged;
                }

                return null;
            }
        }

        public static async Task<bool> ResetSenha(string username, string newPassword)
        {
            using (Data.Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                Models.Authentication.User user = await
                    (from current in db.Users
                     where current.Name == username
                     select current).FirstOrDefaultAsync();

                if (user != null)
                {
                    user.Password = Functionalities.Cryptography.HashPassword(newPassword);
                    await db.SaveChangesAsync();

                    return (true);
                }
            }

            return (false);
        }


        public static bool ResetSenhaPadrão(ResetPasswordDTO credentials, out IEnumerable<string> validationErrors)
        {
            using (Data.Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                User user =
                    (from current in db.Users
                     where current.Name == credentials.Username
                     select current).FirstOrDefault();

                validationErrors = default;

                if (user != null)
                {
                    validationErrors = ValidatePassword(credentials, user);

                    if (validationErrors.Count() < 1)
                    {
                        user.Password = Cryptography.HashPassword(credentials.NewPassword);

                        return db.SaveChanges() > 0;
                    }
                }

                return false;
            }
        }

        private static IEnumerable<string> ValidatePassword(ResetPasswordDTO credentials, User user)
        {
            var oldPasswordHash = Cryptography.HashPassword(credentials.OldPassword);
            var anyUpperCaseLetterPattern = @"[A-Z]+";
            var anyDigitPattern = @"\d+";
            var anySpecialCharactertPattern = @"[^a-zA-Z0-9]";

            if (oldPasswordHash != user.Password)
            {
                yield return PasswordValidationMsgsEnum.WRONG_OLD_PASSWORD.Text;
            }

            if (credentials.NewPassword != credentials.NewPasswordRepeat)
            {
                yield return PasswordValidationMsgsEnum.PASSWORDS_CONFIRMATION_DIFF.Text;
            }

            if (credentials.NewPassword.Length < 8 || !(Regex.IsMatch(credentials.NewPassword, anyUpperCaseLetterPattern) &&
                                                        Regex.IsMatch(credentials.NewPassword, anyDigitPattern) &&
                                                        Regex.IsMatch(credentials.NewPassword, anySpecialCharactertPattern)))
            {
                yield return PasswordValidationMsgsEnum.PASSWORD_INSUFFICIENT_COMPLEXITY.Text;
            }

            yield break;
        }

        public static async Task<bool> LoginUser(string username, string session, string refreshToken, DateTime expiresAt)
        {
            using (SMEManagementContextData db = new SMEManagementContextData())
            {
                LoggedUser loggedUser = await
                    (from current in db.LoggedUsers.Include(".User")
                     where current.User.Name == username
                     select current).FirstOrDefaultAsync();

                if (loggedUser == null)
                {
                    User user = await
                        (from current in db.Users
                         where current.Name == username
                         select current).FirstOrDefaultAsync();

                    loggedUser = new LoggedUser()
                    {
                        User = user,
                        RefreshToken = refreshToken,
                        Session = session,
                        LastAccess = DateTime.Now,
                        ExpiresAt = expiresAt
                    };

                    await db.LoggedUsers.AddAsync(loggedUser);
                }
                else
                {
                    loggedUser.RefreshToken = refreshToken;
                    loggedUser.Session = session;
                    loggedUser.LastAccess = DateTime.Now;
                    loggedUser.ExpiresAt = expiresAt;
                }

                await db.SaveChangesAsync();

                return true;
            }
        }

        public static async Task<LoggedUser> GetLoggedUser(string userName)
        {
            using (SMEManagementContextData db = new SMEManagementContextData())
            {
                var currentUser = await (from current in db.LoggedUsers.Include(".User")
                                         where current.User.Name.Equals(userName.Trim())
                                         select current).LastOrDefaultAsync();

                if (DateTime.Now > currentUser.ExpiresAt || DateTime.Now.Day > currentUser.ExpiresAt.Day)
                {
                    var retornoRevalidacao = await new NovoSGPAPI().RevalidarAutenticacao(currentUser.RefreshToken);
                    await LoginUser(userName, currentUser.Session, retornoRevalidacao.Token, retornoRevalidacao.DataHoraExpiracao);
                    return await GetLoggedUser(userName);
                }

                return currentUser;
            }
        }

        public static async Task<bool> LogoutUser(string username, string session)
        {
            using (SMEManagementContextData db = new SMEManagementContextData())
            {
                LoggedUser loggedUser = await
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

        public static async Task setRoleAuthentication(string userName, IEnumerable<RoleAuthenticationDto> roles)
        {
            var listaBanco = await GetUserRoles(userName);

            var listaAdicionar = roles.Where(role => !listaBanco.Any(banco => banco.Role.Name.Equals(role.RoleName) && banco.PerfilId != null));

            var listaRemover = listaBanco.Where(banco => banco.PerfilId == null || !roles.Any(role => banco.Role.Name.Equals(role.RoleName)));

            if (!listaAdicionar.Any() && !listaRemover.Any())
                return;

            if (listaRemover.Any())
                foreach (var remover in listaRemover)
                    await DeleteRole(remover);

            if (listaAdicionar.Any())
                foreach (var adicionar in listaAdicionar)
                    await SetRole(adicionar.UserName, adicionar.RoleName, adicionar.AccessLevelValue, adicionar.Perfil);            
        }

        public static async Task DeleteRole(UserRole role)
        {
            using (SMEManagementContextData db = new SMEManagementContextData())
            {
                db.UserRoles.Remove(role);
                await db.SaveChangesAsync();
            }
        }

        public static async Task<bool> SetRole(string username, string roleName, string accessLevelValue, Guid perfil)
        {
            using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                var user = await
                    (from current in db.Users
                     where current.Name.Equals(username)
                     select current).FirstOrDefaultAsync();

                if (user == null)
                    return false;

                var role = await
                         (from current in db.Roles
                          where current.Name.Equals(roleName)
                          select current).FirstOrDefaultAsync();

                if (role == null)
                    return false;

                var accessLevel = await
                            (from current in db.AccessLevels
                             where current.Value.Equals(accessLevelValue)
                             select current).FirstOrDefaultAsync();

                if (accessLevel == null)
                    return false;

                var userRole = await
                        (from current in db.UserRoles
                         where current.AccessLevelId.Equals(accessLevel.Id)
                         && current.RoleId.Equals(role.Id)
                         && current.UserId.Equals(user.Id)
                         && current.PerfilId.Equals(perfil)
                         select current).FirstOrDefaultAsync();

                if (userRole != null)
                    return true;

                userRole = new Models.Authentication.UserRole()
                {
                    User = user,
                    Role = role,
                    AccessLevel = accessLevel,
                    PerfilId = perfil
                };

                await db.UserRoles.AddAsync(userRole);
                await db.SaveChangesAsync();

                return true;
            }
        }

        public static async Task<UserRole> GetUserRoleById(string id)
        {
            using (var db = new Contexts.SMEManagementContextData())
            {
                return await db.UserRoles.FirstOrDefaultAsync(x => x.Id.ToUpper().Equals(id.ToUpper()));
            }
        }

        public static async Task<List<Models.Authentication.UserRole>> GetUserRoles(string username)
        {
            using (Contexts.SMEManagementContextData db = new Contexts.SMEManagementContextData())
            {
                List<Models.Authentication.UserRole> userRoles = await
                        (from current in db.UserRoles.Include(".User").Include(".Role").Include(".AccessLevel")
                         where current.User.Name == username
                         select current).ToListAsync();

                return (userRoles);
            }
        }

        public static async Task SetRolePrivilegied(CredentialModel credential, Data.DataTransfer.PrivilegedAccessModel userPrivileged)
        {
            if (userPrivileged.OccupationPlace == "AMCOM")
            {
                var boolean = await SetRole(credential.Username, "Admin", "0", new Guid("5be1e074-37d6-e911-abd6-f81654fe895d"));
            }
            else if (userPrivileged.OccupationPlace == "SME")
            {
                var boolean = await SetRole(credential.Username, "Admin", "2", new Guid("5ae1e074-37d6-e911-abd6-f81654fe895d"));
            }
            else if (userPrivileged.OccupationPlaceCode == 3)
            {
                await SetRole(credential.Username, "Adm DRE", "21", new Guid("48e1e074-37d6-e911-abd6-f81654fe895d"));
            }
        }


    }
}