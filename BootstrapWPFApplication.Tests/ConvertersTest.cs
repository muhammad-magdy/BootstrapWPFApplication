using BootstrapWPFApplication.UI.Converters;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Globalization;
using System.Windows;

namespace BootstrapWPFApplication.Tests
{
    [TestClass()]
    public class ConvertersTest
    {

        [TestMethod()]
        public void ToLowerConverterTest()
        {
            var expected = "string";
            var converter = new ToLowerConverter();
            var actual = converter.Convert("StRing", null, null, CultureInfo.CreateSpecificCulture("en-us"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void ToUpperConverterTest()
        {
            var expected = "STRING";
            var converter = new ToUpperConverter();
            var actual = converter.Convert("StRing", null, null, CultureInfo.CreateSpecificCulture("en-us"));
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BooleanToStringConverterTest()
        {
            var expected = "Valid";
            var converter = new BooleanToStringConverter("Valid", "Invalid");
            var actual = converter.Convert(true, null, null, null);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BooleanToStringConverterInverseTest()
        {
            var expected = "Invalid";
            var converter = new BooleanToStringConverter("Valid", "Invalid");
            var actual = converter.Convert(true, null, "inverse", null);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BooleanToVisibilityConverterTest()
        {
            var expected = Visibility.Visible;
            var converter = new BoolToVisibilityConverter();
            var actual = converter.Convert(true, null, null, null);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void BooleanToVisibilityConverterInverseTest()
        {
            var expected = Visibility.Collapsed;
            var converter = new BoolToVisibilityConverter();
            var actual = converter.Convert(true, null, "inverse", null);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void EmptyStringToValueConverterTest()
        {
            var expected = "NA";
            var converter = new EmptyStringToValueConverter();
            var actual = converter.Convert("", null, "NA", null);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]

        public void NullOrEmptyStringToVisibilityConverterTest()
        {
            var expected = Visibility.Visible;
            var converter = new NullOrEmptyStringToVisibilityConverter();
            var actual = converter.Convert("", null, null, null);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void NullOrEmptyStringToVisibilityConverterNullTest()
        {
            var expected = Visibility.Visible;
            var converter = new NullOrEmptyStringToVisibilityConverter();
            var actual = converter.Convert(null, null, null, null);
            Assert.AreEqual(expected, actual);
        }

        [TestMethod()]
        public void StringMatchToVisibilityConverterTest()
        {
            var expected = Visibility.Visible;
            var converter = new StringMatchToVisibilityConverter("Mohamed");
            var actual = converter.Convert("Mohamed", null, null, null);
            Assert.AreEqual(expected, actual);
        }
    }
}
