using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain.User;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Api.Web.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly UserStore _userStore;
        public UserController(UserStore userStore) {
            _userStore = userStore;
        }
        [HttpPost]
        public IActionResult Salvar(UserDto model) {
            _userStore.Add(model);
            return Ok();
        }
    }
}