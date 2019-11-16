using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.User {
    public class UserDto {
        public string CPF { get; set; }
        public string Nome { get; set; }
        public string Senha { get; set; }
    }
}
