using System.Collections.Generic;

namespace Core
{
    public static class ServiceLocator
    {
        private static Dictionary<System.Type, ISerializationService> map = new();

        public static void Register<T>(T service) where T : ISerializationService
        {
            map.Add(typeof(T), service);
        }

        public static T Get<T>() where T : ISerializationService
        {
            return (T)map[typeof(T)];
        }
    }
}