using MeuLivroDeReceitas.Domain.Entities;

namespace MeuLivroDeReceitas.Domain.Repository;
public interface IUserWriteOnlyRepository
{
    Task AddUser(Usuario usuario);
}