namespace Crud.Domain.Repositories.UnitOfWork;

public interface IUnitOfWork {
    Task Commit();
}