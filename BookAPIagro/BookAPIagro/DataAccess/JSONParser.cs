using System.Text.Json;

namespace BookAPIagro.DataAccess
{
    public class JSONParser<ResType>
    {
        public static ResType? ParseJson(string jsonPath)
        {
            if(!System.IO.File.Exists(jsonPath))
            {
                return default;
            }
            string jsonText = System.IO.File.ReadAllText(jsonPath);
            ResType? result = JsonSerializer.Deserialize<ResType>(jsonText);
            return result;
        }
    }
}
