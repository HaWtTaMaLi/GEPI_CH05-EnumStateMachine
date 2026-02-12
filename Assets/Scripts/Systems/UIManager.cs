using UnityEngine;

public class UIManager : MonoBehaviour
{
    //UI Screen Manager

    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject gamePlayUI;
    [SerializeField] private GameObject pausedUI;
    [SerializeField] private GameObject optionsUI;
    [SerializeField] private GameObject gameOverUI;

    public void ShowMainMenuUI()
    {
        HideAllUI();
        mainMenuUI.SetActive(true);
    }

    public void ShowGamePlayUI()
    {
        HideAllUI();
        gamePlayUI.SetActive(true);
    }

    public void ShowPausedUI()
    {
        HideAllUI();
        gamePlayUI.SetActive(true); //keep the game play UI active in the background
        pausedUI.SetActive(true); 
    }

    public void ShowOptionsUI()
    {
        HideAllUI();
        optionsUI.SetActive(true);
    }

    public void ShowGameOverUI()
    {
        HideAllUI();
        gameOverUI.SetActive(true);
    }

    public void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        gamePlayUI.SetActive(false);
        pausedUI.SetActive(false);
        optionsUI.SetActive(false);
        gameOverUI.SetActive(false);
    }
}
