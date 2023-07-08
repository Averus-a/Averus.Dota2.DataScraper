namespace Averus.Dota2.DataScraper.Lua
{
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Globalization;
    using System.Xml;

    public class LuaJsonWriter : JsonWriter
    {
        private readonly StringWriter _writer;
        private string _propertyName;

        public LuaJsonWriter(StringWriter writer)
        {
            _writer = writer;
        }

        public override void WriteComment(string text)
        {
            base.WriteComment(text);

            // Unnecessary
        }

        public override void WritePropertyName(string name)
        {
            base.WritePropertyName(name);
            _propertyName = name;
        }

        public override void WriteNull()
        {
            base.WriteNull();

            WriteValueElement(JTokenType.Null);
            _writer.WriteEndElement();
        }

        public override void WriteValue(DateTime value)
        {
            base.WriteValue(value);

            WriteValueElement(JTokenType.Date);
            _writer.Write(value);
            _writer.WriteEndElement();
        }

        public override void WriteValue(DateTimeOffset value)
        {
            base.WriteValue(value);

            WriteValueElement(JTokenType.Date);
            _writer.Write(value);
            _writer.WriteEndElement();
        }

        public override void WriteValue(Guid value)
        {
            base.WriteValue(value);

            WriteValueElement(JTokenType.Guid);
            _writer.Write(value.ToString());
            _writer.WriteEndElement();
        }

        public override void WriteValue(TimeSpan value)
        {
            base.WriteValue(value);

            WriteValueElement(JTokenType.TimeSpan);
            _writer.Write(value);
            _writer.WriteEndElement();
        }

        public override void WriteValue(Uri value)
        {
            base.WriteValue(value);

            WriteValueElement(JTokenType.Uri);
            _writer.Write(value);
            _writer.WriteEndElement();
        }

        public override void WriteValue(string value)
        {
            base.WriteValue(value);

            WriteValueElement(JTokenType.String);
            _writer.Write(value);
            _writer.WriteEndElement();
        }

        public override void WriteValue(int value)
        {
            base.WriteValue(value);

            WriteValueElement(JTokenType.Integer);
            _writer.Write(value);
            _writer.WriteEndElement();
        }

        public override void WriteValue(long value)
        {
            base.WriteValue(value);

            WriteValueElement(JTokenType.Integer);
            _writer.Write(value);
            _writer.WriteEndElement();
        }

        public override void WriteValue(short value)
        {
            base.WriteValue(value);

            WriteValueElement(JTokenType.Integer);
            _writer.Write(value);
            _writer.WriteEndElement();
        }

        public override void WriteValue(byte value)
        {
            base.WriteValue(value);

            WriteValueElement(JTokenType.Integer);
            _writer.Write(value);
            _writer.WriteEndElement();
        }

        public override void WriteValue(bool value)
        {
            base.WriteValue(value);

            WriteValueElement(JTokenType.Boolean);
            _writer.Write(value);
            _writer.WriteEndElement();
        }

        public override void WriteValue(char value)
        {
            base.WriteValue(value);

            WriteValueElement(JTokenType.String);
            _writer.Write(value.ToString(CultureInfo.InvariantCulture));
            _writer.WriteEndElement();
        }

        public override void WriteValue(decimal value)
        {
            base.WriteValue(value);

            WriteValueElement(JTokenType.Float);
            _writer.Write(value);
            _writer.WriteEndElement();
        }

        public override void WriteValue(double value)
        {
            base.WriteValue(value);

            WriteValueElement(JTokenType.Float);
            _writer.Write(value);
            _writer.WriteEndElement();
        }

        public override void WriteValue(float value)
        {
            base.WriteValue(value);

            WriteValueElement(JTokenType.Float);

            _writer.Write(value);
        }

        private void WriteValueElement(JTokenType type)
        {
            if (_propertyName != null)
            {
                WriteValueElement(_propertyName, type);
                _propertyName = null;
            }
            else
            {
                WriteValueElement("Item", type);
            }
        }

        private void WriteValueElement(string elementName, JTokenType type)
        {
            _writer.Write(elementName);
        }

        public override void WriteStartArray()
        {
            bool isStart = (WriteState == Newtonsoft.Json.WriteState.Start);

            base.WriteStartArray();

            if (isStart)
            {
                WriteValueElement("Root", JTokenType.Array);
            }
            else
            {
                WriteValueElement(JTokenType.Array);
            }
        }

        public override void WriteStartObject()
        {
            bool isStart = (WriteState == Newtonsoft.Json.WriteState.Start);

            base.WriteStartObject();

            if (isStart)
            {
                WriteValueElement("Root", JTokenType.Object);
            }
            else
            {
                WriteValueElement(JTokenType.Object);
            }
        }

        public override void WriteStartConstructor(string name)
        {
            bool isStart = (WriteState == Newtonsoft.Json.WriteState.Start);

            base.WriteStartConstructor(name);

            if (isStart)
            {
                WriteValueElement("Root", JTokenType.Constructor);
            }
            else
            {
                WriteValueElement(JTokenType.Constructor);
            }
        }

        public override void WriteEndArray()
        {
            base.WriteEndArray();
            _writer.Write("]");
        }

        public override void WriteEndObject()
        {
            base.WriteEndObject();

            // TODO?
        }

        public override void WriteEndConstructor()
        {
            base.WriteEndConstructor();

            // TODO?
        }

        public override void Flush()
        {
            _writer.Flush();
        }

        protected override void WriteIndent()
        {
            _writer.WriteWhitespace();

            // levels of indentation multiplied by the indent count
            int currentIndentCount = Top * 2;

            while (currentIndentCount > 0)
            {
                // write up to a max of 10 characters at once to avoid creating too many new strings
                int writeCount = Math.Min(currentIndentCount, 10);

                _writer.WriteWhitespace(writeCount);

                currentIndentCount -= writeCount;
            }
        }
    }

    internal static class StringWriterExtensions
    {
        public static void WriteWhitespace(this StringWriter writer, int count = 0)
        {
            if (count > 0)
            {
                writer.Write((new string(' ', count)));
                return;
            }
            writer.WriteLine();
        }

        public static void WriteEndElement(this StringWriter writer)
        {
            writer.Write(",");
        }
    }
}
