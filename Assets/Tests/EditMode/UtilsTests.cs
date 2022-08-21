using NUnit.Framework;

namespace Tests
{
    public class UtilsTests
    {
        [Test]
        public void AllPositiveIntValues()
        {
            Assert.IsTrue(Utils.AllPositiveValues(1, 2, 3));
        }

        [Test]
        public void AllPositiveFloatValues()
        {
            Assert.IsTrue(Utils.AllPositiveValues(1f, 2f, 3f));
        }
    }
}
