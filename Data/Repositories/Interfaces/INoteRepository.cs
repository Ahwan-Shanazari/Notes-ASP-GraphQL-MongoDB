using Entity;

namespace Data.Repositories.Interfaces;

public interface INoteRepository
{
    Task<List<BaseNote>> GetAllAsync(CancellationToken ct = default);
    Task<BaseNote?> GetByIdAsync(string id, CancellationToken ct = default);
    Task<BaseNote> CreateAsync(BaseNote note, CancellationToken ct = default);
    Task<bool> UpdateAsync(string id, BaseNote note, CancellationToken ct = default);
    Task<bool> DeleteAsync(string id, CancellationToken ct = default);
}