using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;

namespace XP.Hackathon.Zabbot.Model.Extensions
{
    public static class ObjectExtensions
    {
        public static T Clone<T>(this T source) where T : class
        {
            using (Stream cloneStream = new MemoryStream())
            {
                IFormatter formatter = new BinaryFormatter();
                formatter.Serialize(cloneStream, source);
                cloneStream.Position = 0;
                T clone = (T)formatter.Deserialize(cloneStream);
                return clone;
            }
        }
    }
}
