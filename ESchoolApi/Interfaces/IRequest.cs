namespace ESchoolApi.Interfaces;

public interface IRequest<T>
{
    public List<T> GetAll();
    public T GetDetails(Guid Id);
    public void AddEntity(T obj);
    public void UpdateEntity(T obj);
    public void Remove(T obj);
}