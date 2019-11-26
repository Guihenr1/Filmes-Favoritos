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
            Exists(userDto.CPF);

            var user = new User(userDto.CPF, userDto.Nome, userDto.Senha);

            _userRepository.Add(user);
        }

        public void Update(UserDto userDto) {
            var user = new User(userDto.CPF, userDto.Nome, userDto.Senha);

            user = _userRepository.getCpf(userDto.CPF);
            user.AlterarCPF(userDto.CPF);
            user.AlterarNome(userDto.Nome);
            user.AlterarSenha(userDto.Senha);

            _userRepository.Update(user);
        }

        public void Exists(string userCPF) {
            var userExists = _userRepository.getCpf(userCPF);

            if (userExists != null)
                throw new ArgumentException(Resource.UsuarioJaCadastrado);
        }
    }
}
