using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
[RequireComponent(typeof(WayPoint))]
public class CubeEditor : MonoBehaviour
{
    //[SerializeField] [Range(1,20)] float gridSize = 10f;
    WayPoint wayPoint;
    void Awake()
    {
        // Debug.Log("Editor causes this Awake");
        wayPoint = GetComponent<WayPoint>();
    }

    void Update()
    {
        SnapToGrid();
        UpdateLabel();

    }

     void SnapToGrid()
     {
        int gridSize = wayPoint.GetGridSize();

        transform.position = new Vector3(wayPoint.GetGridLabelCoordinate().x * gridSize, 0, wayPoint.GetGridLabelCoordinate().y * gridSize);
      
     }

    void UpdateLabel()
    {
        TextMesh textMesh = GetComponentInChildren<TextMesh>();
        string label = wayPoint.GetGridLabelCoordinate().x + "," + wayPoint.GetGridLabelCoordinate().y;

        textMesh.text = label;
        gameObject.name = label;
    }
}
