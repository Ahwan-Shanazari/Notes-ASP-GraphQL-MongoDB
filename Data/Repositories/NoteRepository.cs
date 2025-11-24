using Data.Repositories.Interfaces;
using Entity;
using MongoDB.Driver;

namespace Data.Repositories;

public class NoteRepository(IMongoDatabase database) : INoteRepository
{
    private readonly IMongoCollection<BaseNote> _notes = database.GetCollection<BaseNote>("notes");

    public async Task<List<BaseNote>> GetAllAsync(CancellationToken ct = default)
    {
        return await _notes.Find(_ => true).ToListAsync(ct);
    }

    public async Task<BaseNote?> GetByIdAsync(string id, CancellationToken ct = default)
    {
        var filter = Builders<BaseNote>.Filter.Eq(note => note.Id, id);
        return await _notes.Find(filter).FirstOrDefaultAsync(ct);
    }

    public async Task<BaseNote> CreateAsync(BaseNote note, CancellationToken ct = default)
    {
        await _notes.InsertOneAsync(note, ct);
        return note;
    }

    public async Task<bool> UpdateAsync(string id, BaseNote note, CancellationToken ct = default)
    {
        var filter = Builders<BaseNote>.Filter.Eq(note => note.Id, id);
        var result = await _notes.ReplaceOneAsync(filter, note, cancellationToken: ct);
        return result.IsAcknowledged && result.ModifiedCount > 0;
    }

    public async Task<bool> DeleteAsync(string id, CancellationToken ct = default)
    {
        var filter = Builders<BaseNote>.Filter.Eq(n => n.Id, id);
        var result = await _notes.DeleteOneAsync(filter, ct);
        return result.IsAcknowledged && result.DeletedCount > 0;
    }
}