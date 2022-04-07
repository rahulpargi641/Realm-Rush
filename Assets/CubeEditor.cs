using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
[SelectionBase]
public class CubeEditor : MonoBehaviour
{
    [SerializeField] [Range(1,20)] float gridSize = 10f;
    TextMesh textMesh;
    void Awake()
    {
        Debug.Log("Editor causes this Awake");
    }

    void Start()
    {
          
    }


    void Update()
    {
        Vector3 snapPos; // sets the position of block every frame to some vector3
        snapPos.x = Mathf.RoundToInt(transform.position.x / gridSize) * gridSize;
        snapPos.z = Mathf.RoundToInt(transform.position.z / gridSize) * gridSize;

        transform.position = new Vector3(snapPos.x, 0, snapPos.z);

        textMesh = GetComponentInChildren<TextMesh>();
        string label = snapPos.x / gridSize + "," + snapPos.z / gridSize;

        textMesh.text = label;
        gameObject.name = label;
    }
}
