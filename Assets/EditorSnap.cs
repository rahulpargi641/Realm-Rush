using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class EditorSnap : MonoBehaviour
{
    [SerializeField] [Range(1,20)] float gridSize = 10f;
    void Awake()
    {
        Debug.Log("Editor causes this Awake");
    }

    void Update()
    {
        Vector3 snapPos;
        snapPos.x = Mathf.RoundToInt(transform.position.x / 10f) * 10f;
        snapPos.z = Mathf.RoundToInt(transform.position.z / 10f) * 10f;

        transform.position = new Vector3(snapPos.x, 0, snapPos.z);
    }
}
