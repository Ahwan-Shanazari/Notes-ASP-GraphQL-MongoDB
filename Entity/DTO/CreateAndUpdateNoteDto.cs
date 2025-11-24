using Entity.Enums;

namespace Entity.DTO;

[GraphQLName("CreateAndUpdateInput")]
public class CreateAndUpdateNoteDto
{
    public string Title { get; set; }
    public string Text { get; set; }
    public NoteType Type { get; set; }
    public ThemeDto? Theme { get; set; }
    public bool? IsChecked { get; set; }
}