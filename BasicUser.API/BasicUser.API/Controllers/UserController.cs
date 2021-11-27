using BasicUser.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BasicUser.API.Controllers
{
    [Route("api/v1/[controller]s")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private static List<User> UserList = new List<User>()
        {
            new User
            {
                Id = 1,
                UserName = "emirxmertoglu",
                FullName = "Emir Mertoglu",
                Email = "emir.mertoglu.97@gmail.com",
                Password = "emir1337",
                RePassword = "emir1337",
                RegisterDate = new DateTime(2021, 11, 26)
            },
            new User
            {
                Id = 3,
                UserName = "halilgulez",
                Email = "halil.g@gmail.com",
                Password = "halil4321",
                RePassword = "halil4321"
            },
            new User
            {
                Id = 2,
                UserName = "emrullahyilmaz",
                FullName = "Emrullah Yilmaz",
                Email = "emrullah.y@gmail.com",
                Password = "emrullahY1",
                RePassword = "emrullahY1",
                RegisterDate = new DateTime(2021, 11, 24)
            }
        };

        [HttpGet]
        public IActionResult GetUsers()
        {
            var userList = UserList.OrderBy(x => x.Id).ToList<User>();
            return Ok(userList);
        }

        [HttpGet("{username}")]
        public IActionResult GetUserByUserName(string username)
        {
            var user = UserList.Where(x => x.UserName == username).SingleOrDefault();
            if (user is not null)
            {
                return Ok(user);
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] User newUser)
        {
            var user = UserList.SingleOrDefault(x => x.UserName == newUser.UserName);
            if (user is not null)
            {
                return BadRequest();
            }
            UserList.Add(newUser);
            return Ok();
        }

        [HttpPut("{username}")]
        public IActionResult UpdateUser(string username, [FromBody] User updatedUser)
        {
            var user = UserList.SingleOrDefault(x => x.UserName == username);

            if (user is null)
            {
                return BadRequest();
            }

            user.Email = updatedUser.Email != default ? updatedUser.Email : user.Email;
            user.FullName = updatedUser.FullName != default ? updatedUser.FullName : user.FullName;
            user.Password = updatedUser.Password != default ? updatedUser.Password : user.Password;
            user.RePassword = updatedUser.RePassword != default ? updatedUser.RePassword : user.RePassword;
            user.UserName = updatedUser.UserName != default ? updatedUser.UserName : user.UserName;

            return Ok();
        }
    }
}
