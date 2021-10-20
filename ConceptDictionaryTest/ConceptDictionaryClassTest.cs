using NUnit.Framework;
using ConceptDictionary;

namespace ConceptDictionaryTest
{
    public class Tests
    {
        ConceptDictionaryClass ConceptTest;
        ConceptDictionaryClass ConceptTest1;
        [SetUp]
        public void Setup()
        {
           ConceptTest = new ConceptDictionaryClass("", "", "", "");
           ConceptTest1 = new ConceptDictionaryClass(1,"", "", "", "",2);
        }

        [Test]
        public void ConceptDictionary4parameterConstructorTest()
        {
            Assert.NotNull(ConceptTest);
            //Assert.Pass();
        }
        [Test]
        public void ConceptDictionary6parameterConstructorTest()
        {
            Assert.NotNull(ConceptTest1);
            //Assert.Pass();
        }
    }
}