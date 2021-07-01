using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Server.Context;
using Server.Entities;
using Server.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Server.Services
{
    public class AccountsRepository : IAccounts
    {
        private readonly MusicServerDbContext _db;
        private readonly ILogger<AccountsRepository> _logger;

        public AccountsRepository(MusicServerDbContext db,
            ILogger<AccountsRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<Account>> GetAllUser()
        {
            await Task.CompletedTask;
            return _db.Users.Where(c => c.IsDeleted == false).ToList();
        }

        public async Task<Account> GetUser()
        {
            var users = await _db.Users.Include(c => c.Role).ToListAsync();

            var user = users.FirstOrDefault(c => c.UserId == id && c.IsDeleted == false);

            if (user == null) return null;

            return user;
        }

        public async Task<AccountDto> CreateAccount(LoginModel loginModelCreateDto, 
            AccountCreateDto accountCreateDto, Role accountRole)
        {
            var newAccount = await accountCreateDto.ToEntity();

            if (accountRole != null) newAccount.Role = accountRole;

            await _db.Users.AddAsync(newAccount);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return new AccountDto(newAccount);

        }

        public async Task<AccountDto> CreateUserAccount(LoginModel loginModelCreateDto, 
            AccountCreateDto accountCreateDto)
        {
            Role accountRole = await _db.Roles.FirstOrDefaultAsync(r => r.Name == "user");
            var userAccountDto = await CreateAccount(loginModelCreateDto, accountCreateDto, accountRole);

            return userAccountDto;
        }

        public async Task<AccountDto> CreateAdminAccount(LoginModel loginModelCreateDto, 
            AccountCreateDto accountCreateDto)
        {
            Role accountRole = await _db.Roles.FirstOrDefaultAsync(r => r.Name == "admin");
            var adminAccountDto = await CreateAccount(loginModelCreateDto, accountCreateDto, accountRole);

            return adminAccountDto;
        }


        public async Task<bool> UpdateAccount(Guid id, AccountCreateDto accountCreateDto)
        {
            var user = await _db.Users.FirstOrDefaultAsync(c => c.UserId == id);

            if (user == null) return false;

            user = await accountCreateDto.ToEntity();

            _db.Users.Update(user);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }


        public async Task<bool> DeleteUser(Guid id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(c => c.UserId == id);

            if (user == null) return false;

            user.IsDeleted = true;

            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }

        public async Task<List<Account>> GetAllDeletedUsers()
        {
            await Task.CompletedTask;
            return _db.Users.Where(c => c.IsDeleted == true).ToList();
        }

        public async Task<bool> RestoreUser(Guid id)
        {
            var user = await _db.Users.FirstOrDefaultAsync(u => u.UserId == id);

            if (user == null) return false;

            user.IsDeleted = false;

            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return true;
        }
    }
}
