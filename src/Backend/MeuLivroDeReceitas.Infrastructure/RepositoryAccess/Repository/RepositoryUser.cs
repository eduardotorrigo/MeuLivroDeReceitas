using MeuLivroDeReceitas.Domain.Entities;
using MeuLivroDeReceitas.Domain.Repository;
using Microsoft.EntityFrameworkCore;

namespace MeuLivroDeReceitas.Infrastructure.RepositoryAccess.Repository;
    public class RepositoryUser : IUserReadOnlyRepository, IUserWriteOnlyRepository
{
    private readonly MeuLivroDeReceitasContext _context;
    public RepositoryUser(MeuLivroDeReceitasContext context)
    {
        _context = context;
    }

    public async Task AddUser(Usuario user)
    {
        await _context.Usuarios.AddAsync(user);
    }

    public async Task<bool> ThereUserWithEmail(string email)
    {
        return await _context.Usuarios.AnyAsync(x => x.Email.Equals(email));
    }
}