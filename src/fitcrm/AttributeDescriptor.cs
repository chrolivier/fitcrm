using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace fitcrm
{
    public class AttributeDescriptor
    {
        public AttributeDescriptor(string input)
        {
            DisplayName = input;

            var regex = new Regex(@"(?<attr>[^\#\{]*)(\#(?<member>[^\{]*))?(\{(?<format>.*)\})?");
            var match = regex.Match(input);
            DisplayName = match.Groups["attr"].Value;
            var member = match.Groups["member"].Value;
            Member = !string.IsNullOrWhiteSpace(member)? member : null;
            var format = match.Groups["format"].Value;
            Format = !string.IsNullOrWhiteSpace(format) ? format : null;
        }

        public AttributeDescriptor(string displayName, string member, string format)
        {
            if (string.IsNullOrWhiteSpace(displayName))
                throw new ArgumentException("Value cannot be null or whitespace.", nameof(displayName));
            DisplayName = displayName;
            Member = member;
            Format = format;
        }

        public string DisplayName { get; private set; }
        public string Member { get; private set; }
        public string Format { get; private set; }
    }
}
