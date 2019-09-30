using Microsoft.AspNetCore.Mvc;
using MNH_Ecommerce.Domain.Contrats;
using MNH_Ecommerce.Domain.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
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

    }
}
