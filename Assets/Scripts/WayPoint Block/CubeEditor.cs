using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]
public class CubeEditor : MonoBehaviour
{
    WayPoint wayPoint;
    TextMesh labelText;

    void Awake()
    {
        wayPoint = GetComponent<WayPoint>();
        labelText = GetComponentInChildren<TextMesh>();
    }

    void Update()
    {
        SnapToGrid();
        if (labelText)
            UpdateLabel();
        else
            Debug.Log("Label Text is null");
    }

     void SnapToGrid()
     {
        int gridSize = wayPoint.GetGridSize();
        transform.position = new Vector3(wayPoint.GetGridCoordinate().x * gridSize, 0, wayPoint.GetGridCoordinate().y * gridSize);
     }

    void UpdateLabel()
    {
        string label = wayPoint.GetGridCoordinate().x + "," + wayPoint.GetGridCoordinate().y;
        labelText.text = label;
        gameObject.name = label;
    }
}
