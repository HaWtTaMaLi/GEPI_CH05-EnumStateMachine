using UnityEngine;

public class UIManager : MonoBehaviour
{
    //UI Screen Manager

    [SerializeField] private GameObject mainMenuUI;
    [SerializeField] private GameObject gamePlayUI;
    [SerializeField] private GameObject pausedUI;

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
        pausedUI.SetActive(true);
    }

    public void HideAllUI()
    {
        mainMenuUI.SetActive(false);
        gamePlayUI.SetActive(false);
        pausedUI.SetActive(false);
    }

}
