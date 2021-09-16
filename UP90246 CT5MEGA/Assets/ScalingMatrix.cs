using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScalingMatrix : MonoBehaviour
{
    Vector3[] ModelSpaceVertices;
    MeshFilter MF;
    // Start is called before the first frame update
    void Start()
    {
        MF = GetComponent<MeshFilter>();
        ModelSpaceVertices = MF.mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3[] TransformedVertices = new Vector3[ModelSpaceVertices.Length];

        //scaling matrix
        Matrix4by4 scaleMatrix = new Matrix4by4(
            new Vector3(1, 0, 0) * 3.0f, 
            new Vector3(0, 1, 0) * 3.0f,
            new Vector3(0, 0, 1) * 3.0f, 
            Vector3.zero);

        //Transform each individual vertex
        for (int i = 0; i < TransformedVertices.Length; i++)
        {
            //rotate objects using the rotation matrix
            TransformedVertices[i] = scaleMatrix * ModelSpaceVertices[i];
        }

        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //assign our new vertices
        MF.mesh.vertices = TransformedVertices;

        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();
    }
}
