namespace Averus.Dota2.DataScraper.Lua
{
    using Newtonsoft.Json.Linq;

    internal static class LuaConvert
    {
        public static void SerializeObject(string json, string tableName)
        {
            JArray array = JArray.Parse(json);
            SerializeArray(array);
        }

        private static void SerializeArray(JToken token)
        {
            var array = token.ToObject<JArray>();

            foreach (var item in array)
            {
                switch (item.Type)
                {
                    case JTokenType.Boolean:
                        break;
                    case JTokenType.Array:
                        SerializeArray(item);
                        break;
                    case JTokenType.String:
                        break;
                    case JTokenType.Object:
                        break;
                    case JTokenType.Date:
                        break;
                    case JTokenType.Float:
                        break;
                    case JTokenType.Integer:
                        break;
                    case JTokenType.None:
                        break;
                    case JTokenType.Null:
                        break;
                    case JTokenType.TimeSpan:
                        break;
                }
            }
        }
    }

    internal abstract class SyntaxNode
    {
        protected abstract void Accept(Visitor v);
    }

    internal abstract class ValueNode : SyntaxNode
    {

    }

    internal class BooleanNode : ValueNode
    {
        protected override void Accept(Visitor v)
        {
            throw new NotImplementedException();
        }
    }

    internal class StringNode : ValueNode
    {
        protected override void Accept(Visitor v)
        {
            throw new NotImplementedException();
        }
    }
}


