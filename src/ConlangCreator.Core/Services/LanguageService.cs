using ConlangCreator.Core.Interfaces;
using ConlangCreator.Core.Models;

namespace ConlangCreator.Core.Services;

public class LanguageService
{
    private readonly ILanguageRepository _languageRepo;

    public LanguageService(ILanguageRepository languageRepo)
    {
        _languageRepo = languageRepo;
    }

    public Task<List<Language>> GetAllLanguagesAsync() => _languageRepo.GetAllAsync();
    public Task<Language?> GetLanguageAsync(int id) => _languageRepo.GetByIdAsync(id);
    public Task<Language?> GetLanguageWithPhonologyAsync(int id) => _languageRepo.GetWithPhonologyAsync(id);

    public async Task<Language> CreateLanguageAsync(string name, string? description = null, string? endonym = null)
    {
        var language = new Language
        {
            Name = name,
            Description = description,
            Endonym = endonym,
        };
        return await _languageRepo.CreateAsync(language);
    }

    public async Task UpdateLanguageAsync(Language language)
    {
        language.UpdatedAt = DateTime.UtcNow;
        await _languageRepo.UpdateAsync(language);
    }

    public Task DeleteLanguageAsync(int id) => _languageRepo.DeleteAsync(id);
}
