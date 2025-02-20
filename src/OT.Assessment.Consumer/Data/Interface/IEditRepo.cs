
namespace OT.Assessment.Consumer.Data.Interface
{
  public interface IEditRepo <T>
  {
    public abstract T CreateRecord(T obj);

    public bool SaveChanges();

  }
}
