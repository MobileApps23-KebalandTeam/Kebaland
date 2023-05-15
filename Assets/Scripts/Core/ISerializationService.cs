namespace Core
{
    public interface ISerializationService
    {
        bool Serialize();

        void Deserialize();

        string fileName();
        
    }
}