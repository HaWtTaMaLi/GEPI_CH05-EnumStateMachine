using UnityEngine;

public enum GameState
{
    None,
    Init,
    MainMenu,
    GamePlay,
    Paused
}

public class GameStateManager : MonoBehaviour
{
    public GameState currentState { get; private set; }

    public GameState previouseState { get; private set; }

    [Header("Debug (read only)")]
    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;

    private void Start()
    {
        //set initial state
        SetState(GameState.Init);
    }

    public void SetState(GameState newState)
    {
        //
        if (currentState == newState) return;

        //1. set previousState to current state
        //2. set currentState to new state
        previouseState = currentState;
        currentState = newState;

        //update debug strings  
        //3. set currentActiveState, convert to string
        //4. set previoiusActiveState, convert to string
        previousActiveState = previouseState.ToString();
        currentActiveState = currentState.ToString();

        //tell the game state manager to process what need to happen 
        OnGameStateChanged(previouseState, currentState);
    }

    private void OnGameStateChanged(GameState previousState, GameState newState)
    {
        switch (newState)
        {
            case GameState.None:
                Debug.Log("Why are you here??");
                return;

            case GameState.Init:
                Debug.Log("Game State Changed to Init");
                SetState(GameState.MainMenu);
                //do Init stuff
                return;

            case GameState.MainMenu:
                Debug.Log("Game State Changed to Main Menu");
                
                //do main menu stuff
                return;

            case GameState.GamePlay:
                Debug.Log("Game State Changed to Game Play");
                
                //do game play stuff
                return;

            case GameState.Paused:
                Debug.Log("Game State Changed to Paused");
                
                //do paused stuff
                return;
        }
    }

}
