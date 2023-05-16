using System.Threading.Tasks;

namespace Task.Repo.Base
{
    public interface IUnitOfWork
    {        
        void Commit();
        void Dispose();
    }
}
