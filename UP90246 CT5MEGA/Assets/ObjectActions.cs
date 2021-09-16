using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActions : MonoBehaviour
{
    //attributes for the game object transformations
    Vector3[] ModelSpaceVertices;
    MeshFilter MF;
    float yawAngle;

    float quatAngle;
    private Transform Item;

    void Start()
    {
        MF = GetComponent<MeshFilter>();
        ModelSpaceVertices = MF.mesh.vertices;
    }

    // Update is called once per frame
    void Update()
    {
        quatAngle += Time.deltaTime;

        //Define a new array with the correct size
        Vector3[] TransformedVertices = new Vector3[ModelSpaceVertices.Length];

        #region//controls
        //rotate object right
        {
            if (Input.GetKey("right"))
            {
                //Define a quaternion that is the equivilent of rotating around the Yaw axis by "quatAngle" amount
                Quat right = new Quat(quatAngle, new Vector3(0, -1, 0));

                //calculation for rotation matrix
                Matrix4by4 RotationMatrix = right.QuatToRotMatrix();

                //Transform each individual vertex
                for (int i = 0; i < TransformedVertices.Length; i++)
                {
                    //rotate objects using the rotation matrix
                    TransformedVertices[i] = RotationMatrix * ModelSpaceVertices[i];
                }

                //Mesh filter is a component that stores information about the current mesh
                MeshFilter MF = GetComponent<MeshFilter>();

                //assign our new vertices
                MF.mesh.vertices = TransformedVertices;

                MF.mesh.RecalculateNormals();
                MF.mesh.RecalculateBounds();
            }
        }

        //rotate object left
        {
            if (Input.GetKey("left"))
            {
                //Define a quaternion that is the equivilent of rotating around the Yaw axis by "quatAngle" amount
                Quat left = new Quat(quatAngle, new Vector3(0, 1, 0));

                //calculation for rotation matrix
                Matrix4by4 RotationMatrix = left.QuatToRotMatrix();

                //Transform each individual vertex
                for (int i = 0; i < TransformedVertices.Length; i++)
                {
                    //rotate objects using the rotation matrix
                    TransformedVertices[i] = RotationMatrix * ModelSpaceVertices[i];
                }

                //Mesh filter is a component that stores information about the current mesh
                MeshFilter MF = GetComponent<MeshFilter>();

                //assign our new vertices
                MF.mesh.vertices = TransformedVertices;

                MF.mesh.RecalculateNormals();
                MF.mesh.RecalculateBounds();
            }
        }

        //rotate object up
        {
            if (Input.GetKey("up"))
            {
                //Define a quaternion that is the equivilent of rotating around the Yaw axis by "quatAngle" amount
                Quat Up = new Quat(quatAngle, new Vector3(1, 0, 0));

                //calculation for rotation matrix
                Matrix4by4 RotationMatrix = Up.QuatToRotMatrix();

                //Transform each individual vertex
                for (int i = 0; i < TransformedVertices.Length; i++)
                {
                    //rotate objects using the rotation matrix
                    TransformedVertices[i] = RotationMatrix * ModelSpaceVertices[i];
                }

                //Mesh filter is a component that stores information about the current mesh
                MeshFilter MF = GetComponent<MeshFilter>();

                //assign our new vertices
                MF.mesh.vertices = TransformedVertices;

                MF.mesh.RecalculateNormals();
                MF.mesh.RecalculateBounds();
            }
        }

        //rotate object down
        {
            if (Input.GetKey("down"))
            {
                //Define a quaternion that is the equivilent of rotating around the Yaw axis by "quatAngle" amount
                Quat down = new Quat(quatAngle, new Vector3(-1, 0, 0));

                //calculation for rotation matrix
                Matrix4by4 RotationMatrix = down.QuatToRotMatrix();

                //Transform each individual vertex
                for (int i = 0; i < TransformedVertices.Length; i++)
                {
                    //rotate objects using the rotation matrix
                    TransformedVertices[i] = RotationMatrix * ModelSpaceVertices[i];
                }

                //Mesh filter is a component that stores information about the current mesh
                MeshFilter MF = GetComponent<MeshFilter>();

                //assign our new vertices
                MF.mesh.vertices = TransformedVertices;

                MF.mesh.RecalculateNormals();
                MF.mesh.RecalculateBounds();
            }
        }
        #endregion

    }
}
