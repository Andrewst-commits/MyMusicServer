using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using Server.Services;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Server.Controllers
{
    public class AccountController : Controller
    {
        IAccounts _accounts;
        ILogger<AccountController> _logger;

        public AccountController(IAccounts accounts, ILogger<AccountController> logger)
        {
            _accounts = accounts;
            _logger = logger;
        }

        /// <summary>
        /// Авторизоваться  
        /// </summary>
        /// <param name="login"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        [HttpPost("/token")]

        //DTO-объекты
        public async Task<ActionResult> CreateToken(string login, string password) 
        {
            var response = await _accounts.CreateToken(login, password);

            if (response == null) BadRequest(new { errorText = "Invalid username or password" });

            return Ok(response);
        }
    }
}

//openSSL - генерация привтных и публичных ключей 
//Login contr
//Autorization contr 



