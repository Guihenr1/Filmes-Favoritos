using Api.Data.Context;
using Api.Domain.User;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Data.Repository {
    public class UserRepository : BaseRepository<User>, IUserRepository {
        public UserRepository(ApplicationDbContext context) : base(context) {

        }
        public User getCpf(string cpf) {
            var entity = _context.Set<User>().Where(c => c.CPF == cpf);
            if (entity.Any())
                return entity.First();
            return null;
        }
    }
}
