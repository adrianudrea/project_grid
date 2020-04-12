using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    [Header("Components")]
    public GameObject buildingToPlace;
    public GameObject previousBuildingToPlace;
    public GameObject gameUI;
    public ResourceManager resourceManager;
    [Header("Bools")]
    public bool isPlaced;
    public bool isBuilding;
    [Header("Grid Setup")]
    public GameObject gridPrefab;
    public float gridSize;
    public bool isGridOn;
    [Header("Rotation Value")]
    public float rotation;
    [Header("Vectors")]
    public Vector3 offset;
    public Vector3 placementPosition;

    private void Start()
    {
        gameUI = GameObject.FindGameObjectWithTag("GUI");
        GridToggle();
    }

    private void Update()
    {
        if(isBuilding)
        {
            MoveObjectToMousePosition();
            RotateObject();
            PlaceObject();
            GridToggle();
            BuildingMenuToggle();
        }
    }

    private void BuildingMenuToggle()
    {
        if(isBuilding && gameUI.GetComponent<GameUI>().isBuildingMenuOpen)
        {
            gameUI.GetComponent<GameUI>().buildingMenu.GetComponent<CanvasGroup>().interactable = false;
        }
        else if(!isBuilding && gameUI.GetComponent<GameUI>().isBuildingMenuOpen)
        {
            gameUI.GetComponent<GameUI>().buildingMenu.GetComponent<CanvasGroup>().interactable = true;
        }
    }

    private void GridToggle()
    {
        if(isBuilding) { isGridOn = true; }
            else { isGridOn = false; }

        if(isGridOn) { gridPrefab.SetActive(true); }
            else { gridPrefab.SetActive(false); }
    }

    // Will take resources on object (building) placement
    private void TakeResourcesOnBuild()
    {
        switch(buildingToPlace.GetComponent<Building>().buildingResourceCostTypeA)
        {
            case "Food":
            resourceManager.foodTotal -= buildingToPlace.GetComponent<Building>().buildingPriceA;
            break;
            case "Wood":
            resourceManager.woodTotal -= buildingToPlace.GetComponent<Building>().buildingPriceA;
            break;
            case "Iron":
            resourceManager.ironTotal -= buildingToPlace.GetComponent<Building>().buildingPriceA;
            break;
            case "Steel":
            resourceManager.steelTotal -= buildingToPlace.GetComponent<Building>().buildingPriceA;
            break;
            case "Fuel":
            resourceManager.fuelTotal -= buildingToPlace.GetComponent<Building>().buildingPriceA;
            break;
            default: return;
        }
        switch(buildingToPlace.GetComponent<Building>().buildingResourceCostTypeB)
        {
            case "Food":
            resourceManager.foodTotal -= buildingToPlace.GetComponent<Building>().buildingPriceB;
            break;
            case "Wood":
            resourceManager.woodTotal -= buildingToPlace.GetComponent<Building>().buildingPriceB;
            break;
            case "Iron":
            resourceManager.ironTotal -= buildingToPlace.GetComponent<Building>().buildingPriceB;
            break;
            case "Steel":
            resourceManager.steelTotal -= buildingToPlace.GetComponent<Building>().buildingPriceB;
            break;
            case "Fuel":
            resourceManager.fuelTotal -= buildingToPlace.GetComponent<Building>().buildingPriceB;
            break;
            default: return;
        }

        resourceManager.CheckForResources();
    }

    // Will place the object (building) on scene as long as isBuilding == true
    private void PlaceObject()
    {
        if(Input.GetMouseButtonDown(0))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            if(Physics.Raycast(ray, out hit))
            {
                buildingToPlace.layer = 0;
                isPlaced = true;
                buildingToPlace.GetComponent<Building>().isPlaced = true;
                gameObject.GetComponent<BuildingList>().spawnedBuildingList.Add(buildingToPlace);
                TakeResourcesOnBuild();
                buildingToPlace = null;
                isPlaced = false;
                isBuilding = false;
            }
        }
        // Cancels action
        else if(Input.GetMouseButtonDown(1))
        {
            Destroy(buildingToPlace.GetComponent<Building>().buildingUIPrefab);
            Destroy(buildingToPlace);
            buildingToPlace = null;
            isPlaced = false;
            isBuilding = false;
        }
    }
    // Moves the object (building) to the mouse position
    private void MoveObjectToMousePosition()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        if(Physics.Raycast(ray, out hit))
        {
            buildingToPlace.transform.position = hit.point;

            placementPosition.x = Mathf.Floor(buildingToPlace.transform.position.x / gridSize) * gridSize;
            placementPosition.z = Mathf.Floor(buildingToPlace.transform.position.z / gridSize) * gridSize;
        
            placementPosition.y = 0.5f;

            buildingToPlace.transform.position = placementPosition;
        }
    }

    private void RotateObject()
    {
       if(Input.GetKeyDown(KeyCode.Q))
       {
           buildingToPlace.transform.Rotate(transform.position.x, rotation, transform.rotation.z);
       }
       if(Input.GetKeyDown(KeyCode.E))
       {
           buildingToPlace.transform.Rotate(transform.position.x, -rotation, transform.rotation.z);
       }
    }
}
