using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Building : MonoBehaviour
{
    [Header("Building Details")]
    public int buildingId;
    public int buildingLevel;
    public string buildingName;
    public string buildingDescription;
    public string buildingType;
    public int currentWorkers;
    public string buildingResourceType;
    public int buildingOutput;
    public string buildingResourceCostTypeA;
    public string buildingResourceCostTypeB;
    public int buildingPriceA;
    public int buildingPriceB;
    public GameObject buildingPrefab;
    public GameObject buildingUIPrefab;
    public int levelOutput;
    public int upgradeOutput;
    [Header("Components")]
    public GameObject resourceManager;
    public GameObject gameTime;
    public Database.Building building;
    public GameObject buildingUIHolder;
    public Button upgradeButton;
    public Button destroyButton;
    [Header("Bools")]
    public bool isPlaced;
    public bool isColliding;
    public bool isSelected;
    public bool hasGivenResources;

    private void Start() 
    {
        if(isPlaced)
        {
            resourceManager = GameObject.FindGameObjectWithTag("ResourceManager");
            gameTime = GameObject.FindGameObjectWithTag("GameTime");
            buildingUIHolder = GameObject.Find("_buildingPanelHolder");
            buildingUIPrefab = Instantiate(buildingUIPrefab, transform.position, transform.rotation);
            buildingUIPrefab.transform.SetParent(buildingUIHolder.transform, false);
            buildingUIPrefab.transform.position = buildingUIHolder.transform.position;
            buildingUIPrefab.transform.rotation = buildingUIHolder.transform.rotation;
            LevelUpgrade();
            
            ButtonFunctionality();
        }
    }

    private void Update()
    {
        SelectBuilding();
        OpenCloseUI();
    }

    // Functionality
    public void GiveResources()
    {
        switch(buildingResourceType)
        {
            case "Food": resourceManager.GetComponent<ResourceManager>().foodTotal += buildingOutput;
            break;
            case "Wood": resourceManager.GetComponent<ResourceManager>().woodTotal += buildingOutput;
            break;
            case "Iron": resourceManager.GetComponent<ResourceManager>().ironTotal += buildingOutput;
            break;
            case "Steel": resourceManager.GetComponent<ResourceManager>().steelTotal += buildingOutput;
            break;
            case "Fuel": resourceManager.GetComponent<ResourceManager>().fuelTotal += buildingOutput;
            break;
            default: return;
        }
    }

    public void LevelUpgrade()
    {
        switch(buildingLevel)
        {
            case 1: upgradeOutput = 25;
            break;
            case 2: upgradeOutput = 50;
            break;
            case 3: upgradeOutput = 100;
            break;
            case 4: upgradeOutput = 150;
            break;
            case 5: upgradeOutput = 200;
            break;
            default: return;
        }
         buildingOutput = upgradeOutput;
    }

    // UI
    private void SelectBuilding()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                if(hit.collider == this.gameObject.GetComponent<Collider>())
                {
                    isSelected = true;
                }
                else if(hit.collider != this.gameObject.transform)
                {
                    isSelected = false;
                }
            }
        }
    }

    public void OpenCloseUI()
    {
        if(isPlaced && isSelected)
        {
            buildingUIPrefab.GetComponent<CanvasGroup>().alpha = 1;
            buildingUIPrefab.GetComponent<CanvasGroup>().interactable = true;
            buildingUIPrefab.GetComponent<CanvasGroup>().blocksRaycasts = true;
            SendDataToUI();
        }
        else if(isPlaced && !isSelected)
        {
            buildingUIPrefab.GetComponent<CanvasGroup>().alpha = 0;
            buildingUIPrefab.GetComponent<CanvasGroup>().interactable = false;
            buildingUIPrefab.GetComponent<CanvasGroup>().blocksRaycasts = false;
        }
    }

    private void SendDataToUI()
    {
        buildingUIPrefab.transform.GetChild(0).GetComponent<Text>().text = buildingLevel.ToString();
        buildingUIPrefab.transform.GetChild(1).GetComponent<Text>().text = buildingName;
        buildingUIPrefab.transform.GetChild(5).GetComponent<Text>().text = currentWorkers.ToString();
        buildingUIPrefab.transform.GetChild(8).GetComponent<Text>().text = buildingOutput.ToString();

        CheckForParameters();
    }

    private void CheckForParameters()
    {
        if(buildingLevel >= 5) { upgradeButton.interactable = false; }
            else { upgradeButton.interactable = true;}

        if(buildingOutput <= 0) { buildingOutput = 0; }
    }


#region Button Functionality 
    private void UpgradeBuilding() { buildingLevel += 1; LevelUpgrade(); }
    private void DestroyBuilding() { isSelected = false; Destroy(buildingUIPrefab); Destroy(gameObject); }

    private void ButtonFunctionality()
    {
        upgradeButton = buildingUIPrefab.transform.GetChild(9).GetComponent<Button>();
        upgradeButton.onClick.AddListener(UpgradeBuilding);

        destroyButton = buildingUIPrefab.transform.GetChild(10).GetComponent<Button>();
        destroyButton.onClick.AddListener(DestroyBuilding);
    }
#endregion
}
