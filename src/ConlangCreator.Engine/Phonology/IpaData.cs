using ConlangCreator.Core.Models;

namespace ConlangCreator.Engine.Phonology;

/// <summary>
/// Static reference data for the IPA consonant and vowel charts.
/// Used by the engine for validation and generation.
/// </summary>
public static class IpaData
{
    public record ConsonantInfo(string Symbol, PlaceOfArticulation Place, MannerOfArticulation Manner, bool IsVoiced);
    public record VowelInfo(string Symbol, VowelHeight Height, VowelBackness Backness, bool IsRounded);

    public static readonly ConsonantInfo[] Consonants =
    [
        // Plosives
        new("p", PlaceOfArticulation.Bilabial, MannerOfArticulation.Plosive, false),
        new("b", PlaceOfArticulation.Bilabial, MannerOfArticulation.Plosive, true),
        new("t", PlaceOfArticulation.Alveolar, MannerOfArticulation.Plosive, false),
        new("d", PlaceOfArticulation.Alveolar, MannerOfArticulation.Plosive, true),
        new("ʈ", PlaceOfArticulation.Retroflex, MannerOfArticulation.Plosive, false),
        new("ɖ", PlaceOfArticulation.Retroflex, MannerOfArticulation.Plosive, true),
        new("c", PlaceOfArticulation.Palatal, MannerOfArticulation.Plosive, false),
        new("ɟ", PlaceOfArticulation.Palatal, MannerOfArticulation.Plosive, true),
        new("k", PlaceOfArticulation.Velar, MannerOfArticulation.Plosive, false),
        new("ɡ", PlaceOfArticulation.Velar, MannerOfArticulation.Plosive, true),
        new("q", PlaceOfArticulation.Uvular, MannerOfArticulation.Plosive, false),
        new("ɢ", PlaceOfArticulation.Uvular, MannerOfArticulation.Plosive, true),
        new("ʔ", PlaceOfArticulation.Glottal, MannerOfArticulation.Plosive, false),
        // Nasals
        new("m", PlaceOfArticulation.Bilabial, MannerOfArticulation.Nasal, true),
        new("ɱ", PlaceOfArticulation.Labiodental, MannerOfArticulation.Nasal, true),
        new("n", PlaceOfArticulation.Alveolar, MannerOfArticulation.Nasal, true),
        new("ɳ", PlaceOfArticulation.Retroflex, MannerOfArticulation.Nasal, true),
        new("ɲ", PlaceOfArticulation.Palatal, MannerOfArticulation.Nasal, true),
        new("ŋ", PlaceOfArticulation.Velar, MannerOfArticulation.Nasal, true),
        new("ɴ", PlaceOfArticulation.Uvular, MannerOfArticulation.Nasal, true),
        // Fricatives
        new("ɸ", PlaceOfArticulation.Bilabial, MannerOfArticulation.Fricative, false),
        new("β", PlaceOfArticulation.Bilabial, MannerOfArticulation.Fricative, true),
        new("f", PlaceOfArticulation.Labiodental, MannerOfArticulation.Fricative, false),
        new("v", PlaceOfArticulation.Labiodental, MannerOfArticulation.Fricative, true),
        new("θ", PlaceOfArticulation.Dental, MannerOfArticulation.Fricative, false),
        new("ð", PlaceOfArticulation.Dental, MannerOfArticulation.Fricative, true),
        new("s", PlaceOfArticulation.Alveolar, MannerOfArticulation.Fricative, false),
        new("z", PlaceOfArticulation.Alveolar, MannerOfArticulation.Fricative, true),
        new("ʃ", PlaceOfArticulation.Postalveolar, MannerOfArticulation.Fricative, false),
        new("ʒ", PlaceOfArticulation.Postalveolar, MannerOfArticulation.Fricative, true),
        new("ʂ", PlaceOfArticulation.Retroflex, MannerOfArticulation.Fricative, false),
        new("ʐ", PlaceOfArticulation.Retroflex, MannerOfArticulation.Fricative, true),
        new("ç", PlaceOfArticulation.Palatal, MannerOfArticulation.Fricative, false),
        new("ʝ", PlaceOfArticulation.Palatal, MannerOfArticulation.Fricative, true),
        new("x", PlaceOfArticulation.Velar, MannerOfArticulation.Fricative, false),
        new("ɣ", PlaceOfArticulation.Velar, MannerOfArticulation.Fricative, true),
        new("χ", PlaceOfArticulation.Uvular, MannerOfArticulation.Fricative, false),
        new("ʁ", PlaceOfArticulation.Uvular, MannerOfArticulation.Fricative, true),
        new("ħ", PlaceOfArticulation.Pharyngeal, MannerOfArticulation.Fricative, false),
        new("ʕ", PlaceOfArticulation.Pharyngeal, MannerOfArticulation.Fricative, true),
        new("h", PlaceOfArticulation.Glottal, MannerOfArticulation.Fricative, false),
        new("ɦ", PlaceOfArticulation.Glottal, MannerOfArticulation.Fricative, true),
        // Approximants
        new("ʋ", PlaceOfArticulation.Labiodental, MannerOfArticulation.Approximant, true),
        new("ɹ", PlaceOfArticulation.Alveolar, MannerOfArticulation.Approximant, true),
        new("ɻ", PlaceOfArticulation.Retroflex, MannerOfArticulation.Approximant, true),
        new("j", PlaceOfArticulation.Palatal, MannerOfArticulation.Approximant, true),
        new("ɰ", PlaceOfArticulation.Velar, MannerOfArticulation.Approximant, true),
        // Laterals
        new("l", PlaceOfArticulation.Alveolar, MannerOfArticulation.LateralApproximant, true),
        new("ɭ", PlaceOfArticulation.Retroflex, MannerOfArticulation.LateralApproximant, true),
        new("ʎ", PlaceOfArticulation.Palatal, MannerOfArticulation.LateralApproximant, true),
        new("ʟ", PlaceOfArticulation.Velar, MannerOfArticulation.LateralApproximant, true),
        // Trills
        new("ʙ", PlaceOfArticulation.Bilabial, MannerOfArticulation.Trill, true),
        new("r", PlaceOfArticulation.Alveolar, MannerOfArticulation.Trill, true),
        new("ʀ", PlaceOfArticulation.Uvular, MannerOfArticulation.Trill, true),
        // Taps
        new("ⱱ", PlaceOfArticulation.Labiodental, MannerOfArticulation.TapFlap, true),
        new("ɾ", PlaceOfArticulation.Alveolar, MannerOfArticulation.TapFlap, true),
        new("ɽ", PlaceOfArticulation.Retroflex, MannerOfArticulation.TapFlap, true),
        // Lateral Fricatives
        new("ɬ", PlaceOfArticulation.Alveolar, MannerOfArticulation.LateralFricative, false),
        new("ɮ", PlaceOfArticulation.Alveolar, MannerOfArticulation.LateralFricative, true),
        // Affricates
        new("t͡s", PlaceOfArticulation.Alveolar, MannerOfArticulation.Affricate, false),
        new("d͡z", PlaceOfArticulation.Alveolar, MannerOfArticulation.Affricate, true),
        new("t͡ʃ", PlaceOfArticulation.Postalveolar, MannerOfArticulation.Affricate, false),
        new("d͡ʒ", PlaceOfArticulation.Postalveolar, MannerOfArticulation.Affricate, true),
    ];

    public static readonly VowelInfo[] Vowels =
    [
        new("i", VowelHeight.Close, VowelBackness.Front, false),
        new("y", VowelHeight.Close, VowelBackness.Front, true),
        new("ɨ", VowelHeight.Close, VowelBackness.Central, false),
        new("ʉ", VowelHeight.Close, VowelBackness.Central, true),
        new("ɯ", VowelHeight.Close, VowelBackness.Back, false),
        new("u", VowelHeight.Close, VowelBackness.Back, true),
        new("ɪ", VowelHeight.NearClose, VowelBackness.Front, false),
        new("ʏ", VowelHeight.NearClose, VowelBackness.Front, true),
        new("ʊ", VowelHeight.NearClose, VowelBackness.Back, true),
        new("e", VowelHeight.CloseMid, VowelBackness.Front, false),
        new("ø", VowelHeight.CloseMid, VowelBackness.Front, true),
        new("ɘ", VowelHeight.CloseMid, VowelBackness.Central, false),
        new("ɵ", VowelHeight.CloseMid, VowelBackness.Central, true),
        new("ɤ", VowelHeight.CloseMid, VowelBackness.Back, false),
        new("o", VowelHeight.CloseMid, VowelBackness.Back, true),
        new("ə", VowelHeight.Mid, VowelBackness.Central, false),
        new("ɛ", VowelHeight.OpenMid, VowelBackness.Front, false),
        new("œ", VowelHeight.OpenMid, VowelBackness.Front, true),
        new("ɜ", VowelHeight.OpenMid, VowelBackness.Central, false),
        new("ɞ", VowelHeight.OpenMid, VowelBackness.Central, true),
        new("ʌ", VowelHeight.OpenMid, VowelBackness.Back, false),
        new("ɔ", VowelHeight.OpenMid, VowelBackness.Back, true),
        new("æ", VowelHeight.NearOpen, VowelBackness.Front, false),
        new("ɐ", VowelHeight.NearOpen, VowelBackness.Central, false),
        new("a", VowelHeight.Open, VowelBackness.Front, false),
        new("ɶ", VowelHeight.Open, VowelBackness.Front, true),
        new("ɑ", VowelHeight.Open, VowelBackness.Back, false),
        new("ɒ", VowelHeight.Open, VowelBackness.Back, true),
    ];

    public static ConsonantInfo? FindConsonant(string symbol) =>
        Consonants.FirstOrDefault(c => c.Symbol == symbol);

    public static VowelInfo? FindVowel(string symbol) =>
        Vowels.FirstOrDefault(v => v.Symbol == symbol);

    public static bool IsConsonant(string symbol) => FindConsonant(symbol) is not null;
    public static bool IsVowel(string symbol) => FindVowel(symbol) is not null;
}
