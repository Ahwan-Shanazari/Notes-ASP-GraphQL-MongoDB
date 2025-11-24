using AutoMapper;
using Data.Repositories.Interfaces;
using Entity;
using Entity.DTO;
using Entity.Interfaces;

namespace NoteAPI.GraphQL;

public class Mutation(INoteRepository noteRepository,IMapper mapper)
{
    public async Task<INote> CreateNote(CreateAndUpdateNoteDto note)
    {
        var toBeCreated = new BaseNote()
        {
            Text = note.Text,
            Title = note.Title,
            CreateDate = DateTime.UtcNow.Date,
            Type = note.Type,
            IsChecked = note.IsChecked,
            Theme = note.Theme != null
                ? new NoteTheme
                {
                    ColorR = note.Theme.ColorR,
                    ColorG = note.Theme.ColorG,
                    ColorB = note.Theme.ColorB,
                    Name = note.Theme.Name
                }
                : null,
        };
        var result = await noteRepository.CreateAsync(toBeCreated);
        return result.IsChecked == null ? mapper.Map<NormalNote>(result) : mapper.Map<CheckNote>(result);
    }

    public async Task<bool> UpdateNote(string id, CreateAndUpdateNoteDto note)
    {
        var toBeUpdate = new BaseNote()
        {
            Id = id,
            Text = note.Text,
            Title = note.Title,
            CreateDate = DateTime.UtcNow.Date,
            Type = note.Type,
            IsChecked = note.IsChecked,
            Theme = note.Theme != null
                ? new NoteTheme
                {
                    ColorR = note.Theme.ColorR,
                    ColorG = note.Theme.ColorG,
                    ColorB = note.Theme.ColorB,
                    Name = note.Theme.Name
                }
                : null,
        };
        return await noteRepository.UpdateAsync(id, toBeUpdate);
    }

    public async Task<bool> DeleteNote(string id)
    {
        return await noteRepository.DeleteAsync(id);
    }
}