using Newtonsoft.Json;
using NUnit.Framework;

namespace Crunch.DotNet.Tests.Unit.Model
{
    [TestFixture]
    public abstract class SimpleDeserialiseTests<T> where T : class
    {
        [Test]
        public void Deserialize()
        {
            // Setup
            var json = System.IO.File.ReadAllText($".\\Model\\{GetSeralisedJsonName()}.json");

            // Execute
            var result = JsonConvert.DeserializeObject<T>(json);

            // Assert
            Assert.That(result, Is.Not.Null);
        }

        protected abstract string GetSeralisedJsonName();
    }
}