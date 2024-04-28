using UnityEngine;
using Assets.Scripts.Defense_Tower;

public class WayPoint : MonoBehaviour
{
    // Data Class
    public bool isExplored = false;
    public bool isPlacable = true;
    public WayPoint exploredFrom;

    public int GridSize { get => gridSize; }
    public Vector2Int GridCoordinate
    {
         get => new Vector2Int(
             Mathf.RoundToInt(transform.position.x / gridSize),
             Mathf.RoundToInt(transform.position.z / gridSize)); 
    }

    [SerializeField] MeshRenderer wayPointMeshRenderer;
    [SerializeField] Color placableColor;
    [SerializeField] Color unplacableColor;

    private Color originalColor;

    const int gridSize = 10; // we don't wanna individual block size

    private void Start()
    {
        originalColor = wayPointMeshRenderer.material.color;
    }

   

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            if (isPlacable)
            {
                TowerSpawnManager.Instance.AddTower(this);
                Debug.Log("Tower Base Coordinate" + gameObject.name);
            }
            else
            { print("Can't place it here"); }
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