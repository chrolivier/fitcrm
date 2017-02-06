using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace fitcrm.tests
{

    [TestFixture]
    class AttributeDescriptorTests
    {
        [Test]
        [TestCase("Name", "Name", null, null)]
        [TestCase("Full Name", "Full Name", null, null)]
        [TestCase("One two three", "One two three", null, null)]
        public void Ctor_DisplayNameOnly_PopulatesAttributeName(string input, string displayName, string member, string format)
        {
            var sut = new AttributeDescriptor(input);
            Assert.That(sut.DisplayName, Is.EqualTo(displayName));
            Assert.That(sut.Member, Is.EqualTo(member));
            Assert.That(sut.Format, Is.EqualTo(format));
        }

        [Test]
        [TestCase("Name.Start", "Name", "Start", null)]
        [TestCase("Full Name.Foo", "Full Name", "Foo", null)]
        [TestCase("One two three.four", "One two three", "four", null)]
        public void Ctor_MemberSpecified_IsParsedCorrectly(string input, string displayName, string member, string format)
        {
            var sut = new AttributeDescriptor(input);
            Assert.That(sut.DisplayName, Is.EqualTo(displayName));
            Assert.That(sut.Member, Is.EqualTo(member));
            Assert.That(sut.Format, Is.EqualTo(format));
        }

        [Test]
        [TestCase("Name.Start:xxx", "Name", "Start", "xxx")]
        [TestCase("Full Name.Foo:xxx", "Full Name", "Foo", "xxx")]
        [TestCase("One two three.four:xxx", "One two three", "four", "xxx")]
        public void Ctor_MemberAndFormatSpecified_IsParsedCorrectly(string input, string displayName, string member, string format)
        {
            var sut = new AttributeDescriptor(input);
            Assert.That(sut.DisplayName, Is.EqualTo(displayName));
            Assert.That(sut.Member, Is.EqualTo(member));
            Assert.That(sut.Format, Is.EqualTo(format));
        }

        [Test]
        [TestCase("Name:xxx", "Name", null, "xxx")]
        [TestCase("Full Name:xxx", "Full Name", null, "xxx")]
        [TestCase("One two three:xxx", "One two three", null, "xxx")]
        public void Ctor_AttributeFormatSpecified_IsParsedCorrectly(string input, string displayName, string member, string format)
        {
            var sut = new AttributeDescriptor(input);
            Assert.That(sut.DisplayName, Is.EqualTo(displayName));
            Assert.That(sut.Member, Is.EqualTo(member));
            Assert.That(sut.Format, Is.EqualTo(format));
        }
    }
}
