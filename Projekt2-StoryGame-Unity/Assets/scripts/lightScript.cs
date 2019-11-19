using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightScript : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
//  [SerializeField] private LayerMask enemyLayerMask;

    private Mesh mesh;
    private Vector3 origin;
    private float startingAngle;
    private float fov;

    private void Start()
    {
        //gør mesh klar til brug.
        mesh = new Mesh();
        GetComponent<MeshFilter>().mesh = mesh;

        //sætter startpos til midten af det game object, som scriptet er plaseret på.
        origin = Vector3.zero;

        //den vinkel, som skal være synlig ud af de 360 grader.
        fov = 75f;
    }

    private void LateUpdate()
    {
        //mængden af rays, som bliver til x små trekanter.
        int rayCount = 50;
        //får vi fra funktionen længere nede.
        float angle = startingAngle;
        //finder den vikel, hver af de små trekanter skal have.
        float angleIncrease = fov / rayCount;
        //hvor langt skal spilleren kunne se.
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

            //RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, GetVectorFromAng(angle), viewDistance, enemyLayerMask);

            if (raycastHit2D.collider == null)
            {
                //no hit
                vertex = origin + GetVectorFromAng(angle) * viewDistance;
            }
            else
            {
                // Hit object
                vertex = raycastHit2D.point;

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

        //genereae meshet, med de variabler vi har regnet os frem til.
        mesh.vertices = vertices;
        mesh.uv = uv;
        mesh.triangles = triangles;
        mesh.bounds = new Bounds(origin, Vector3.one * 1000f);
    }

    //funktion, som kan kaldes fra et andet script, for at sætte lygtens startpos.
    public void SetOrigin(Vector3 origin)
    {
        this.origin = origin;
    }

    //funktion, som kan kaldes fra et andet script, for at sætte ratningen på lygten.
    public void SetAimDirection(Vector3 aimDirection)
    {
        startingAngle = GetAngleFromVectorFloat(aimDirection) + fov / 2f;
    }


    //udregner en vector udfra en vinkel
    private Vector3 GetVectorFromAng(float ang)
    {
        float angleRad = ang * (Mathf.PI / 180f);
        return new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
    }


    //udregner vinklen udfra en vector.
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
