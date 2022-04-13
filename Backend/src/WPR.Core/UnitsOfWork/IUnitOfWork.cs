namespace WPR.Core.UnitsOfWork;

public interface IUnitOfWork
{
    int SaveChanges();
}