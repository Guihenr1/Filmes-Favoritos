using Api.Domain.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.DomainTest._Builder {
    public class FilmBuilder {
        private int _filme_id = 1;
        private string _titulo = "Os Vingadores";
        private double _nota = 4.75;
        private string _lancamento = "2019-01-01";

        public static FilmBuilder Novo() {
            return new FilmBuilder();
        }

        public FilmBuilder ComFilmeId(int filme_id) {
            _filme_id = filme_id;
            return this;
        }

        public FilmBuilder ComTitulo(string titulo) {
            _titulo = titulo;
            return this;
        }

        public FilmBuilder ComNota(double nota) {
            _nota = nota;
            return this;
        }

        public FilmBuilder ComLancamento(string lancamento) {
            _lancamento = lancamento;
            return this;
        }

        public Film Build() {
            return new Film(_filme_id, _titulo, _nota, _lancamento);
        }
    }
}
