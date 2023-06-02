namespace Scripts.Services
{
    public interface ILoader
    {
        T Load<T>(string dataName);
    }
}
