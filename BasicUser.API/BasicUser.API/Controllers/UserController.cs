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
        public List<User> GetUsers()
        {
            var userList = UserList.OrderBy(x => x.Id).ToList<User>();
            return userList;
        }
    }
}
