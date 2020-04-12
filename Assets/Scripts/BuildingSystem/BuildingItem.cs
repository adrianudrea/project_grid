using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BuildingItem : MonoBehaviour
{
    [Header("Components")]
    public GameObject buildingSystem;
    [Header("UI")]
    public Text buildingName;
    public Text buildingDescription;
    public Text buildingCostA;
    public Text buildingCostB;
    public GameObject tooltip;
    public Button button;

    private void Start() 
    {
        buildingSystem = GameObject.FindGameObjectWithTag("BuildingSystem");
        GetBuildingData();

        button.onClick.AddListener(SpawnObject);
    }

    // Assings the building information to the UI
    private void GetBuildingData()
    {
        buildingName.text = GetComponent<Building>().buildingName;
        buildingDescription.text = GetComponent<Building>().buildingDescription;
        buildingCostA.text = GetComponent<Building>().buildingResourceCostTypeA.ToString() + " " + GetComponent<Building>().buildingPriceA.ToString();
        buildingCostB.text = GetComponent<Building>().buildingResourceCostTypeB.ToString() + " " + GetComponent<Building>().buildingPriceB.ToString();
    }
    // Spawns the building and assigns all parameters
    private void SpawnObject()
    {
        buildingSystem.GetComponent<BuildingSystem>().isBuilding = true;
        GameObject spawnedBuilding;
        spawnedBuilding = Instantiate(GetComponent<Building>().buildingPrefab, transform.position, Quaternion.identity);
        spawnedBuilding.GetComponent<Building>().buildingId = gameObject.GetComponent<Building>().buildingId;
        spawnedBuilding.GetComponent<Building>().buildingLevel = gameObject.GetComponent<Building>().buildingLevel;
        spawnedBuilding.GetComponent<Building>().buildingName = gameObject.GetComponent<Building>().buildingName;
        spawnedBuilding.GetComponent<Building>().buildingDescription = gameObject.GetComponent<Building>().buildingDescription;
        spawnedBuilding.GetComponent<Building>().buildingType = gameObject.GetComponent<Building>().buildingType;
        spawnedBuilding.GetComponent<Building>().currentWorkers = gameObject.GetComponent<Building>().currentWorkers;
        spawnedBuilding.GetComponent<Building>().buildingResourceType = gameObject.GetComponent<Building>().buildingResourceType;
        spawnedBuilding.GetComponent<Building>().buildingOutput = gameObject.GetComponent<Building>().buildingOutput;
        spawnedBuilding.GetComponent<Building>().buildingResourceCostTypeA = gameObject.GetComponent<Building>().buildingResourceCostTypeA;
        spawnedBuilding.GetComponent<Building>().buildingResourceCostTypeB = gameObject.GetComponent<Building>().buildingResourceCostTypeB;
        spawnedBuilding.GetComponent<Building>().buildingPriceA = gameObject.GetComponent<Building>().buildingPriceA;
        spawnedBuilding.GetComponent<Building>().buildingPriceB = gameObject.GetComponent<Building>().buildingPriceB;
        spawnedBuilding.GetComponent<Building>().buildingUIPrefab = gameObject.GetComponent<Building>().buildingUIPrefab;
        buildingSystem.GetComponent<BuildingSystem>().buildingToPlace = spawnedBuilding;
    }
    // UI -- Functionality for this is set in the editor with the event trigger
    public void ShowUI() 
    {
        tooltip.GetComponent<CanvasGroup>().alpha = 1;
    }

    public void HideUI() 
    {
        tooltip.GetComponent<CanvasGroup>().alpha = 0;
    }
}
