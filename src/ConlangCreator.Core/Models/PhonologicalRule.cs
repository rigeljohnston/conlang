namespace ConlangCreator.Core.Models;

public class PhonologicalRule
{
    public int Id { get; set; }
    public int LanguageId { get; set; }

    /// <summary>
    /// Human-readable name for the rule (e.g., "Palatalization before front vowels").
    /// </summary>
    public string Name { get; set; } = string.Empty;

    /// <summary>
    /// The input phoneme or pattern (IPA).
    /// </summary>
    public string Input { get; set; } = string.Empty;

    /// <summary>
    /// The output phoneme or pattern (IPA).
    /// </summary>
    public string Output { get; set; } = string.Empty;

    /// <summary>
    /// The environment/context where the rule applies.
    /// Uses standard notation: _V = before a vowel, V_ = after a vowel,
    /// #_ = word-initial, _# = word-final, etc.
    /// </summary>
    public string? Environment { get; set; }

    /// <summary>
    /// Order in which rules are applied (lower = earlier).
    /// </summary>
    public int Order { get; set; }

    /// <summary>
    /// Whether the rule is currently active/enabled.
    /// </summary>
    public bool IsActive { get; set; } = true;

    public string? Notes { get; set; }

    // Navigation
    public Language Language { get; set; } = null!;
}
