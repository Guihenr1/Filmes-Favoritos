using System;

namespace Api.Domain.Model {
    public class Film {
        public Film(int filme_Id, string titulo, double nota, string lancamento) {
            if (filme_Id <= 0)
                throw new ArgumentException("Id do filme inválido");

            if (string.IsNullOrEmpty(titulo))
                throw new ArgumentException("Título do filme inválido");

            if (nota <= 0 || nota > 5)
                throw new ArgumentException("Nota do filme inválida");

            if (string.IsNullOrEmpty(lancamento))
                throw new ArgumentException("Lancamento do filme inválido");

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
