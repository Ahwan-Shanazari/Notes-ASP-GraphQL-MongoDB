using AutoMapper;
using Data.Repositories.Interfaces;
using Entity;
using Entity.Interfaces;

namespace NoteAPI.GraphQL;

public class Query(INoteRepository noteRepository, IMapper mapper)
{
    public async Task<IEnumerable<INote>> GetNotesAsync()
    {
        return (await noteRepository.GetAllAsync()).Select(note => note.IsChecked == null ? (INote)mapper.Map<NormalNote>(note) : mapper.Map<CheckNote>(note));
    }

    public async Task<INote?> GetNoteAsync(string id)
    {
        var result = await noteRepository.GetByIdAsync(id);
        return result.IsChecked == null ? mapper.Map<NormalNote>(result) : mapper.Map<CheckNote>(result);
    }
}