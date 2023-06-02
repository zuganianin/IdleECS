namespace Scripts.Services
{
    public interface ISaver
    {
        void Save<T>(string path, T data);
    }
}
