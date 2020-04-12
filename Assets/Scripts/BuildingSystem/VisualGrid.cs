using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VisualGrid : MonoBehaviour
{
   [SerializeField] private Transform objectTransform;
   [SerializeField] private Material material;
   [SerializeField] private Vector2 gridSize;
   [SerializeField] private int gridRows;
   [SerializeField] private int gridColumns;

   private void Start()
   {
       UpdateGrid();
   }

   public void UpdateGrid()
   {
       objectTransform.localScale = new Vector3 (gridSize.x, gridSize.y, 1.0f);
       material.SetTextureScale("_MainText", new Vector2(gridColumns, gridRows));
   }
}
