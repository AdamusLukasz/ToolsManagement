using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToolsManagement.Data.Context;
using ToolsManagement.Data.Entities;
using ToolsManagement.Models;

namespace ToolsManagement.Services
{
    public interface IAccountService
    {
        void RegisterUser(RegisterUserDto dto);
    }

    public class AccountService : IAccountService
    {
        private readonly ToolsManagementDbContext _context;
        private readonly IPasswordHasher<User> _passwordHasher;

        public AccountService(ToolsManagementDbContext context, IPasswordHasher<User> passwordHasher)
        {
            _context = context;
            _passwordHasher = passwordHasher;
        }
        public void RegisterUser(RegisterUserDto dto)
        {
            var newUser = new User()
            {
                FirstName = dto.FirstName,
                LastName = dto.LastName,
                RoleId = dto.RoleId
            };

            var hashedPassword = _passwordHasher.HashPassword(newUser, dto.Password);

            newUser.PasswordHash = hashedPassword;
            _context.Users.Add(newUser);
            _context.SaveChanges();
        }
    }
}
