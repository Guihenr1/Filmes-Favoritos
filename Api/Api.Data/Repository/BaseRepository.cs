using Api.Domain._Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace Api.Data.Repository {
    public class BaseRepository<TEntity> : IRepository<TEntity> where TEntity : Entity {
    }
}
