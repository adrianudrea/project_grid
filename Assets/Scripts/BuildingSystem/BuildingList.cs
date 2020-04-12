using System.Collections.Generic;
using UnityEngine;

public class BuildingList : MonoBehaviour
{
    [Header("Database")]
    public Database database;
    [Header("Components")]
    public GameObject buildingInMenuPrefab;
    public GameObject buildingHolder;
    public List<GameObject> buildingList = new List<GameObject>();
    [Header("Spawned Buildings")]
    public List<GameObject> spawnedBuildingList = new List<GameObject>();

    private void Start()
    {
        AddBuildingsToMenu(0);
        AddBuildingsToMenu(1);

        gameObject.GetComponent<SortList>().SortA();
    }
    // Populates the building list from the database
    public void AddBuildingsToMenu(int id)
    {
        Database.Building buildingToAdd = database.GetBuildingById(id);

        for(int i = 0; i < database.buildingDatabase.Count; i++)
        {
            if(database.buildingDatabase[i].buildingId == id)
            {
                GameObject newBuildingItem = Instantiate(buildingInMenuPrefab);
                newBuildingItem.GetComponent<Building>().building = buildingToAdd;
                newBuildingItem.GetComponent<Building>().buildingId = i;
                newBuildingItem.GetComponent<Building>().buildingLevel = database.buildingDatabase[i].buildingLevel;
                newBuildingItem.GetComponent<Building>().buildingName = database.buildingDatabase[i].buildingName;
                newBuildingItem.GetComponent<Building>().buildingDescription = database.buildingDatabase[i].buildingDescription;
                newBuildingItem.GetComponent<Building>().buildingType = database.buildingDatabase[i].buildingtype.ToString();
                newBuildingItem.GetComponent<Building>().currentWorkers = database.buildingDatabase[i].currentWorkers;
                newBuildingItem.GetComponent<Building>().buildingResourceType = database.buildingDatabase[i].buildingResourceType.ToString();
                newBuildingItem.GetComponent<Building>().buildingOutput = database.buildingDatabase[i].buildingOutput;
                newBuildingItem.GetComponent<Building>().buildingResourceCostTypeA = database.buildingDatabase[i].buildingResourceCostTypeA.ToString();
                newBuildingItem.GetComponent<Building>().buildingResourceCostTypeB = database.buildingDatabase[i].buildingResourceCostTypeB.ToString();
                newBuildingItem.GetComponent<Building>().buildingPriceA = database.buildingDatabase[i].buildingPriceA;
                newBuildingItem.GetComponent<Building>().buildingPriceB = database.buildingDatabase[i].buildingPriceB;
                newBuildingItem.GetComponent<Building>().buildingPrefab = database.buildingDatabase[i].buildingPrefab;
                newBuildingItem.GetComponent<Building>().buildingUIPrefab = database.buildingDatabase[i].buildingUIPrefab;
                newBuildingItem.transform.SetParent(buildingHolder.transform, false);
                newBuildingItem.name = buildingToAdd.buildingName;
                buildingList.Add(newBuildingItem);
                break;            
            }
        }
    }
}
