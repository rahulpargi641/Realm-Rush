using UnityEngine;

public class WayPoint : MonoBehaviour
{
    // Data Class
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

    public Vector2Int GetGridCoordinate()
    {
        return new Vector2Int(
            Mathf.RoundToInt(transform.position.x/gridSize),
            Mathf.RoundToInt(transform.position.z/gridSize)); 
       
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlacable)
            {
                FindObjectOfType<TowerFactory>().AddTower(this);
                Debug.Log("Tower Base Coordinate" + gameObject.name);
            }
            else
            {
                print("Can't place it here");
            }
        }       
    }

    //public void SetTopColor(Color color)
    //{
    //    MeshRenderer topMeshRenderer = transform.Find("Top").GetComponent<MeshRenderer>();
    //    topMeshRenderer.material.color = color;
    //}
}
