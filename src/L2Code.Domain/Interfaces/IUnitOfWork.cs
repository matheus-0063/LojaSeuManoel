namespace L2Code.Domain.Interfaces;

public interface IUnitOfWork
{
    Task<int> Commit();
}