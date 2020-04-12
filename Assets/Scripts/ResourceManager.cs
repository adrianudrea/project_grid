using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceManager : MonoBehaviour
{
    [Header("Components")]
    public BuildingList buildingList;
    public GameTime gameTime;
    [Header("UI")]
    public Text foodText;
    public Text woodText;
    public Text ironText;
    public Text steelText;
    public Text fuelText;
    [Header("Values")]
    public int foodTotal;
    public int woodTotal;
    public int ironTotal;
    public int steelTotal;
    public int fuelTotal;

    private void Start()
    {
        CheckForResources();
    }

    private void Update()
    {
        AssignResourcesToUI();
        CheckForResources();
    }

    private void AssignResourcesToUI()
    {
        foodText.text = foodTotal.ToString();
        woodText.text = woodTotal.ToString();
        ironText.text = ironTotal.ToString();
        steelText.text = steelTotal.ToString();
        fuelText.text = fuelTotal.ToString();
    }

    public void GiveResources()
    {
        for(int i = 0; i < buildingList.spawnedBuildingList.Count; i++)
        {
            foreach (GameObject item in buildingList.spawnedBuildingList)
            {
                if(!item.GetComponent<Building>().hasGivenResources)
                {
                    item.GetComponent<Building>().GiveResources();
                    item.GetComponent<Building>().hasGivenResources = true;
                }
                else if(item.GetComponent<Building>().hasGivenResources)
                {
                    item.GetComponent<Building>().hasGivenResources = false;
                }
            }
        }
    }
    // Checks if the player has resources available to build the respective building or not
    public void CheckForResources()
    {
        for(int i = 0; i < buildingList.buildingList.Count; i++)
        {
            foreach (GameObject item in buildingList.buildingList)
            {
                // Fuck if I can figure it out!
            }
        }
    }
}
                   

                    

                
                
                
