using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain.User {
    public class FilmDto {
        public int Filme_Id { get; set; }
        public string Titulo { get; set; }
        public double Nota { get; set; }
        public string Lancamento { get; set; }
    }
}
