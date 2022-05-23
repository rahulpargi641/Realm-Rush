using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WayPoint : MonoBehaviour
{
    [SerializeField] Color exploredColor;
    // Public ok as is a data class 
    public bool isExplored = false;
    public WayPoint exploredFrom;
    public bool isPlacable = true;

    Vector2Int gridPos;
    const int gridSize = 10; // we don't wanna individual block size
    // Start is called before the first frame update
    public int GetGridSize()
    {
        return gridSize;
    }

    // HomeWork - setting own color in Update()

    public Vector2Int GetGridPos()
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
    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlacable)
            {
                print(gameObject.name + " Tower Placement");
            }
            else
            {
                print("Can't place it here");
            }
            
        }        


       
    }
}
