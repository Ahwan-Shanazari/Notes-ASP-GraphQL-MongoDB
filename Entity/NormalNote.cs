using Entity.Enums;
using Entity.Interfaces;

namespace Entity;

public class NormalNote : INote
{
    public string Id { get; set; }
    public string? Title { get; set; }
    public string Text { get; set; }
    public NoteType Type { get; set; }
    public DateTime CreateDate { get; set; }
    public NoteTheme? Theme { get; set; }
    public int TokenCount(int size = 4)
    {
        return Text.Length/size;
    }
}