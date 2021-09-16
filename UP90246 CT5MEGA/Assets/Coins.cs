using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    //attributes for the game object transformations
    Vector3[] ModelSpaceVertices;
    MeshFilter MF;
    float yawAngle;
    float EulerAngles;
    BoundingCircle collision;
    BoundingCircle FPplayer;

    // Start is called before the first frame update
    void Start()
    {
        MF = GetComponent<MeshFilter>();
        ModelSpaceVertices = MF.mesh.vertices;

        //define a collision box for player
        collision = new BoundingCircle(transform.position, 0.5f);
       
    }

    // Update is called once per frame
    void Update()
    {
        //add to our Yaw Angle
        yawAngle += Time.deltaTime;

        //EulerAngles = 90 * Mathf.PI / 180;

        //Define a new array with the correct size
        Vector3[] TransformedVertices = new Vector3[ModelSpaceVertices.Length];

        //Create our rotation on the z/roll axis
        Matrix4by4 rollMatrix = new Matrix4by4(
            new Vector3(Mathf.Cos(0), Mathf.Sin(0), 0),
            new Vector3(-Mathf.Sin(0), Mathf.Cos(0), 0),
            new Vector3(0, 0, 1),
            Vector3.zero);

        //Create a rotation on the y/yaw axis
        Matrix4by4 yawMatrix = new Matrix4by4(
            new Vector3(Mathf.Cos(0), 0, -Mathf.Sin(0)),
            new Vector3(0, 1, 0),
            new Vector3(Mathf.Sin(0), 0, Mathf.Cos(0)),
            Vector3.zero);

        //Create a rotation in x/pitch axis
        Matrix4by4 pitchMatrix = new Matrix4by4(
            new Vector3(1, 0, 0),
            new Vector3(0, Mathf.Cos(yawAngle), Mathf.Sin(yawAngle)),
            new Vector3(0, -Mathf.Sin(yawAngle), Mathf.Cos(yawAngle)),
            Vector3.zero);

        //scaling matrix
        Matrix4by4 scaleMatrix = new Matrix4by4(
            new Vector3(1, 0, 0),
            new Vector3(0, 1, 0) / 10.0f,
            new Vector3(0, 0, 1),
            Vector3.zero);

        //calculation for rotation matrix
        Matrix4by4 RotationMatrix = yawMatrix * (pitchMatrix * rollMatrix);

        //Transform each individual vertex
        for (int i = 0; i < TransformedVertices.Length; i++)
        {
            //rotate objects using the rotation matrix
            TransformedVertices[i] = RotationMatrix * scaleMatrix * ModelSpaceVertices[i];
        }

        //Mesh filter is a component that stores information about the current mesh
        MeshFilter MF = GetComponent<MeshFilter>();

        //assign our new vertices
        MF.mesh.vertices = TransformedVertices;

        MF.mesh.RecalculateNormals();
        MF.mesh.RecalculateBounds();


        collision.CentrePoint = transform.position;
        BoundingCircle FPplayer = GameObject.Find("FPplayer").GetComponent<Movement>().FPplayer;

        {
            if (collision.Intersects(FPplayer))

            {
                Destroy(this.gameObject); //destroys obejcts when it has collided
            }

        }
    }
    }
