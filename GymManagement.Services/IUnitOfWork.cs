namespace GymManagement.Services;
public interface IUnitOfWork
{
    Task CommitChanges();
}
