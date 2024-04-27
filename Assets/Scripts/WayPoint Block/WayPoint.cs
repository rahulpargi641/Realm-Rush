using UnityEngine;

public class WayPoint : MonoBehaviour
{
    // Data Class
    public bool isExplored = false;
    public bool isPlacable = true;
    public WayPoint exploredFrom;  

    [SerializeField] MeshRenderer wayPointMeshRenderer;
    [SerializeField] Color placableColor;
    [SerializeField] Color unplacableColor;

    private Color originalColor;

    const int gridSize = 10; // we don't wanna individual block size

    private void Start()
    {
        originalColor = wayPointMeshRenderer.material.color;
    }

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
                FindObjectOfType<TowerSpawner>().AddTower(this);

                Debug.Log("Tower Base Coordinate" + gameObject.name);
            }
            else
                print("Can't place it here");
        }
    }

    private void OnMouseEnter()
    {
        UpdateMeshColor();
    }

    private void OnMouseExit()
    {
        wayPointMeshRenderer.material.color = originalColor;
    }

    private void UpdateMeshColor()
    {
        if (isPlacable)
            SetMeshColor(placableColor);
        else
            SetMeshColor(unplacableColor);
    }

    public void SetMeshColor(Color color)
    {
        wayPointMeshRenderer.material.color = color;
    }
}
