using ConlangCreator.Core.Models;

namespace ConlangCreator.Core.Interfaces;

public interface IPhonologyRepository
{
    // Phonemes
    Task<List<Phoneme>> GetPhonemesAsync(int languageId);
    Task<Phoneme> AddPhonemeAsync(Phoneme phoneme);
    Task RemovePhonemeAsync(int phonemeId);
    Task RemoveAllPhonemesAsync(int languageId);

    // Syllable Rules
    Task<List<SyllableRule>> GetSyllableRulesAsync(int languageId);
    Task<SyllableRule> AddSyllableRuleAsync(SyllableRule rule);
    Task UpdateSyllableRuleAsync(SyllableRule rule);
    Task RemoveSyllableRuleAsync(int ruleId);

    // Phonological Rules
    Task<List<PhonologicalRule>> GetPhonologicalRulesAsync(int languageId);
    Task<PhonologicalRule> AddPhonologicalRuleAsync(PhonologicalRule rule);
    Task UpdatePhonologicalRuleAsync(PhonologicalRule rule);
    Task RemovePhonologicalRuleAsync(int ruleId);
    Task ReorderPhonologicalRulesAsync(int languageId, List<int> orderedRuleIds);

    // Romanization
    Task<List<RomanizationMapping>> GetRomanizationMappingsAsync(int languageId);
    Task SetRomanizationMappingsAsync(int languageId, List<RomanizationMapping> mappings);
}
