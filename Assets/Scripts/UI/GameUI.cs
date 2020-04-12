using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameUI : MonoBehaviour
{
    [Header("Menus")]
    public GameObject worldMenu;
    public GameObject buildingMenu;
    public GameObject researchMenu;
    public GameObject squadMenu;
    public GameObject optionsMenu;
    [Header("Buttons")]
    public Button worldMenuButton;
    public Button buildingMenuButton;
    public Button researchMenuButton;
    public Button squadMenuButton;
    public Button optionsMenuButton;
    [Header("Bools")]
    public bool isWorldMenuOpen;
    public bool isBuildingMenuOpen;
    public bool isResearchMenuOpen;
    public bool isSquadMenuOpen;
    public bool isOptionsMenuOpen;

    private void Start()
    {
        isWorldMenuOpen = false;
        isBuildingMenuOpen = false;
        isResearchMenuOpen = false;
        isSquadMenuOpen = false;
        isOptionsMenuOpen = false;

        ButtonFunctionality();
        ToggleUI();
    }

    public void OpenWorldMenu()     { isWorldMenuOpen = true;  isBuildingMenuOpen = false; isResearchMenuOpen = false; isSquadMenuOpen = false; isOptionsMenuOpen = false; ToggleUI(); }
    public void OpenBuildingMenu()  { isWorldMenuOpen = false; isBuildingMenuOpen = true;  isResearchMenuOpen = false; isSquadMenuOpen = false; isOptionsMenuOpen = false; ToggleUI(); }
    public void OpenResearchMenu()  { isWorldMenuOpen = false; isBuildingMenuOpen = false; isResearchMenuOpen = true;  isSquadMenuOpen = false; isOptionsMenuOpen = false; ToggleUI(); }
    public void OpenSquadMenu()     { isWorldMenuOpen = false; isBuildingMenuOpen = false; isResearchMenuOpen = false; isSquadMenuOpen = true;  isOptionsMenuOpen = false; ToggleUI(); }
    public void OpenOptionsMenu()   { isWorldMenuOpen = false; isBuildingMenuOpen = false; isResearchMenuOpen = false; isSquadMenuOpen = false; isOptionsMenuOpen = true;  ToggleUI(); }

    private void ButtonFunctionality()
    {
        worldMenuButton.onClick.AddListener(OpenWorldMenu);
        buildingMenuButton.onClick.AddListener(OpenBuildingMenu);
        researchMenuButton.onClick.AddListener(OpenResearchMenu);
        squadMenuButton.onClick.AddListener(OpenSquadMenu);
        optionsMenuButton.onClick.AddListener(OpenOptionsMenu);
    }

    private void ToggleUI()
    {
        if(isWorldMenuOpen)
        {
            worldMenu.GetComponent<CanvasGroup>().alpha = 1;
            worldMenu.GetComponent<CanvasGroup>().interactable = true;
            worldMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            worldMenu.GetComponent<CanvasGroup>().alpha = 0;
            worldMenu.GetComponent<CanvasGroup>().interactable = false;
            worldMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        if(isBuildingMenuOpen)
        {
            buildingMenu.GetComponent<CanvasGroup>().alpha = 1;
            buildingMenu.GetComponent<CanvasGroup>().interactable = true;
            buildingMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            buildingMenu.GetComponent<CanvasGroup>().alpha = 0;
            buildingMenu.GetComponent<CanvasGroup>().interactable = false;
            buildingMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        if(isResearchMenuOpen)
        {
            researchMenu.GetComponent<CanvasGroup>().alpha = 1;
            researchMenu.GetComponent<CanvasGroup>().interactable = true;
            researchMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            researchMenu.GetComponent<CanvasGroup>().alpha = 0;
            researchMenu.GetComponent<CanvasGroup>().interactable = false;
            researchMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
        if(isSquadMenuOpen)
        {
            squadMenu.GetComponent<CanvasGroup>().alpha = 1;
            squadMenu.GetComponent<CanvasGroup>().interactable = true;
            squadMenu.GetComponent<CanvasGroup>().blocksRaycasts = true;
        }
        else
        {
            squadMenu.GetComponent<CanvasGroup>().alpha = 0;
            squadMenu.GetComponent<CanvasGroup>().interactable = false;
            squadMenu.GetComponent<CanvasGroup>().blocksRaycasts = false;
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
