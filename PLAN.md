# Conlang Creator - Application Plan

## Overview

A web application for creating constructed languages (conlangs) from scratch.
Built with **ASP.NET + Blazor** (Server-side initially, with option to move to WASM).
Starts as a **personal tool**, architected for **multi-user support** later.

---

## Tech Stack

| Layer | Technology |
|-------|-----------|
| Frontend | Blazor Server (C# / Razor components) |
| Backend | ASP.NET Core 8 Web API |
| Database | SQLite (dev) → PostgreSQL (production) |
| ORM | Entity Framework Core |
| Audio | IPA-based TTS library (eSpeak-ng or similar) |
| Export | QuestPDF / HTML templates for grammar docs |

### Project Structure

```
conlang/
├── src/
│   ├── ConlangCreator.Web/          # Blazor Server app (UI + pages)
│   ├── ConlangCreator.Core/         # Domain models, interfaces, business logic
│   ├── ConlangCreator.Engine/       # Generation algorithms, grammar engine, phonology engine
│   └── ConlangCreator.Data/         # EF Core DbContext, migrations, repositories
├── tests/
│   ├── ConlangCreator.Core.Tests/
│   └── ConlangCreator.Engine.Tests/
├── conlang_kernel/                  # Existing reference files (verb tenses, etc.)
└── PLAN.md
```

---

## Architecture Principles

1. **Repository pattern** with interfaces in Core, implementations in Data — enables SQLite↔Postgres swap
2. **Service layer** in Core for business logic, decoupled from UI
3. **Engine library** is pure logic with no DB dependencies — testable in isolation
4. **Multi-user ready**: All entities have a `UserId` foreign key from day one (nullable for now)
5. **Modular dashboard UI**: Each linguistic layer is an independent Blazor component/page

---

## Phase 1: Foundation & Phonology

### 1.1 Project Scaffolding
- Create the solution structure (4 projects + 2 test projects)
- Set up EF Core with SQLite provider
- Configure DI, middleware, basic layout
- Create the dashboard shell with navigation sidebar

### 1.2 Core Domain Models
- `Language` — top-level entity (name, description, metadata, timestamps)
- `Phoneme` — individual sound (IPA symbol, type: consonant/vowel, features)
- `PhonemeInventory` — a language's set of phonemes
- `SyllableRule` — syllable structure templates (e.g., CVC, CCVC)
- `PhonologicalRule` — sound change / allophony rules
- `RomanizationMapping` — IPA ↔ Latin character mappings

### 1.3 Phonology Module (UI)
- **Phoneme Inventory Builder**: Interactive IPA chart where you click to select consonants and vowels
- **Phonotactics Editor**: Define syllable templates, allowed onset/coda clusters, stress rules
- **Sound Change Rules**: Define ordered rules (e.g., /k/ → [tʃ] before front vowels)
- **Romanization Table**: Map each phoneme to a Latin-script representation
- **Tone System** (optional toggle): Define tone inventory and tone sandhi rules

---

## Phase 2: Morphology

### 2.1 Domain Models
- `MorphemeSlot` — a position in a word template (prefix, suffix, infix, root)
- `Morpheme` — an affix or root with phonological form and meaning
- `WordTemplate` — ordered sequence of morpheme slots for a part of speech
- `ConjugationParadigm` — tense/aspect/mood/person/number grid for verbs
- `DeclensionParadigm` — case/number/gender grid for nouns
- `DerivationalRule` — rules for deriving new words (e.g., verb → noun via suffix)

### 2.2 Morphology Module (UI)
- **Word Template Designer**: Visual slot editor — drag morpheme slots to define word structure for each part of speech
- **Verb Conjugation Builder**: Grid editor for tense × person × number (import existing infix system from `conlang_kernel/`)
- **Noun Declension Builder**: Grid editor for case × number × gender/class
- **Adjective/Adverb Morphology**: Agreement rules, comparison forms
- **Pronoun System**: Define pronoun paradigms (personal, demonstrative, relative, etc.)
- **Derivational Morphology**: Define rules to create new words from roots (nominalization, verbalization, etc.)

---

## Phase 3: Lexicon & Word Generation

### 3.1 Domain Models
- `Root` — base form with semantic category
- `LexiconEntry` — a word: root + derived form + part of speech + gloss + notes
- `SemanticCategory` — grouping (body, nature, kinship, emotion, etc.)
- `GenerationAlgorithm` — saved configuration for word generation
- `GenerationConstraint` — phonotactic or aesthetic constraints for generated words

### 3.2 Word Generation Engine
This is the core creative engine. Supports a **pipeline of transforms**:

#### Generation Modes
1. **Fully Random**: Generate random phoneme sequences respecting phonotactic rules
2. **Constrained Random**: Random generation with user-defined constraints (max length, required patterns, forbidden clusters, "feel" parameters)
3. **Deterministic Transform**: Take input words (e.g., English) and transform through a configurable pipeline:
   - Character substitution (Caesar cipher, custom mapping tables)
   - Vowel/consonant harmony adjustments
   - Cluster simplification to match target phonotactics
   - Syllable restructuring
   - Stress-based modifications
4. **Root-List Import**: Import root lists from natural languages (Swadesh lists, frequency lists) and batch-transform them
5. **Hybrid**: Combine any of the above — e.g., start from Latin roots, transform, then randomize affixes

#### Pipeline Architecture
```
Input Source → [Transform 1] → [Transform 2] → ... → [Constraint Filter] → Output
```
Each transform is a pluggable C# class implementing `IWordTransform`:
- `CaesarCipherTransform`
- `PhonemeSubstitutionTransform`
- `ClusterSimplificationTransform`
- `SyllableRestructureTransform`
- `VowelHarmonyTransform`
- `RandomMutationTransform`
- Custom user-defined transforms (expression-based)

### 3.3 Lexicon Module (UI)
- **Dictionary View**: Searchable, filterable table of all words
- **Root Explorer**: View root families and their derived forms
- **Word Generator**: Configure and run generation algorithms
  - Select generation mode
  - Build transform pipeline (drag-and-drop ordering)
  - Set constraints
  - Preview generated words, accept/reject individually or in batch
- **Import/Export**: CSV, JSON import of word lists; export full lexicon

---

## Phase 4: Syntax & Grammar Engine

### 4.1 Domain Models
- `WordOrder` — basic constituent order (SOV, SVO, VSO, etc.) + head-directionality
- `PhraseStructureRule` — context-free grammar rules (S → NP VP, NP → Det N, etc.)
- `AgreementRule` — subject-verb agreement, noun-adjective agreement, etc.
- `TransformationRule` — syntactic transformations (question formation, passivization, relativization)
- `ClauseType` — declarative, interrogative, imperative, conditional, relative, etc.

### 4.2 Grammar Engine
- **Parser**: Takes a sentence template and validates it against phrase structure rules
- **Generator**: Produces grammatical sentences from semantic input
- **Agreement Resolver**: Applies agreement rules across constituents
- **Clause Combiner**: Handles subordination, coordination, embedding

### 4.3 Syntax Module (UI)
- **Word Order Configurator**: Set basic typological parameters
- **Phrase Structure Editor**: Visual rule editor with tree preview
- **Agreement Rules Table**: Define which features must agree between which constituents
- **Clause Type Templates**: Configure how each clause type differs (e.g., question = verb-fronting)
- **Sentence Playground**: Type a structure, see it expanded into a full conlang sentence with glossing

---

## Phase 5: Translation & Glossing

### 5.1 Translation Module
- **Interlinear Glossing**: Break down conlang sentences into morphemes with aligned translations
- **English → Conlang**: Basic translation using lexicon lookup + grammar rules
  - Handle word order transformation
  - Apply morphological rules to produce correct inflected forms
  - Flag untranslatable concepts (missing vocabulary)
- **Gloss Format**: Support Leipzig glossing conventions

### 5.2 UI
- **Translation Workspace**: Side-by-side input/output with interlinear gloss between
- **Missing Word Suggestions**: When a word is missing, offer to generate one on the spot

---

## Phase 6: Audio & Phonetic Output

### 6.1 Text-to-Speech
- Map romanized text → IPA → audio using eSpeak-ng (or similar)
- Per-language pronunciation rules
- Playback controls in the UI (play word, play sentence)

### 6.2 UI
- Speaker icon buttons on dictionary entries and translation output
- Bulk pronunciation preview for generated word batches

---

## Phase 7: Import/Export & Version History

### 7.1 Export Formats
- **Grammar Reference**: Generate a formatted grammar document (PDF/HTML) covering all defined rules
- **Lexicon Export**: CSV, JSON, or PDF dictionary
- **Full Language Export**: JSON bundle of the entire language definition (for backup/sharing)

### 7.2 Version History
- Snapshot-based versioning: Save named snapshots of a language at any point
- Diff view: Compare two snapshots to see what changed
- Rollback: Restore a previous snapshot
- Implementation: Store serialized language state as JSON blobs with timestamps

### 7.3 Import
- Import word lists (CSV with columns: word, gloss, POS, category)
- Import full language definitions (JSON bundle)
- Import natural language root lists for word generation

---

## Phase 8: Multi-User Preparation

### 8.1 Authentication
- Add ASP.NET Core Identity
- Individual user accounts with language ownership
- Switch from nullable `UserId` to required FK

### 8.2 Data Isolation
- Repository layer filters all queries by authenticated user
- Sharing: Optional read-only sharing of languages via link

### 8.3 Database Migration
- Swap SQLite provider for Npgsql (PostgreSQL)
- Run EF Core migrations

---

## Implementation Priority & Milestones

| Milestone | Phases | What You Get |
|-----------|--------|-------------|
| **M1: Foundations** | 1.1, 1.2, 1.3 | Working app with phonology module |
| **M2: Word Structure** | 2.1, 2.2 | Full morphological system, verb/noun paradigms |
| **M3: Living Lexicon** | 3.1, 3.2, 3.3 | Word generation pipeline + dictionary |
| **M4: Grammar** | 4.1, 4.2, 4.3 | Sentence structure and generation |
| **M5: Translation** | 5.1, 5.2 | English ↔ Conlang translation with glossing |
| **M6: Polish** | 6, 7 | Audio, export, version history |
| **M7: Scale** | 8 | Multi-user, PostgreSQL |

Each milestone is independently useful — you can start using the app after M1.

---

## Open Questions for Future Iterations

- Should the grammar engine support formal grammar formalisms (e.g., HPSG, LFG) or stay informal?
- How complex should the custom script designer be when added later?
- Should there be AI-assisted features (e.g., "suggest a phoneme inventory similar to Japanese")?
- Conlang comparison tools (compare two languages side by side)?
