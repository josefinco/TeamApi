using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace TeamApi.Entities
{
    public class Membro
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("nome")]
        public string Nome { get; set; } = null!;

        [BsonElement("telefone")]
        public string Telefone { get; set; } = null!;

        [BsonElement("character")]
        public string Character { get; set; } = null!;

        [BsonElement("cargos")]
        [JsonPropertyName("cargos")]        
        public List<string> Cargo { get; set; } = null!;
        

    }
}
