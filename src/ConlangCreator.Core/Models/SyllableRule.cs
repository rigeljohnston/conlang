namespace ConlangCreator.Core.Models;

public class SyllableRule
{
    public int Id { get; set; }
    public int LanguageId { get; set; }

    /// <summary>
    /// Syllable template using C (consonant) and V (vowel) notation.
    /// Examples: "CV", "CVC", "CCVC", "CVCC"
    /// Parentheses denote optional: "(C)V(C)" means onset and coda are optional.
    /// </summary>
    public string Template { get; set; } = string.Empty;

    /// <summary>
    /// Whether this is the most common/default syllable structure.
    /// </summary>
    public bool IsDefault { get; set; }

    /// <summary>
    /// Relative frequency weight for generation (higher = more common).
    /// </summary>
    public int Weight { get; set; } = 1;

    /// <summary>
    /// Optional comma-separated list of allowed onset clusters (e.g., "st,sk,sp,tr,kr").
    /// If null, all phonotactically valid combinations are allowed.
    /// </summary>
    public string? AllowedOnsets { get; set; }

    /// <summary>
    /// Optional comma-separated list of allowed coda clusters.
    /// </summary>
    public string? AllowedCodas { get; set; }

    public string? Notes { get; set; }

    // Navigation
    public Language Language { get; set; } = null!;
}
