using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    // Public ok as is a data class 
    public bool isExplored = false;
    public WayPoint exploredFrom;
    public bool isPlacable = true;

    [SerializeField] Color exploredColor;

    Vector2Int gridPos;

    const int gridSize = 10; // we don't wanna individual block size
  
    public int GetGridSize()
    {
        return gridSize;
    }

    // HomeWork - setting own color in Update()

    public Vector2Int GetGridLabelCoordinate()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x/gridSize),
            Mathf.RoundToInt(transform.position.z/gridSize)); 
       
    }
    public void SetTopColor(Color color)
    {
        MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
        topMeshRenderer.material.color = color;
        // Searching for children name top
    }    

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlacable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
            }
            else
            {
                print("Can't place it here");
            }
            
        }        

    }
}
