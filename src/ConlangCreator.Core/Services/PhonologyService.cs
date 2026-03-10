using ConlangCreator.Core.Interfaces;
using ConlangCreator.Core.Models;

namespace ConlangCreator.Core.Services;

public class PhonologyService
{
    private readonly IPhonologyRepository _phonologyRepo;

    public PhonologyService(IPhonologyRepository phonologyRepo)
    {
        _phonologyRepo = phonologyRepo;
    }

    public Task<List<Phoneme>> GetPhonemesAsync(int languageId) =>
        _phonologyRepo.GetPhonemesAsync(languageId);

    public Task<Phoneme> AddPhonemeAsync(int languageId, string ipaSymbol, PhonemeType type,
        PlaceOfArticulation? place = null, MannerOfArticulation? manner = null, bool? isVoiced = null,
        VowelHeight? height = null, VowelBackness? backness = null, bool? isRounded = null)
    {
        var phoneme = new Phoneme
        {
            LanguageId = languageId,
            IpaSymbol = ipaSymbol,
            Type = type,
            Place = place,
            Manner = manner,
            IsVoiced = isVoiced,
            Height = height,
            Backness = backness,
            IsRounded = isRounded,
        };
        return _phonologyRepo.AddPhonemeAsync(phoneme);
    }

    public Task RemovePhonemeAsync(int phonemeId) =>
        _phonologyRepo.RemovePhonemeAsync(phonemeId);

    // Syllable Rules
    public Task<List<SyllableRule>> GetSyllableRulesAsync(int languageId) =>
        _phonologyRepo.GetSyllableRulesAsync(languageId);

    public Task<SyllableRule> AddSyllableRuleAsync(int languageId, string template, bool isDefault = false, int weight = 1)
    {
        var rule = new SyllableRule
        {
            LanguageId = languageId,
            Template = template,
            IsDefault = isDefault,
            Weight = weight,
        };
        return _phonologyRepo.AddSyllableRuleAsync(rule);
    }

    public Task UpdateSyllableRuleAsync(SyllableRule rule) =>
        _phonologyRepo.UpdateSyllableRuleAsync(rule);

    public Task RemoveSyllableRuleAsync(int ruleId) =>
        _phonologyRepo.RemoveSyllableRuleAsync(ruleId);

    // Phonological Rules
    public Task<List<PhonologicalRule>> GetPhonologicalRulesAsync(int languageId) =>
        _phonologyRepo.GetPhonologicalRulesAsync(languageId);

    public Task<PhonologicalRule> AddPhonologicalRuleAsync(int languageId, string name,
        string input, string output, string? environment = null)
    {
        var rule = new PhonologicalRule
        {
            LanguageId = languageId,
            Name = name,
            Input = input,
            Output = output,
            Environment = environment,
        };
        return _phonologyRepo.AddPhonologicalRuleAsync(rule);
    }

    public Task UpdatePhonologicalRuleAsync(PhonologicalRule rule) =>
        _phonologyRepo.UpdatePhonologicalRuleAsync(rule);

    public Task RemovePhonologicalRuleAsync(int ruleId) =>
        _phonologyRepo.RemovePhonologicalRuleAsync(ruleId);

    public Task ReorderPhonologicalRulesAsync(int languageId, List<int> orderedRuleIds) =>
        _phonologyRepo.ReorderPhonologicalRulesAsync(languageId, orderedRuleIds);

    // Romanization
    public Task<List<RomanizationMapping>> GetRomanizationMappingsAsync(int languageId) =>
        _phonologyRepo.GetRomanizationMappingsAsync(languageId);

    public Task SetRomanizationMappingsAsync(int languageId, List<RomanizationMapping> mappings) =>
        _phonologyRepo.SetRomanizationMappingsAsync(languageId, mappings);
}
