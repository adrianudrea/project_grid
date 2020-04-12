using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(menuName = "Database")]
public class Database : ScriptableObject
{
    public List<Building> buildingDatabase = new List<Building>();

    public enum BuildingType { None, Housing, Resources, Military };
    public enum BuildingResourceType { None, Food, Wood, Iron, Steel, Fuel };
    public enum BuildingResourceCostTypeA { None, Food, Wood, Iron, Steel, Fuel };
    public enum BuildingResourceCostTypeB { None, Food, Wood, Iron, Steel, Fuel };

    public Building GetBuildingById(int id)
    {
        for(int i = 0; i < buildingDatabase.Count; i++)
        {
            if(buildingDatabase[i].buildingId == id)
            {
                return buildingDatabase[i];
            }
        }
        return null;
    }

    [System.Serializable]
    public class Building
    {
        public int buildingId;
        public int buildingLevel;
        public string buildingName;
        public string buildingDescription;
        public BuildingType buildingtype;
        public int currentWorkers;
        public BuildingResourceType buildingResourceType;
        public int buildingOutput;
        public BuildingResourceCostTypeA buildingResourceCostTypeA;
        public BuildingResourceCostTypeB buildingResourceCostTypeB;
        public int buildingPriceA;
        public int buildingPriceB;
        public GameObject buildingPrefab;
        public GameObject buildingUIPrefab;
    }
}
