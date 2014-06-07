using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace DogeONSharp
{
    public static class DogeONConvert
    {
        public static string ToDogeONString(JObject json)
        {
            var builder = new StringBuilder();

            ParseObject(json, builder);

            return builder.ToString();
        }

        private static void ParseObject(JToken token, StringBuilder builder)
        {

            builder.Append("such ");

            var properties = ((JObject)token).Properties().ToList();

            for (var x = 0; x < properties.Count; x++)
            {
                var property = properties[x];

                builder.Append(string.Format("\"{0}\" is ", property.Name));

                ParseToken(property.Value, builder);

                if (x < properties.Count - 1)
                {
                    builder.Append(", ");
                }
            }

            EnsurePadding(builder);

            builder.Append("wow");
        }

        private static void ParseToken(JToken token, StringBuilder builder)
        {
            switch (token.Type)
            {
                case JTokenType.Array:
                    ParseArray(token, builder);
                    break;
                case JTokenType.Boolean:
                    builder.Append((bool)token ? "yes" : "no");
                    break;
                case JTokenType.Bytes:
                    break;
                case JTokenType.Comment:
                    break;
                case JTokenType.Constructor:
                    break;
                case JTokenType.Date:
                    break;
                case JTokenType.Float:
                    break;
                case JTokenType.Guid:
                    break;
                case JTokenType.Integer:
                    break;
                case JTokenType.None:
                    break;
                case JTokenType.Null:
                    break;
                case JTokenType.Object:
                    ParseObject(token, builder);
                    break;
                case JTokenType.Property:
                    break;
                case JTokenType.Raw:
                    break;
                case JTokenType.String:
                    builder.Append("\"" + (string)token + "\"");
                    break;
                case JTokenType.TimeSpan:
                    break;
                case JTokenType.Undefined:
                    break;
                case JTokenType.Uri:
                    break;
                default:
                    break;
            }
        }

        private static void ParseArray(JToken array, StringBuilder builder)
        {
            builder.Append("so ");

            var items = ((JArray)array).ToList();

            for (var x = 0; x < items.Count; x++)
            {
                ParseToken(items[x], builder);

                if (x < items.Count - 1)
                {
                    builder.Append(" also ");
                } 
            }

            EnsurePadding(builder);

            builder.Append("many");
        }

        private static void EnsurePadding(StringBuilder builder)
        {
            if (builder[builder.Length - 1] != ' ')
            {
                builder.Append(" ");
            }
        }
    }
}
