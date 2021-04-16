# Unity-SemanticVersioning
Semantic versioning system within the Unity environment.

# Features
1. Major, minor, patch, pre-release and build number tracking
2. Build number increases every time you go in to play mode that way we can keep our version unique every time we add a new feature or we fix a bug.
3. Pre-release enumeration has its own commented explanations.
4. Keep that in mind that only developers/engineers can change major, minor, patch or pre-release versions. The only automation is in build number. But, when you change a versioning sequence manually versioning system responds to it downwards . How ? When you change superior sequence, minor sequence resets. For example, if you set patch version manually then pre-release and build numbers resets.
