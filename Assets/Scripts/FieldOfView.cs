using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;
using SAE;

public class FieldOfView : MonoBehaviour
{
    private bool hasfunction;

    //This script was taught by Code Monkey on Youtube. Field of View effec in Unity (Line of Sight, View Cone) & How to create a Mesh from code | Unity Tutorial.
    //Written and modified by Brody to fit the needs of the project.
    private void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        //This will repalce the array the commented out arrays below to allow for adpation on the player.
        //Easily modifiable.
        float fov = 75f;
        Vector3 origin = Vector3.zero;
        int rayCount = 50;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 15f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1]; //rayCount + 1 + 1 means one array will project one array at 0 one array at 45 and one array at 90.
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1; // Start on index 1 as index 0 is origin as stated above.
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            //Had to go into the CodeMonkey UtilsClass script and change the formula for the GetVectorAngle.
            //The formula called the angle an int but you want it as a float.
            Vector3 vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;


            // I would like ot get this chunk of code to work for 3D.
            //Makes the raycast/mesh bend around objects in the scene rather than going straight through.
            //If this gets setup I need to add a layer mask as well
            /*
            [SerializeField] private LayerMask layerMask;
            */
            /*RaycastHit2D raycasHit2D = Physics2D.Raycast(origin, UtilsClass.GetVectorFromAngle(angle), viewDistance, layerMask);
            if (raycasHit2D.collider == null)
            {
                //No hit.
                vertex = origin + UtilsClass.GetVectorFromAngle(angle) * viewDistance;
            }
            else
            {
                //Hit object.
                vertex = raycasHit2D.point;
            }*/


            //Vertex position.
            vertices[vertexIndex] = vertex;

            //Origin --> Previous Vertex --> Current Vertex = Polygon Triangle.
            if (i > 0)
            {
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++;

            angle -= angleIncrease;
        }

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;

        MeshCollider mc = this.gameObject.GetComponent<MeshCollider>();
        if (mc != null) { mc.sharedMesh = mesh; }

    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log( "SUCK!: " +other.gameObject.name );
        GameObject go;
        hasfunction = other.gameObject.GetComponent<DestroyMe>();
        if (hasfunction)
        {
            Destroy(other.gameObject);
        }

    }

}