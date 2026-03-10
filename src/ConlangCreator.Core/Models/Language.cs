namespace ConlangCreator.Core.Models;

public class Language
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string? Description { get; set; }
    public string? Endonym { get; set; } // what the language calls itself
    public int? UserId { get; set; } // nullable for now, required when multi-user is added
    public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

    // Navigation properties
    public List<Phoneme> Phonemes { get; set; } = [];
    public List<SyllableRule> SyllableRules { get; set; } = [];
    public List<PhonologicalRule> PhonologicalRules { get; set; } = [];
    public List<RomanizationMapping> RomanizationMappings { get; set; } = [];
}
