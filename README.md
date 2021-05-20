# Unity-SemanticVersioning
Semantic versioning system within the Unity environment.

# Features
1. Major, minor, patch, pre-release and build number tracking
2. Build number increases every time you go in to play mode that way we can keep our version unique every time we add a new feature or we fix a bug.
3. Pre-release enumeration has its own commented explanations.


## Import

1. Go to [release](https://github.com/ertanturan/Unity-SemanticVersioning/releases) page.
2. Download the lates release of the package.
3. Import it to your unity project.
4. You're set.

## Usage

### General Use
1. Head to `Assets/CustomTools/SemanticVersioning/Prefab`
2. Add the prefab to your scene.
3. Click on the added prefab in your scene hierarchy.
4. Set a textbox for auto versioner to show the current version on UI.
5. You're set.


### Increasing version number manually
1. Click to `AutoVersioner` in your scene.
2. Choose the type of release ( Visit ReleaseType enumeration for detailed information)

![Release type selection](https://i.ibb.co/YTWsYz7/version-Type.png)

3. Click on editor buttons of which type you would like to make a release of.

![Release type selection](https://i.ibb.co/gvZqC2v/buttons.png)

4. You're set.

## Notes 
1. Keep that in mind that only developers/engineers can change major, minor, patch or pre-release versions. The only automation is in build number. But, when you change a versioning sequence manually, versioning system responds to it downwards . How ? When you change superior sequence, minor sequence resets. For example, if you set patch version manually then pre-release and build numbers resets.

## Contributing
Pull requests are welcome. For major changes, please open an issue first to discuss what you would like to change.

Please make sure to update tests as appropriate.

# ENJOY !
