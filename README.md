Project based on Marvel Snap done in Unity to prove my code architecture knowledge.

Patterns Used:

Observer Pattern:
The GameManager class utilizes the Observer pattern through the use of UnityEvents. These events (UpdateEnergy, UpdateHands, ChangeTurnTo, CardPlayed, and BoardChanged) act as subjects, and other classes (like ControllerViaUI) subscribe to these events to get notified when certain game events occur.

Command Pattern (Partial):
The methods like TryPlayCardBy, PlayerEndedTurn, and event handlers in ControllerViaUI can be considered as following the Command pattern. These methods encapsulate actions that can be invoked by different objects, providing a clear separation between the sender (invoker) and the receiver.

Factory Method Pattern (Partial):
The instantiation of CardPrefab in ControllerViaUI's UpdateHand method can be seen as a form of a Factory Method pattern. It encapsulates the creation of objects, allowing subclasses (CardManager instances) to alter the type of objects created.

MVC (Model-View-Controller) Architecture (Partial):
The GameManager class can be seen as part of the Model, holding the game state and logic. The ControllerViaUI class serves as part of the Controller, handling user input and updating the UI. The UI elements themselves (like TextMeshProUGUI) can be considered part of the View.

Event-driven Programming:
The entire system relies heavily on events to notify and handle changes in the game state. Unity's event system is used to decouple different components and systems, promoting a more modular and maintainable design.
