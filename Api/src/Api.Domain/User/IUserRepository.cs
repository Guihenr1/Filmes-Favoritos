using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.User {
    public interface IUserRepository {
        void Add(User user);
        void Update(User user);
        User getCpf(string cpf);
    }
}
