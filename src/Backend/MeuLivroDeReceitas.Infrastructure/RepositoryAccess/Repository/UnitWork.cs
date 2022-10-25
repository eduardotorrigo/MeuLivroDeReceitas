using MeuLivroDeReceitas.Domain.Repository;

namespace MeuLivroDeReceitas.Infrastructure.RepositoryAccess.Repository;
public sealed class UnitWork : IDisposable, IUnitWork
{
    private readonly MeuLivroDeReceitasContext _context;
    private bool _disposed;

    public UnitWork(MeuLivroDeReceitasContext context)
    {
        _context = context;
    }
    public async Task Commit()
    {
        await _context.SaveChangesAsync();
    }

    public void Dispose()
    {
        Dispose(true);
    }
    private void Dispose(bool disposing)
    {
        if (!_disposed && disposing)
        {
            _context.Dispose();
            _disposed = true;
        }
    }
}