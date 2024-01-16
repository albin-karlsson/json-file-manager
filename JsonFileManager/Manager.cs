using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace JsonFileManager
{
    public class Manager
    {
        // JSON till Dictionary

        // Dictionary till JSON
        public string CreateJsonFromDict(Dictionary<string, object> dict)
        {
            // Guard clauses
            if (dict == null)
                throw new ArgumentNullException();
            else if (!dict.Any())
                throw new ArgumentException();
            else if (dict.ContainsValue(null))
                throw new NullReferenceException();

            return JsonConvert.SerializeObject(dict);
        }

        // Skriva JSON-fil
        public void WriteJsonFile(string json, string fileName)
        {
            if (IsValidJson(json))
            {
                string filePath = Path.Combine(Environment.CurrentDirectory, fileName);
                File.WriteAllText(filePath, json);
            }
        }

        /// <summary>
        /// Validates a string as JSON. If invalid JSON, this method will throw a JsonReaderException.
        /// </summary>
        /// <param name="stringToValidate"></param>
        /// <returns>Returns true if the input string is in correct JSON format, otherwise this method throws a JsonReaderException.</returns>
        /// <exception cref="JsonReaderException"></exception>
        private bool IsValidJson(string stringToValidate)
        {
            JToken.Parse(stringToValidate);

            return true;
        }

        // Läsa JSON-fil
    }
}
