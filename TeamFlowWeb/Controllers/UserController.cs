using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Text;
using TeamFlowWeb.DTOs;
using TeamFlowWeb.Models;
using TeamFlowWeb.Services;

namespace TeamFlowWeb.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        private readonly ITokenService _tokenService;
        public UserController(IUserService userService, ITokenService tokenService)
        {
            _userService = userService;
            _tokenService = tokenService;
        }
        [HttpPost("register")]
        public IActionResult RegisterUser(UserRegister request)
        {
            var user = new User
            {
                Name = request.Name,
                Email = request.Email,
            };
            var registeredUser = _userService.RegisterUserService(user, request.Password);
            if (registeredUser == null)
            {
                return Conflict("Email already Registered");
            }
            return Ok(new { 
                registeredUser.Name,
                registeredUser.Email, 
                registeredUser.Id
            });
        }
        [HttpPost("login")]
        public IActionResult LoginUser(LoginUser login)
        {
            var user =  _userService.Login(login.Email, login.Password);
            if (user == null)
            {
                return Unauthorized("Login Failed");
            }
            var token = _tokenService.GenerateToken(user);
            var response = new
            {
                Token = token,
                User = new User
                {
                    Id = user.Id,
                    Name = user.Name,
                    Email = user.Email,
                }
            };
            return Ok(response);    
        }
    }
}
