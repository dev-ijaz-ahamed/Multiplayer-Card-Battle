Multiplayer Card Game – Technical Documentation
Author: Ijaz
Engine: Unity (3D)
Networking: Photon PUN 2
Platform: Android

Project Overview:
The Multiplayer Card Game is a real-time online 1v1 game where two players draw, swap, and place cards on separate board zones.
Each player views their own Green Zone (My Board) and the opponent’s Red Zone (Opponent Board).

The game uses event-driven messages and JSON-based networking to sync actions between players.

Tools & Technologies Used:
Unity 6.000+
2D gameplay
Prefab-based card system
UI system for player panels, deck zones, timers
Coroutines for timers & animations
Scriptable Objects for storing card data
Networking
Photon PUN 2

Used for:
Real-time multiplayer
Room creation & joining
Player identity (ActorNumber)
Remote Procedure Calls (RPCs)
Custom Properties for synced data
PhotonNetwork.Time for synchronized countdown timer

Networking Approach:
✔ JSON-based messages
✔ All network messages include "action"
✔ No raw primitives in RPC (recommended design)

Example Message:

{
  "action": "swapCard",
  "senderID": 1,
  "cardID": "K03",
  "cardName": "King",
  "cardPower": "8"
}


Card System Cards are represented as:
ScriptableObject (data)
Prefab (visual)

Each card contains:
public string cardID;
public string cardName;
public int cardCost;
public int cardPower;
public Sprite cardImage;


Each player has 2 main zones:
Green Zone
Player’s own active board
Cards placed here belong to current player
Red Zone
Shows opponent’s cards
Mirror of opponent’s Green Zone
Each swap/spawn action positions cards based on:
If I performed action → spawn in my Green Zone
If opponent performed action → spawn in my Red Zone.
