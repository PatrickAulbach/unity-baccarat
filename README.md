# Baccarat Unity Project

This is a Unity project that implements the game of Baccarat. The game is a popular casino game that involves betting on the outcome of two hands of cards, the player's hand and the banker's hand.
Here you can play the game https://patrickaulbach.github.io/unity-baccarat/Build/index.html

## Getting Started

To run this project, you will need Unity installed on your computer. You can download Unity from the [official Unity website](https://unity.com/).

Once you have Unity installed, you can open the project by following these steps:

1. Clone the repository to your local machine.
2. Download the card assets from https://cazwolf.itch.io/pixel-fantasy-cards and add them to the `Assets/Textures/Cards` folder. Note that the card assets are not included in this project and must be downloaded separately.
3. Open Unity and click on "Open Project".
4. Navigate to the directory where you cloned the repository and select the "Baccarat" folder.
5. Add the sprite names, card values, and card types to the deck GameObject in the Unity editor. To do this, select the Deck GameObject in the Hierarchy window and add sprite, card value and card type for each card you want to add to the deck.

Alternatively, you can use any other card assets that you prefer by replacing the card textures in the `Assets/Textures/Cards` folder.

## Audio
The audio in the game only consist of one song from the unity asset store. I don't wanted to spend more time with audio tracks because I wanted to move on to the next project. Maybe in the future I will add appropriate sounds.

## Playing the Game

To play the game, simply run the project in Unity and click on the "Play" button in the Unity editor. The game will start and you can place your bets by dragging and dropping the chips into the betting areas.

You can bet on the following outcomes:

- Player
- Banker
- Tie
- Banker Pair
- Player Pair

After you have placed your bets, click on the "Deal" button to deal the cards. The game will automatically determine the outcome and pay out any winnings.

## Project Structure

The project is organized into several folders:

- **Assets**: Contains all the assets for the game, including 3D models, textures, and scripts.
  - **Textures/Cards**: Contains the card assets used in the game.
- **Scenes**: Contains the main scene for the game, where the gameplay takes place.
- **Scripts**: Contains all the scripts for the game, including scripts for handling the gameplay, user interface, and sound effects.

## Credits
The cards used in this game were created by Caz. You can download the Assets from https://cazwolf.itch.io/pixel-fantasy-cards.

## License

This project is licensed under the MIT License. See the [LICENSE](LICENSE) file for more details.
