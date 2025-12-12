using jwt_auth_api.Domain;
using jwt_auth_api.Infrastructure.Repositories.Interfaces;

namespace jwt_auth_api.Application.Service
{
    public class GeneriService<T> : IRepositoriy<T> where T : BaseModel
    {
        private readonly IRepositoriy<T> _repository;
        public GeneriService(IRepositoriy<T> repository)
        {
            _repository = repository;
        }

        public virtual List<T> Read()
        {
            return _repository.Read();
        }

        public virtual T ReadById(int id)
        {
            var entity = _repository.ReadById(id);

            if (entity == null)
                throw new Exception($"Registro ID {id} não encontrado.");

            return entity;
        }

        public virtual int Create(T entity)
        {
            return _repository.Create(entity);
        }

        public virtual void Update(T entity)
        {
            var existing = _repository.ReadById(entity.Id);

            if (existing == null)
                throw new Exception($"Registro {entity.Id} não encontrado.");

            _repository.Update(entity);
        }

        public virtual void Delete(int id)
        {
            var entity = _repository.ReadById(id);

            if (entity == null)
                throw new Exception($"Registro {id} não encontrado.");

            _repository.Delete(id);
        }

        public virtual bool Exists(int id)
        {
            return _repository.Exists(id);
        }
    }
}
