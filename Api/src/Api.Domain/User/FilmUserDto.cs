using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.User {
    public class FilmUserDto {
        public User Usuario { get; set; }
        public Film Filme { get; set; }
    }
}
