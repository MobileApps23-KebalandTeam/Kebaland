using System.Collections.Generic;

namespace Core
{
    public static class ServiceLocator
    {
        private static Dictionary<System.Type, AbstractSerializationService> map = new();

        public static void Register<T>(T service) where T : AbstractSerializationService
        {
            map[typeof(T)] = service;
        }

        public static T Get<T>() where T : AbstractSerializationService
        {
            return (T)map[typeof(T)];
        }
    }
}