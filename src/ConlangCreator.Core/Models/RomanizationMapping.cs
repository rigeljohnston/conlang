namespace ConlangCreator.Core.Models;

public class RomanizationMapping
{
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public int PhonemeId { get; set; }

    /// <summary>
    /// The Latin-script representation of this phoneme.
    /// </summary>
    public string Romanization { get; set; } = string.Empty;

    /// <summary>
    /// Whether this is the primary romanization (a phoneme might have context-dependent spellings).
    /// </summary>
    public bool IsPrimary { get; set; } = true;

    /// <summary>
    /// Optional context description for non-primary romanizations
    /// (e.g., "before front vowels", "word-finally").
    /// </summary>
    public string? Context { get; set; }

    // Navigation
    public Language Language { get; set; } = null!;
    public Phoneme Phoneme { get; set; } = null!;
}
