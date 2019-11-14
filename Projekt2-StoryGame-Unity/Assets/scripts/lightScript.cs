using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using CodeMonkey.Utils;

public class lightScript : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
//    [SerializeField] private LayerMask enemyLayerMask;
    private Mesh mesh;
    private Vector3 origin;
    private float startingAngle;
    private float fov;
    private void Start()
    {
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;
        origin = Vector3.zero;
        fov = 75f;
    }

    private void LateUpdate()
    {

        int rayCount = 50;
        float angle = startingAngle;
        float angleIncrease = fov / rayCount;
        float viewDistance = 7f;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1];
        Vector2[] uv = new Vector2[vertices.Length];
        int[] triangles = new int[rayCount * 3];

        vertices[0] = origin;

        int vertexIndex = 1;
        int triangleIndex = 0;
        for (int i = 0; i <= rayCount; i++)
        {
            Vector3 vertex;
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAng(angle), viewDistance, layerMask);

           // RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAng(angle), viewDistance, enemyLayerMask);


            if (raycastHit2D.collider == null)
            {
                //no hit
                vertex = origin + GetVectorFromAng(angle) * viewDistance;
            }
            else
            {
                // Hit object
                vertex = raycastHit2D.point;

                //Debug.Log(raycastHit2D.collider.gameObject.name);
               
                //Hvis spillerens lygte rammer et object med tagget "Enemy"
                if (raycastHit2D.collider.gameObject.CompareTag("Enemy"))
                {
                    //fjern objektet
                    Destroy(raycastHit2D.collider.gameObject, 0.3f);   
                }
            }
            
            vertices[vertexIndex] = vertex;

            

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
        mesh.bounds = new Bounds(origin, Vector3.one * 1000f);

    }

    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) + fov / 2f;
    }

    private Vector3 GetVectorFromAng(float ang)
    {
        float angleRad = ang * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }

    private float GetAngleFromVectorFloat(Vector3 dir)
    {
        dir = dir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        if(n < 0)
        {
            n += 360;
        }

        return n;
    }


}
