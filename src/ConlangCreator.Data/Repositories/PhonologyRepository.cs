using ConlangCreator.Core.Interfaces;
using ConlangCreator.Core.Models;
using Microsoft.EntityFrameworkCore;

namespace ConlangCreator.Data.Repositories;

public class PhonologyRepository : IPhonologyRepository
{
    private readonly ConlangDbContext _db;

    public PhonologyRepository(ConlangDbContext db)
    {
        _db = db;
    }

    // Phonemes
    public async Task<List<Phoneme>> GetPhonemesAsync(int languageId) =>
        await _db.Phonemes
            .Where(p => p.LanguageId == languageId)
            .OrderBy(p => p.Type)
            .ThenBy(p => p.Place ?? (PlaceOfArticulation)99)
            .ThenBy(p => p.Manner ?? (MannerOfArticulation)99)
            .ThenBy(p => p.Height ?? (VowelHeight)99)
            .ThenBy(p => p.Backness ?? (VowelBackness)99)
            .ToListAsync();

    public async Task<Phoneme> AddPhonemeAsync(Phoneme phoneme)
    {
        _db.Phonemes.Add(phoneme);
        await _db.SaveChangesAsync();
        return phoneme;
    }

    public async Task RemovePhonemeAsync(int phonemeId)
    {
        var phoneme = await _db.Phonemes.FindAsync(phonemeId);
        if (phoneme is not null)
        {
            _db.Phonemes.Remove(phoneme);
            await _db.SaveChangesAsync();
        }
    }

    public async Task RemoveAllPhonemesAsync(int languageId)
    {
        var phonemes = await _db.Phonemes.Where(p => p.LanguageId == languageId).ToListAsync();
        _db.Phonemes.RemoveRange(phonemes);
        await _db.SaveChangesAsync();
    }

    // Syllable Rules
    public async Task<List<SyllableRule>> GetSyllableRulesAsync(int languageId) =>
        await _db.SyllableRules
            .Where(r => r.LanguageId == languageId)
            .OrderByDescending(r => r.IsDefault)
            .ThenByDescending(r => r.Weight)
            .ToListAsync();

    public async Task<SyllableRule> AddSyllableRuleAsync(SyllableRule rule)
    {
        _db.SyllableRules.Add(rule);
        await _db.SaveChangesAsync();
        return rule;
    }

    public async Task UpdateSyllableRuleAsync(SyllableRule rule)
    {
        _db.SyllableRules.Update(rule);
        await _db.SaveChangesAsync();
    }

    public async Task RemoveSyllableRuleAsync(int ruleId)
    {
        var rule = await _db.SyllableRules.FindAsync(ruleId);
        if (rule is not null)
        {
            _db.SyllableRules.Remove(rule);
            await _db.SaveChangesAsync();
        }
    }

    // Phonological Rules
    public async Task<List<PhonologicalRule>> GetPhonologicalRulesAsync(int languageId) =>
        await _db.PhonologicalRules
            .Where(r => r.LanguageId == languageId)
            .OrderBy(r => r.Order)
            .ToListAsync();

    public async Task<PhonologicalRule> AddPhonologicalRuleAsync(PhonologicalRule rule)
    {
        if (rule.Order == 0)
        {
            var maxOrder = await _db.PhonologicalRules
                .Where(r => r.LanguageId == rule.LanguageId)
                .MaxAsync(r => (int?)r.Order) ?? 0;
            rule.Order = maxOrder + 1;
        }
        _db.PhonologicalRules.Add(rule);
        await _db.SaveChangesAsync();
        return rule;
    }

    public async Task UpdatePhonologicalRuleAsync(PhonologicalRule rule)
    {
        _db.PhonologicalRules.Update(rule);
        await _db.SaveChangesAsync();
    }

    public async Task RemovePhonologicalRuleAsync(int ruleId)
    {
        var rule = await _db.PhonologicalRules.FindAsync(ruleId);
        if (rule is not null)
        {
            _db.PhonologicalRules.Remove(rule);
            await _db.SaveChangesAsync();
        }
    }

    public async Task ReorderPhonologicalRulesAsync(int languageId, List<int> orderedRuleIds)
    {
        var rules = await _db.PhonologicalRules
            .Where(r => r.LanguageId == languageId)
            .ToListAsync();

        for (int i = 0; i < orderedRuleIds.Count; i++)
        {
            var rule = rules.FirstOrDefault(r => r.Id == orderedRuleIds[i]);
            if (rule is not null)
                rule.Order = i + 1;
        }
        await _db.SaveChangesAsync();
    }

    // Romanization
    public async Task<List<RomanizationMapping>> GetRomanizationMappingsAsync(int languageId) =>
        await _db.RomanizationMappings
            .Include(m => m.Phoneme)
            .Where(m => m.LanguageId == languageId)
            .OrderBy(m => m.Phoneme.Type)
            .ThenBy(m => m.Phoneme.IpaSymbol)
            .ToListAsync();

    public async Task SetRomanizationMappingsAsync(int languageId, List<RomanizationMapping> mappings)
    {
        var existing = await _db.RomanizationMappings
            .Where(m => m.LanguageId == languageId)
            .ToListAsync();
        _db.RomanizationMappings.RemoveRange(existing);

        foreach (var mapping in mappings)
            mapping.LanguageId = languageId;

        _db.RomanizationMappings.AddRange(mappings);
        await _db.SaveChangesAsync();
    }
}
