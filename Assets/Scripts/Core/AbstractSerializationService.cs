using System.IO;
using System.Runtime.Serialization.Formatters.Binary;
using UnityEngine;

namespace Core
{
    public abstract class AbstractSerializationService
    {
        public AbstractSerializationService()
        {
            handleLoad();
        }

        protected bool Serialize()
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream file = File.Create(Application.persistentDataPath
                                          + "/" + fileName());
            bf.Serialize(file, objectToSave());
            file.Close();
            return true;
        }

        protected T Deserialize<T>() where T : new()
        {
            try
            {
                BinaryFormatter bf = new BinaryFormatter();
                FileStream file =
                    File.Open(Application.persistentDataPath
                              + "/" + fileName(), FileMode.Open);
                T deserialized = (T)bf.Deserialize(file);
                file.Close();
                return deserialized;
            }
            catch (FileNotFoundException e)
            {
                return new T();
            }
        }

        abstract protected string fileName();

        abstract protected object objectToSave();

        abstract protected void handleLoad();
    }
}