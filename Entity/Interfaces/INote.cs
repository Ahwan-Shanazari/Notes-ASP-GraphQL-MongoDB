using Entity.Enums;

namespace Entity.Interfaces;

public interface INote
{
    string Id { get; }
    string Title { get; }
    string Text { get; }
    NoteType Type { get; }
    DateTime CreateDate { get; }
    NoteTheme? Theme { get; }
}