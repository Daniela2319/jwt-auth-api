
namespace jwt_auth_api.Infrastructure.Repositories.Interfaces
{
    public interface IRepositoriy<T>
    {
        Guid Create(T entity);
        List<T> Read();
        T ReadById(Guid id);
        void Update(T entity);
        void Delete(Guid id);
        bool Exists(Guid id);
    }
}
