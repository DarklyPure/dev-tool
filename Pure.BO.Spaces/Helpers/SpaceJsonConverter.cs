using System.Runtime.InteropServices;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Text.Json.Serialization;

namespace Pure.BO.Spaces.Helpers
{
    public class SpaceJsonConverter : JsonConverter<Space>
    {
        public override Space? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
        {
            IEnumerable<Space>? spaces = JsonSerializer.Deserialize<IEnumerable<Space>>(ref reader);

            // Iterate collection
            if (spaces != null)
            {
                // Get the ultimate parent
                Space? space = spaces.FirstOrDefault(f => f.ParentId == null);

                if (space != null)
                {
                    // Remove the parent from the collection
                    spaces.ToList().Remove(space);

                    space.RebuildHierarchy(spaces);
                }

                return space;
            }
            return null;
        }

        public override void Write(Utf8JsonWriter writer, Space value, JsonSerializerOptions options)
        {
            // Flatten collection
            IEnumerable<Space> spaces = value.Flatten();

            // Create the Json text
            string jsonText = JsonSerializer.Serialize(spaces, new JsonSerializerOptions
            {
                WriteIndented = true
            });

            writer.WriteRawValue(jsonText);
        }

        #region Helpers
        private JsonObject WriteSpace(Space value, JsonSerializerOptions options, JsonObject space)
        {
            JsonObject childSpace = new()
            {
                ["Name"] = value.Name,
                ["Description"] = value.Description,
                ["Type"] = value.Type,
                ["Spaces"] = new JsonArray(),
                ["Attributes"] = new JsonArray(JsonSerializer.Serialize(value.Attributes.AsEnumerable())),
                ["Inside"] = value.Inside,
                ["Note"] = new JsonObject
                {
                    ["Description"] = value.Note.Description,
                    ["Content"] = value.Note.Content
                }
            };
            space["Spaces"] = new JsonArray(JsonSerializer.Serialize(value.Spaces));

            Span<Space> span = CollectionsMarshal.AsSpan(value.Spaces.ToList());

            // Iterate children
            for (int i = 0; i < span.Length; i++)
            {
                Space item = span[i];

                WriteSpace(item, options, space);
            }
            // TODO: Delete after testing
            //foreach (Space item in value.Spaces)
            //{
            //    WriteSpace(item, options, space);
            //}
            return space;
        }
        #endregion
    }
}
