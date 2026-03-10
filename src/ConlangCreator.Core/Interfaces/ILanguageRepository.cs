using ConlangCreator.Core.Models;

namespace ConlangCreator.Core.Interfaces;

public interface ILanguageRepository
{
    Task<Language?> GetByIdAsync(int id);
    Task<Language?> GetWithPhonologyAsync(int id);
    Task<List<Language>> GetAllAsync();
    Task<Language> CreateAsync(Language language);
    Task UpdateAsync(Language language);
    Task DeleteAsync(int id);
}
