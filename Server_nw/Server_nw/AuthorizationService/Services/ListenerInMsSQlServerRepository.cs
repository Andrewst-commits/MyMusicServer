using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Server_nw.AuthorizationApplication.Entities;
using Server_nw.AuthorizationService.DtoModels.CreateDto;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Server_nw.AuthorizationApplication.Services
{
    public class ListenerInMsSQlServerRepository
    {
        private const int NUMBER_OF_ROUNDS = 1000;
        private readonly AuthorizationDbContext _db;
        private readonly ILogger<ListenerInMsSQlServerRepository> _logger;

        public ListenerInMsSQlServerRepository(AuthorizationDbContext db,
            ILogger<ListenerInMsSQlServerRepository> logger)
        {
            _db = db;
            _logger = logger;
        }

        public async Task<List<Listener>> GetAllListeners()
        {
            await Task.CompletedTask;
            return _db.Listeners.Where(c => c.IsDeleted == false).ToList();
        }

        public async Task<Listener> GetListener(Guid id)
        {
            var listeners = await _db.Listeners.Include(c => c.Role).ToListAsync();

            var listener = listeners.FirstOrDefault(c => c.UserId == id && c.IsDeleted == false);

            if (listener == null) return null;

            return listener;
        }

        public async Task<Listener> CreateAccount(LoginModelCreateDto loginModel,
            ListenerCreateDto accountInf, Role role)
        {
            var newAccount = accountInf.ToEntity();

            var salt = GenerateSalt();
            var enteredPassHash = HashPassword(loginModel, salt);

            newAccount.Role = role;
            newAccount.LoginModel.Salt = Convert.ToBase64String(salt);
            newAccount.LoginModel.PasswordHash = Convert.ToBase64String(enteredPassHash);

            await _db.Users.AddAsync(newAccount);
            await _db.SaveChangesAsync();
            await _db.DisposeAsync();

            return newAccount;

        }

        public async Task<Listener> CreateListenerAccount(LoginModelCreateDto loginModelCreateDto,
            ListenerCreateDto accountCreateDto)
        {
            Role accountRole = await _db.Roles.FirstOrDefaultAsync(r => r.Name == "listener");
            var userAccountDto = await CreateAccount(loginModelCreateDto, accountCreateDto, accountRole);

            return userAccountDto;
        }

        //public async Task<bool> UpdateAccount(Guid id, AccountCreateDto accountCreateDto)
        //{
        //    var user = await _db.Users.FirstOrDefaultAsync(c => c.UserId == id);

        //    if (user == null) return false;

        //    user = await accountCreateDto.ToEntity();

        //    _db.Users.Update(user);
        //    await _db.SaveChangesAsync();
        //    await _db.DisposeAsync();

        //    return true;
        //}


        //public async Task<bool> DeleteUser(Guid id)
        //{
        //    var user = await _db.Users.FirstOrDefaultAsync(c => c.UserId == id);

        //    if (user == null) return false;

        //    user.IsDeleted = true;

        //    await _db.SaveChangesAsync();
        //    await _db.DisposeAsync();

        //    return true;
        //}

        //public async Task<List<Account>> GetAllDeletedUsers()
        //{
        //    await Task.CompletedTask;
        //    return _db.Users.Where(c => c.IsDeleted == true).ToList();
        //}

        //public async Task<bool> RestoreUser(Guid id)
        //{
        //    var user = await _db.Users.FirstOrDefaultAsync(u => u.UserId == id);

        //    if (user == null) return false;

        //    user.IsDeleted = false;

        //    await _db.SaveChangesAsync();
        //    await _db.DisposeAsync();

        //    return true;
        //}


        private static byte[] HashPassword(LoginModelCreateDto loginModelCreateDto, byte[] salt)
        {
            using var rfc2898DeriveBytes = new Rfc2898DeriveBytes(loginModelCreateDto.PasswordDto, salt, NUMBER_OF_ROUNDS);
            return rfc2898DeriveBytes.GetBytes(20);
        }

        private static byte[] GenerateSalt()
        {
            using var randomNumberGenerator = new RNGCryptoServiceProvider();
            var randomNumber = new byte[16];
            randomNumberGenerator.GetBytes(randomNumber);

            return randomNumber;
        }
    }
}
