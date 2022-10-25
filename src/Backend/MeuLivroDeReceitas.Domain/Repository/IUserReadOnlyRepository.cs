namespace MeuLivroDeReceitas.Domain.Repository;

public interface IUserReadOnlyRepository
{
    Task<bool> ThereUserWithEmail(string email);
}