using Newtonsoft.Json.Linq;
using NUnit.Framework;
namespace DogeONSharp.Test
{
    [TestFixture]
    public class DogeONConvertTests
    {
        [Test]
        public void TestEmpty()
        {
            var json = JObject.Parse("{ }");
            var result = DogeONConvert.ToDogeONString(json);
            Assert.AreEqual("such wow", result);
        }

        [Test]
        public void TestCase1()
        {
            var json = JObject.Parse("{\"foo\": \"bar\", \"doge\": \"shibe\"}");
            var result = DogeONConvert.ToDogeONString(json);
            Assert.AreEqual("such \"foo\" is \"bar\", \"doge\" is \"shibe\" wow", result);
        }

        [Test]
        public void TestCase2()
        {
            var json = JObject.Parse("{\"foo\": {\"shiba\": \"inu\", \"doge\": true}}");
            var result = DogeONConvert.ToDogeONString(json);
            Assert.AreEqual("such \"foo\" is such \"shiba\" is \"inu\", \"doge\" is yes wow wow", result);
        }

        [Test]
        public void TestCase3()
        {
            var json = JObject.Parse("{\"foo\": [\"bar\", \"baz\", \"fizzbuzz\"]}");
            var result = DogeONConvert.ToDogeONString(json);
            Assert.AreEqual("such \"foo\" is so \"bar\" also \"baz\" also \"fizzbuzz\" many wow", result);
        }

        [Test]
        public void TestCase4()
        {
            var json = JObject.Parse("{\"foo\": 34e3}");
            var result = DogeONConvert.ToDogeONString(json);
            Assert.AreEqual("such \"foo\" is 42very3 wow", result);
        }
    }
}