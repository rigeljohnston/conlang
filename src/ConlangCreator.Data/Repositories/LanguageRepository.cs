using ConlangCreator.Core.Interfaces;
using ConlangCreator.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ConlangCreator.Data.Repositories;

public class LanguageRepository : ILanguageRepository
{
    private readonly ConlangDbContext _db;

    public LanguageRepository(ConlangDbContext db)
    {
        _db = db;
    }

    public async Task<Language?> GetByIdAsync(int id) =>
        await _db.Languages.FindAsync(id);

    public async Task<Language?> GetWithPhonologyAsync(int id) =>
        await _db.Languages
            .Include(l => l.Phonemes)
            .Include(l => l.SyllableRules)
            .Include(l => l.PhonologicalRules.OrderBy(r => r.Order))
            .Include(l => l.RomanizationMappings)
                .ThenInclude(m => m.Phoneme)
            .FirstOrDefaultAsync(l => l.Id == id);

    public async Task<List<Language>> GetAllAsync() =>
        await _db.Languages
            .OrderByDescending(l => l.UpdatedAt)
            .ToListAsync();

    public async Task<Language> CreateAsync(Language language)
    {
        _db.Languages.Add(language);
        await _db.SaveChangesAsync();
        return language;
    }

    public async Task UpdateAsync(Language language)
    {
        _db.Languages.Update(language);
        await _db.SaveChangesAsync();
    }

    public async Task DeleteAsync(int id)
    {
        var language = await _db.Languages.FindAsync(id);
        if (language is not null)
        {
            _db.Languages.Remove(language);
            await _db.SaveChangesAsync();
        }
    }
}
