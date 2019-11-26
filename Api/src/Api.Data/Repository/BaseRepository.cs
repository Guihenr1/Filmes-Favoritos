using Api.Data.Context;
using Api.Domain._Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Api.Data.Repository {
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity {
        protected readonly ApplicationDbContext _context;
        public BaseRepository(ApplicationDbContext context) {
            _context = context;
        }
        public void Add(TEntity entity) {
            _context.Set<TEntity>().Add(entity);
        }

        public List<TEntity> Get() {
            var entities = _context.Set<TEntity>().ToList();
            return entities.Any() ? entities : new List<TEntity>();
        }

        public TEntity GetById(int id) {
            var query = _context.Set<TEntity>().Where(e => e.Id == id);
            return query.Any() ? query.First() : null;
        }

        public void Update(TEntity entity) {
            _context.Update(entity);
        }
    }
}
