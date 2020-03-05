using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CodeMonkey.Utils;

public class FieldOfView : MonoBehaviour
{
    //This script was taught by Code Monkey on Youtube. Field of View effec in Unity (Line of Sight, View Cone) & How to create a Mesh from code | Unity Tutorial.
    //Written and modified by Brody to fit the needs of the project.
    private void Start()
    {
        Mesh mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        //This will repalce the array the commented out arrays below to allow for adpation on the player.
        //Easily modifiable.
        float fov = 90f;
        Vector3 origin = Vector3.zero;
        int rayCount = 50;
        float angle = 0f;
        float angleIncrease = fov / rayCount;
        float viewDistance = 50f;

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

        // This section was designed to test the origianl mesh.
        // Keeping it in incase I have to roll back.
        /*vertices[0] = Vector3.zero;
        vertices[1] = new Vector3(50, 0);
        vertices[2] = new Vector3(0, -50);

        triangles[0] = 0;
        triangles[1] = 1;
        triangles[2] = 2;*/

        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
    }
}
