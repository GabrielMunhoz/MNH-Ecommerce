using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MNH_Ecommerce.Domain.Contrats;
using MNH_Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MNH_Ecommerce.Web.Controllers
{
    [Route("api/[Controller]")]
    public class UserController : Controller
    {
        private readonly IUserRepository _userRepository;
        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }
        [Authorize("Bearer")]
        [HttpGet]
        public ActionResult Get()
        {
            try
            {
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }
        
        [HttpPost]
        public ActionResult Post([FromBody] User user)
        {
            try
            {
                var usuarioCadastrado = _userRepository.Get(user.Email);
                if (usuarioCadastrado != null)
                {
                    return BadRequest("Usuario já cadastrado");
                }
                _userRepository.Add(user);

                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);

            }
        }

        [Authorize("Bearer")]
        [HttpPost("VerifyUser")]
        public ActionResult VerifyUser([FromBody] User user)
        {
            try
            {
                var returnedUser = _userRepository.Login(user.Email, user.Password);

                if (returnedUser != null)
                {
                    return Ok(returnedUser);
                }
                return BadRequest("Usuario ou senha invalidos");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
                
            }
        }

        [HttpPost("Logintoken")]
        public object Logintoken(
            [FromBody]User usuario,
            [FromServices]SigningConfigurations signingConfigurations,
            [FromServices]TokenConfigurations tokenConfigurations)
        {
            bool credenciaisValidas = false;
            if (usuario != null && !String.IsNullOrWhiteSpace(usuario.Email) && !String.IsNullOrWhiteSpace(usuario.Password))
            {
                var usuarioBase = _userRepository.Login(usuario.Email, usuario.Password);
                usuario.Id = usuarioBase.Id;
                credenciaisValidas = (usuarioBase != null &&
                    usuario.Email == usuarioBase.Email &&
                    usuario.Password == usuarioBase.Password);
            }

            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(usuario.Id.ToString(), "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, usuario.Id.ToString())
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }

    }
}
