using WPR.Core.UnitsOfWork;

namespace WPR.Data.UnitsOfWork;

public class UnitOfWork : IUnitOfWork
{
    private readonly WprDbContext _context;

    public UnitOfWork(WprDbContext context)
    {
        _context = context;
    }

    public int SaveChanges()
    {
        return _context.SaveChanges();
    }
}