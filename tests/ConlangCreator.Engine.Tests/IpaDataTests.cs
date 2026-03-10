using ConlangCreator.Core.Models;
using ConlangCreator.Engine.Phonology;

namespace ConlangCreator.Engine.Tests;

public class IpaDataTests
{
    [Fact]
    public void Consonants_ContainsExpectedCommonSounds()
    {
        Assert.True(IpaData.IsConsonant("p"));
        Assert.True(IpaData.IsConsonant("b"));
        Assert.True(IpaData.IsConsonant("t"));
        Assert.True(IpaData.IsConsonant("d"));
        Assert.True(IpaData.IsConsonant("k"));
        Assert.True(IpaData.IsConsonant("m"));
        Assert.True(IpaData.IsConsonant("n"));
        Assert.True(IpaData.IsConsonant("s"));
        Assert.True(IpaData.IsConsonant("l"));
        Assert.True(IpaData.IsConsonant("r"));
    }

    [Fact]
    public void Vowels_ContainsExpectedCommonSounds()
    {
        Assert.True(IpaData.IsVowel("a"));
        Assert.True(IpaData.IsVowel("e"));
        Assert.True(IpaData.IsVowel("i"));
        Assert.True(IpaData.IsVowel("o"));
        Assert.True(IpaData.IsVowel("u"));
    }

    [Fact]
    public void FindConsonant_ReturnsCorrectFeatures()
    {
        var p = IpaData.FindConsonant("p");
        Assert.NotNull(p);
        Assert.Equal(PlaceOfArticulation.Bilabial, p.Place);
        Assert.Equal(MannerOfArticulation.Plosive, p.Manner);
        Assert.False(p.IsVoiced);

        var b = IpaData.FindConsonant("b");
        Assert.NotNull(b);
        Assert.Equal(PlaceOfArticulation.Bilabial, b.Place);
        Assert.Equal(MannerOfArticulation.Plosive, b.Manner);
        Assert.True(b.IsVoiced);
    }

    [Fact]
    public void FindVowel_ReturnsCorrectFeatures()
    {
        var a = IpaData.FindVowel("a");
        Assert.NotNull(a);
        Assert.Equal(VowelHeight.Open, a.Height);
        Assert.Equal(VowelBackness.Front, a.Backness);
        Assert.False(a.IsRounded);

        var u = IpaData.FindVowel("u");
        Assert.NotNull(u);
        Assert.Equal(VowelHeight.Close, u.Height);
        Assert.Equal(VowelBackness.Back, u.Backness);
        Assert.True(u.IsRounded);
    }

    [Fact]
    public void NonExistentSymbol_ReturnsNull()
    {
        Assert.Null(IpaData.FindConsonant("a")); // 'a' is a vowel
        Assert.Null(IpaData.FindVowel("p"));     // 'p' is a consonant
        Assert.Null(IpaData.FindConsonant("xyz"));
    }

    [Fact]
    public void AllConsonantsHaveUniqueSymbols()
    {
        var symbols = IpaData.Consonants.Select(c => c.Symbol).ToList();
        Assert.Equal(symbols.Count, symbols.Distinct().Count());
    }

    [Fact]
    public void AllVowelsHaveUniqueSymbols()
    {
        var symbols = IpaData.Vowels.Select(v => v.Symbol).ToList();
        Assert.Equal(symbols.Count, symbols.Distinct().Count());
    }
}
