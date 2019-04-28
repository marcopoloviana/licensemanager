
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using LicenceManager.Models;
using licensemanager.Repositories;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace licensemanager.Controllers
{
    [Route("api/[controller]")]
    public class TokenController : Controller
    {
        private readonly IConfiguration _configuration;
        public TokenController(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        [AllowAnonymous]
        [HttpGet("teste")]
        public IActionResult TestApi()
        {
            return Ok("Api up!");
        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult RequestToken([FromBody] Resale resale)
        {
            ResaleRepository _resale; 

            _resale = new ResaleRepository();
            var resaleDb = _resale.Autenticate(resale.Email,resale.Password);

            if (resaleDb!=null)
            {
                var claims = new[]
                {
                    new Claim(ClaimTypes.Sid, resaleDb.ID.ToString()),
                    new Claim(ClaimTypes.Name, resaleDb.Name),
                    new Claim(ClaimTypes.Email, resaleDb.Email)                    
                };

                var key = new SymmetricSecurityKey(
                    Encoding.UTF8.GetBytes(_configuration["SecurityKey"])
                );

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var token = new JwtSecurityToken(
                    issuer: "gerenciadoronline.com.br",
                    audience: "gerenciadoronline.com.br",
                    claims: claims,
                    expires: DateTime.Now.AddMinutes(60),
                    signingCredentials: creds);

                return Ok(
                    new {
                        token = new JwtSecurityTokenHandler().WriteToken(token),
                        resaleId = resaleDb.ID
                    }
                );
            } else {
                return Unauthorized("Usuário ou senha inválidos!");
            }
        }
    }
}