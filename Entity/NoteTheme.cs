using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace Entity;

public class NoteTheme
{
    public int ColorR { get; set; }
    public int ColorG { get; set; }
    public int ColorB { get; set; }
    public string Name { get; set; }
}