using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using TeamFlowWeb.DTOs;
using TeamFlowWeb.Models;

namespace TeamFlowWeb.Services
{
    public class UserService : IUserService
    {
        private readonly UserStore _userStore;
        private readonly IPasswordHasher<User> _passwordHasher;
        public UserService(UserStore userStore, IPasswordHasher<User> passwordHasher)
        {
            _userStore = userStore;
            _passwordHasher = passwordHasher;
        }
        public User RegisterUserService(User user, string password)
        {
            var existingUser = _userStore.Users.FirstOrDefault(u => u.Email.Equals(user.Email, StringComparison.OrdinalIgnoreCase));
            if(existingUser != null)
            {
                return null;
            } 
            user.Id = _userStore.NextId;
            user.PasswordHash = _passwordHasher.HashPassword(user, password);
            Console.WriteLine("password", user.PasswordHash);
            _userStore.Users.Add(user);
            _userStore.NextId++;
            return user;
        }
        public User Login(string email, string password)
        {
            var user = _userStore.Users.FirstOrDefault(u => u.Email.Equals(email, StringComparison.OrdinalIgnoreCase));
            if(user == null)
            {
                return null;
            }
            var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, password);
            if(result == PasswordVerificationResult.Failed)
            {
                return null;
            }
            return user;
        }
    }
}
