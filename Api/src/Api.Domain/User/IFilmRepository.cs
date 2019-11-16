using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.User {
    public interface IFilmRepository {
        void Add(Film film);
    }
}
