using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace ApiRestCountries.Models;

public class Country
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string Code { get; set; } = null!;
    public string Name { get; set; } = null!;
    public string Continent { get; set; } = null!;
    public string Flag { get; set; } = null!;
    public string Capital { get; set; } = null!;
    public string Population { get; set; } = null!;
}
