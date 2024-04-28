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
        int gridSize = wayPoint.GridSize;
        transform.position = new Vector3(wayPoint.GridCoordinate.x * gridSize, 0, wayPoint.GridCoordinate.y * gridSize);
     }

    void UpdateLabel()
    {
        string label = wayPoint.GridCoordinate.x + "," + wayPoint.GridCoordinate.y;
        labelText.text = label;
        gameObject.name = label;
    }
}
