using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.User {
    public class UserStore {
        private readonly IUserRepository _userRepository;
        public UserStore(IUserRepository userRepository) {
            _userRepository = userRepository;
        }

        public void Add(UserDto userDto) {
            var userExists = _userRepository.getCpf(userDto.CPF);

            if (userExists != null)
                throw new ArgumentException(Resource.UsuarioJaCadastrado);

            var user = new User(userDto.CPF, userDto.Nome, userDto.Senha);

            _userRepository.Add(user);
        }
    }
}
