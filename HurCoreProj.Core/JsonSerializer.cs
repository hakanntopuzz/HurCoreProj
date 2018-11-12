using Newtonsoft.Json;

namespace HurCoreProj.Core
{
    public class JsonSerializer
    {
        private JsonSerializer() { }

        private static JsonSerializer Instance;

        public static JsonSerializer ActiveInstance
        {
            get
            {
                if (Instance == null)
                {
                    Instance = new JsonSerializer();
                }

                return Instance;
            }
        }

        public T DeserializeObject<T>(string json)
        {
            return JsonConvert.DeserializeObject<T>(json);
        }
    }
}
