using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SortList : MonoBehaviour
{
    [Header("Components")]
    public BuildingList buildingList; 
    [Header("Buttons")]
    public Button sortA;
    public Button sortB;

    private void Start()
    {
        sortA.onClick.AddListener(SortA);
        sortB.onClick.AddListener(SortB);
    }

    public void SortA () 
    {
        for(int i = 0; i < buildingList.buildingList.Count; i++)
        {
            foreach (GameObject item in buildingList.buildingList)
            {
                if(item.GetComponent<Building>().buildingType == "Housing")
                {
                    item.SetActive(true);
                    item.GetComponent<CanvasGroup>().alpha = 1;
                }
                else
                {
                    item.SetActive(false);
                    item.GetComponent<CanvasGroup>().alpha = 0;
                }
            }
        }
     }

    public void SortB () 
    {
        for(int i = 0; i < buildingList.buildingList.Count; i++)
        {
            foreach (GameObject item in buildingList.buildingList)
            {
                if(item.GetComponent<Building>().buildingType == "Military")
                {
                    item.SetActive(true);
                }
                else
                {
                    item.SetActive(false);
                }
            }
        }
     }
}
