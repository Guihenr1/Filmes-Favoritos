using System.Threading.Tasks;

namespace Api.Domain._Base {
    public interface IUnitOfWork {
        Task Commit();
    }
}
