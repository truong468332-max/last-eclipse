# Last Eclipse - Game Design Document

## Overview

**Last Eclipse** is a fast-paced, dark pixel action game inspired by Katana Zero with deep storytelling and moral choice mechanics.

### Core Concept

- **Setting:** Post-apocalyptic 2189
- **Event:** The Black Rain - mysterious apocalyptic event
- **Player Character:** Kai - A demon hunter with unique abilities
- **Main Theme:** "Everyone is a victim. Not all enemies are evil."

---

## Gameplay Mechanics

### One-Hit-One-Kill System

- Player dies in 1 hit
- Demons die in 1 hit
- Combat is about precision, timing, and puzzle-solving
- Each level is a self-contained puzzle
- Fail = restart level instantly

### Movement & Controls

```
WASD/Arrow Keys - Move
Space - Dash (invulnerable frames)
E - Absorb (consume nearby defeated demon)
Q - Memory Vision (see clues from absorbed memories)
Mouse Click - Attack
```

### Demon Absorption

When you defeat a demon and absorb it:
1. **Gain Power** - Different powers based on demon type
   - Feral: Speed boost
   - Alpha: Strength/damage boost
   - Ancient: Special ability unlock

2. **See Memory** - Flashback of the demon's past
   - What they were before mutation
   - How they became a demon
   - Story clues

3. **Gain Knowledge** - Affects story/choices

---

## Demons

### Feral Demons
- **State:** Mindless
- **Behavior:** Erratic, unpredictable attacks
- **Threat:** Low-medium
- **Memory:** Often fragmented, hard to understand

### Alpha Demons
- **State:** Intelligent, territorial
- **Behavior:** Strategic, leads other demons
- **Threat:** Medium-high
- **Memory:** Clear, purposeful. Often reveal plot points.

### Ancient Demons
- **State:** Primordial, nearly godlike
- **Behavior:** Slow but devastating
- **Threat:** Boss-level
- **Memory:** Deep secrets about the Black Rain

---

## Story Structure

### Act 1: Discovery
- Kai hunts demons
- First absorption reveals horror of mutation
- **Plot Twist 1:** The Black Rain wasn't natural

### Act 2: Questions
- Factions appear
- Player makes choices
- Multiple endings become possible
- **Plot Twist 2:** Kai was part of the project

### Act 3: Truth
- Final confrontation
- Choose your ending
- **Plot Twist 3:** Civilization is cyclical

---

## Factions

### Iron Dominion ⚔️
**Military Extremists**
- Goal: Total demon extermination + world control
- Ending path: EXTERMINATION (destroy all demons)
- Trust bonuses: Complete extermination missions
- Threat: Authoritarian control

### Eden Union 🧬
**Scientists**
- Goal: Cure the infection
- Ending path: FUSION (merge with demons)
- Trust bonuses: Collect biological data
- Hope: Maybe demons can be saved?

### Ash Walkers 🏜️
**Desert Survivors**
- Goal: Survive and gather resources
- Ending path: RESTART (both paths possible)
- Trust bonuses: Hunt and gather missions
- Morally gray

### Children of Void 🌀
**Nihilistic Cult**
- Goal: Accelerate world's end
- Ending path: RESTART (destroy everything)
- Trust bonuses: Cause chaos
- Ideology: New world from ashes

---

## Endings

### Ending 1: EXTERMINATION
**"Victory Without Peace"**

You work with Iron Dominion to destroy all demons.

Result:
- All demons are gone
- Humanity survives
- But the world keeps decaying
- It feels hollow
- Did you save humanity or just delay the inevitable?

### Ending 2: FUSION
**"Evolution or Abomination"**

You merge human and demon DNA.

Result:
- New hybrid species emerges
- More powerful, but changed
- Beautiful and terrible
- Kai becomes something new
- The world is transformed

### Ending 3: RESTART
**"Breaking the Cycle"**

You destroy the source of the Black Rain.

Result:
- Civilization resets
- Nature reclaims the world
- Opportunity for a new beginning
- But can humanity avoid the same mistakes?

---

## Themes

1. **Moral Ambiguity**
   - Demons are victims, not monsters
   - Humans can be monsters
   - No clear good vs evil

2. **Cyclical Nature**
   - History repeats
   - The world has ended before
   - Will it end again?

3. **Cost of Survival**
   - What are you willing to sacrifice?
   - Is humanity worth saving?
   - Can you trust the factions?

4. **Identity & Choice**
   - Kai's choices define the story
   - Your choices define who Kai becomes
   - The ending reflects your journey

---

## Art Style

### Visual Aesthetic
- Pixel art (16x16 to 32x32 sprites)
- Dark, gritty colors
- Neon radiation accents
- Minimal UI
- Environmental storytelling

### Color Scheme
```
Primary:       #2A2A2A (Ash Gray)
Accent 1:      #CC0000 (Blood Red)
Accent 2:      #00FF00 (Radioactive Green)
Accent 3:      #4A0080 (Deep Purple)
Background:    #1A1A1A (Pure Black)
Highlight:     #FFFFFF (White)
```

---

## Levels

### Level 1: Ruined City
- Tutorial area
- Low demon density
- Introduce absorption mechanic
- First memory: A human's last moments

### Level 2: Nuclear Power Plant
- Source of radiation
- Medium-high difficulty
- Alpha demons begin appearing
- **Plot Twist 1 hint:** Old technology, pre-war era

### Level 3: Subway Tunnels
- Underground bunker theme
- Claustrophobic corridors
- Mixture of demon types
- Discover faction headquarters

### Level 4: Underground Laboratory
- Secret research facility
- **Plot Twist 2 revealed:** Kai's role in the project
- Ancient Demon boss
- Faction confrontation

### Level 5: Toxic Forest
- Mutated nature
- Bio-luminescent enemies
- **Plot Twist 3 hinted:** Cyclical destruction
- Prepare for final choice

### Final: Ending Sequences (3 different)

---

## Development Roadmap

### Phase 1: Core Systems ✅
- [x] Player controller (movement, dash, attack)
- [x] Demon types and AI
- [x] Combat system (one-hit mechanics)
- [x] Absorption mechanic
- [x] Memory system
- [x] Story/dialogue framework
- [x] Faction system
- [x] Ending system

### Phase 2: Level Design
- [ ] Design 5 main levels
- [ ] Create pixel art assets
- [ ] Build environmental puzzles
- [ ] Place enemies strategically

### Phase 3: Narrative
- [ ] Write full dialogue
- [ ] Create dialogue trees
- [ ] Implement branching story
- [ ] Record/design sound effects

### Phase 4: Polish
- [ ] UI/UX design
- [ ] Particle effects
- [ ] Music composition
- [ ] Balance gameplay
- [ ] Debug and optimize

---

## Quote

> "In a world where everyone is a victim, who is the real enemy?"
> 
> The answer you find will define the ending you deserve.

---

**Last Eclipse - Where the sun never rises again.** 🖤
