using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Domain._Base {
    public interface IRepository<TEntity> {
        TEntity GetById(int id);
        List<TEntity> Get();
        void Add(TEntity entity);
        void Update(TEntity entity);
    }
}
