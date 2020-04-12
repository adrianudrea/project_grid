using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class OptionsUI : MonoBehaviour
{
    [Header("Components")]
    public GameObject gameMenu;
    public GameObject videoMenu;
    public GameObject audioMenu;
    [Header("Bools")]
    public bool isGameMenuOpen;
    public bool isVideoMenuOpen;
    public bool isAudioMenuOpen;
    [Header("Buttons")]
    public Button backButton;
    public Button gameButton;
    public Button videoButton;
    public Button audioButton;

    private void Start()
    {
        isGameMenuOpen = true;
        isVideoMenuOpen = false;
        isAudioMenuOpen = false;

        ButtonFunctionality();
        ToggleUI();
    }

    public void ExitButton()    { SceneManager.LoadScene(0); }
    public void OpenGameMenu()  { isGameMenuOpen = true; isVideoMenuOpen = false; isAudioMenuOpen = false; ToggleUI(); }
    public void OpenVideoMenu() { isGameMenuOpen = false; isVideoMenuOpen = true; isAudioMenuOpen = false; ToggleUI(); }
    public void OpenAudioMenu() { isGameMenuOpen = false; isVideoMenuOpen = false; isAudioMenuOpen = true; ToggleUI(); }

    public void ButtonFunctionality()
    {
        //backButton.onClick.AddListener();
        gameButton.onClick.AddListener(OpenGameMenu);
        videoButton.onClick.AddListener(OpenVideoMenu);
        audioButton.onClick.AddListener(OpenAudioMenu);
    }

    private void ToggleUI()
    {
        if(isGameMenuOpen)
        {
            gameMenu.GetComponent<CanvasGroup>().alpha = 1;
            gameMenu.GetComponent<CanvasGroup>().interactable = true;
            gameMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            gameMenu.GetComponent<CanvasGroup>().alpha = 0;
            gameMenu.GetComponent<CanvasGroup>().interactable = false;
            gameMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        if(isVideoMenuOpen)
        {
            videoMenu.GetComponent<CanvasGroup>().alpha = 1;
            videoMenu.GetComponent<CanvasGroup>().interactable = true;
            videoMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            videoMenu.GetComponent<CanvasGroup>().alpha = 0;
            videoMenu.GetComponent<CanvasGroup>().interactable = false;
            videoMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        if(isAudioMenuOpen)
        {
            audioMenu.GetComponent<CanvasGroup>().alpha = 1;
            audioMenu.GetComponent<CanvasGroup>().interactable = true;
            audioMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            audioMenu.GetComponent<CanvasGroup>().alpha = 0;
            audioMenu.GetComponent<CanvasGroup>().interactable = false;
            audioMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }
}
