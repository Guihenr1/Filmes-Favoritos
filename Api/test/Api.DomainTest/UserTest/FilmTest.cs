using ExpectedObjects;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Api.DomainTest.UserTest {
    public class FilmTest {
        [Fact]
        public void DevoCriarFilme() {
            var filmeEsperado = new {
                Filme_Id = (int)1,
                Titulo = "Os Vingadores",
                Nota = (double)4.75,
                Lancamento = "2019-01-01"
            };

            var filme = new Film(filmeEsperado.Filme_Id, filmeEsperado.Titulo, filmeEsperado.Nota, filmeEsperado.Lancamento);

            filmeEsperado.ToExpectedObject().ShouldMatch(filme);
        }
    }

    public class Film {
        public Film(int filme_Id, string titulo, double nota, string lancamento) {
            Filme_Id = filme_Id;
            Titulo = titulo;
            Nota = nota;
            Lancamento = lancamento;
        }

        public int Filme_Id { get; private set; }
        public string Titulo { get; private set; }
        public double Nota { get; private set; }
        public string Lancamento { get; private set; }
    }
}
