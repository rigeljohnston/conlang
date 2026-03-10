namespace ConlangCreator.Core.Models;

public class Phoneme
{
    public int Id { get; set; }
    public int LanguageId { get; set; }
    public string IpaSymbol { get; set; } = string.Empty;
    public PhonemeType Type { get; set; }

    // Consonant features
    public PlaceOfArticulation? Place { get; set; }
    public MannerOfArticulation? Manner { get; set; }
    public bool? IsVoiced { get; set; }

    // Vowel features
    public VowelHeight? Height { get; set; }
    public VowelBackness? Backness { get; set; }
    public bool? IsRounded { get; set; }

    // Shared
    public bool IsNasal { get; set; }
    public string? Notes { get; set; }

    // Navigation
    public Language Language { get; set; } = null!;
    public List<RomanizationMapping> RomanizationMappings { get; set; } = [];
}

public enum PhonemeType
{
    Consonant,
    Vowel
}

public enum PlaceOfArticulation
{
    Bilabial,
    Labiodental,
    Dental,
    Alveolar,
    Postalveolar,
    Retroflex,
    Palatal,
    Velar,
    Uvular,
    Pharyngeal,
    Glottal
}

public enum MannerOfArticulation
{
    Plosive,
    Nasal,
    Trill,
    TapFlap,
    Fricative,
    LateralFricative,
    Approximant,
    LateralApproximant,
    Affricate
}

public enum VowelHeight
{
    Close,
    NearClose,
    CloseMid,
    Mid,
    OpenMid,
    NearOpen,
    Open
}

public enum VowelBackness
{
    Front,
    Central,
    Back
}
