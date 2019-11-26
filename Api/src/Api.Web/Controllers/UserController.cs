using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api.Domain._Base;
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
        private readonly IRepository<User> _repository;
        public UserController(UserStore userStore, IRepository<User> repository) {
            _userStore = userStore;
            _repository = repository;
        }
        [HttpPost]
        public IActionResult Salvar([FromBody]UserDto model) {
            _userStore.Add(model);
            return Ok();
        }
        [HttpPut]
        public IActionResult Editar([FromBody]UserDto model) {
            _userStore.Update(model);
            return Ok();
        }
        [HttpGet]
        public IActionResult Listar() {
            var result = _repository.Get();
            if (result.Any()) {
                var userDto = result.Select(u => new UserDto {
                    CPF = u.CPF,
                    Nome = u.Nome,
                    Senha = u.Senha
                });
                return Ok(userDto);
            }
            return null;
        }
    }
}