using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class TitleUI : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject optionsMenu;

    public bool isMainMenuOpen;
    public bool isOptionsMenuOpen;

    public Button newGameButton;
    public Button exitButton;

    public Button optionsButton;
    public Button optionsButtonBack;

    private void Start()
    {
        isMainMenuOpen = true;
        isOptionsMenuOpen = false;

        ButtonFunctionality();
        ToggleUI();
    }

    public void StartNewGame()      { SceneManager.LoadScene(1); }
    public void OpenMainMenu()      { isMainMenuOpen = true; isOptionsMenuOpen = false; ToggleUI(); }
    public void OpenOptionsMenu()   { isMainMenuOpen = false; isOptionsMenuOpen = true; ToggleUI(); }
    public void ExitGame()          { Application.Quit(); }

    private void ButtonFunctionality()
    {
        optionsButton.onClick.AddListener(OpenOptionsMenu);
        optionsButtonBack.onClick.AddListener(OpenMainMenu);
    }

    private void ToggleUI()
    {
        if(isMainMenuOpen)
        {
            mainMenu.GetComponent<CanvasGroup>().alpha = 1;
            mainMenu.GetComponent<CanvasGroup>().interactable = true;
            mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            mainMenu.GetComponent<CanvasGroup>().alpha = 0;
            mainMenu.GetComponent<CanvasGroup>().interactable = false;
            mainMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
         if(isOptionsMenuOpen)
        {
            optionsMenu.GetComponent<CanvasGroup>().alpha = 1;
            optionsMenu.GetComponent<CanvasGroup>().interactable = true;
            optionsMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            optionsMenu.GetComponent<CanvasGroup>().alpha = 0;
            optionsMenu.GetComponent<CanvasGroup>().interactable = false;
            optionsMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }
}
