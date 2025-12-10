namespace jwt_auth_api.Infrastructure.Repositories.Interfaces
{
    public interface IRepositoriy<T>
    {
        List<T> Read();
        T ReadById(int id);
        int Create(T entity);
        void Update(T entity);
        void Delete(int id);
        bool Exists(int id);
    }
}
