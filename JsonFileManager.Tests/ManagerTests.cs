using FluentAssertions;
using Newtonsoft.Json;

namespace JsonFileManager.Tests
{
    public class ManagerTests
    {
        // Har en dictionary, får JSON tillbaka
        [Fact]
        public void CreateJsonFromDict_ShouldReturnJson()
        {
            // Given
            Dictionary<string, object> dict = new()
            {
                { "Name", "Gandalf" },
                { "Age", 3000 },
                { "Profession", "Wizard" }
            };
            Manager manager = new();

            // When
            string expectedJson = JsonConvert.SerializeObject(dict);
            string returnedJson = manager.CreateJsonFromDict(dict);

            // Then
            returnedJson.Should().NotBeNull();
            returnedJson.Should().BeEquivalentTo(expectedJson);
        }

        [Fact]
        public void CreateJsonFromDict_EmptyDict_ShouldThrowArgumentException()
        {
            // Given
            Dictionary<string, object> dict = new();
            Manager manager = new();

            // When
            Action test = () => manager.CreateJsonFromDict(dict);

            // Then
            test.Should().Throw<ArgumentException>();
        }














    }
}
