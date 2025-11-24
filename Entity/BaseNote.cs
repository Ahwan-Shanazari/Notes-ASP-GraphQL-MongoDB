using Entity.Enums;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entity;


public class BaseNote 
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string Id { get; set; }
    public string? Title { get; set; }
    public string Text { get; set; }
    public NoteType Type { get; set; }
    public DateTime CreateDate { get; set; }
    public NoteTheme? Theme { get; set; }
    public bool? IsChecked { get; set; }
}
