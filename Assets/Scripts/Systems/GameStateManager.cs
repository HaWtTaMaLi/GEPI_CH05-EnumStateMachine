using UnityEngine;
using UnityEngine.UI;

public enum GameState
{
    None,
    Init,
    MainMenu,
    GamePlay,
    Paused,
    Options,
    GameOver
}

public class GameStateManager : MonoBehaviour
{
    public UIManager uiManager;
    public GameState currentState { get; private set; }

    public GameState previouseState { get; private set; }

    [Header("Debug (read only)")]
    [SerializeField] private string currentActiveState;
    [SerializeField] private string previousActiveState;

    private void Start()
    {
        //set initial state
        SetState(GameState.Init);
        uiManager = ServiceHub.Instance.uiManager;
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

                //do Init stuff
                SetState(GameState.MainMenu);
                return;

            case GameState.MainMenu:
                Debug.Log("Game State Changed to Main Menu");

                //do main menu stuff
                uiManager.ShowMainMenuUI();
                return;

            case GameState.GamePlay:
                Debug.Log("Game State Changed to Game Play");

                //do game play stuff
                SetState(GameState.GamePlay);
                uiManager.ShowGamePlayUI();
                return;

            case GameState.Paused:
                Debug.Log("Game State Changed to Paused");

                //do paused stuff
                uiManager.ShowPausedUI();
                return;

            case GameState.Options:
                Debug.Log("Game State Changed to Options");

                //do options stuff
                uiManager.ShowOptionsUI();
                return;

            case GameState.GameOver:
                Debug.Log("Game State Changed to Game Over");

                //do game over stuff
                uiManager.ShowGameOverUI();
                return;
        }
    }

    //Button Logic
    public void StartGame()
    {
        SetState(GameState.GamePlay);
    }

    public void OpenOptions()
    {
        SetState(GameState.Options);
    }

    public void ReturnToMainMenu()
    {
        SetState(GameState.MainMenu);
    }

    public void TogglePause()
    {
        if (currentState == GameState.GamePlay)
        {
            //ignore if in game play
            if (currentState == GameState.Paused) return;
            //resume
            SetState(GameState.Paused);
        }
        else if (currentState == GameState.Paused)
        {
            //ignore if paused
            if (currentState == GameState.GamePlay) return;
            //pause
            SetState(GameState.GamePlay);
        }
    }

    public void ToggleGameOver()
    {
        Debug.Log("Toggling Game Over");
        
        if (currentState == GameState.GamePlay)
        {
            SetState(GameState.GameOver);
        }
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(currentState == GameState.GamePlay)
            {
                Debug.Log("Toggling Pause");
                TogglePause();
            }
            else
            {
                Debug.Log("Returning to previous state from options");
                SetState(previouseState);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            ToggleGameOver();
        }
    }
}
