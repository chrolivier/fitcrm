using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace fitcrm.tests.Converters
{

    [TestFixture]
    class DateTimeConverterTests
    {
        [Test]
        public void ToCrm_NoFormat_ParsesDateUsingCurrentCulture()
        {
            var descriptor = new AttributeDescriptor("Foo", null, null);
            var sut = new fitcrm.Converters.DateTimeConverter(descriptor);
            var result = sut.ToCrm(@"2010/01/10");
            Assert.That(result, Is.EqualTo(new DateTime(2010, 01, 10)));
        }

        [Test]
        public void ToCrm_WithFormat_ParsesDateUsingFormat()
        {
            var descriptor = new AttributeDescriptor("Foo", null, "yyyy/dd/MM");
            var sut = new fitcrm.Converters.DateTimeConverter(descriptor);
            var result = sut.ToCrm(@"2010/01/10");
            Assert.That(result, Is.EqualTo(new DateTime(2010, 10, 01)));
        }

        [Test]
        public void FromCrm_NoFormat_FormatsDateAsString()
        {
            var descriptor = new AttributeDescriptor("Foo", null, null);
            var sut = new fitcrm.Converters.DateTimeConverter(descriptor);
            var expected = DateTime.Now;
            var result = sut.FromCrm(expected);
            Assert.AreEqual(expected, result);
        }

        [Test]
        public void FromCrm_WithFormat_FormatsDateAsString()
        {
            var descriptor = new AttributeDescriptor("Foo", null, "dd/MM/yyyy");
            var sut = new fitcrm.Converters.DateTimeConverter(descriptor);
            var result = sut.FromCrm(new DateTime(2017, 02, 06));
            Assert.AreEqual("06/02/2017", result);
        }

        [Test]
        public void FromCrm_Always_ConvertsFromUTCToLocalTime()
        {
            var descriptor = new AttributeDescriptor("Foo", null, null);
            var sut = new fitcrm.Converters.DateTimeConverter(descriptor);

            var local = DateTime.Now;
            var utc = local.ToUniversalTime();

            var result = (DateTime)sut.FromCrm(utc);
            Assert.AreEqual(local, result);
        }
    }
}
