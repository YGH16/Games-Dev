using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    [SerializeField] private LayerMask layerMask;
    private Mesh mesh;
    
    private float fov; 
    private float viewDistance; 
    private Vector3 origin; 
    private float startingAngle; 
    // Start is called before the first frame update
    private void Start()
    {
        mesh = new Mesh(); 
        GetComponent<MeshFilter>().mesh = mesh; 
        origin = Vector3.zero;

    }

    // Update is called once per frame
    private void LateUpdate()
    {
        int rayCount = 50; 
        float angle = startingAngle;
        float angleInc = fov/rayCount;

        Vector3[] vertices = new Vector3[rayCount + 1 + 1]; 
        Vector2[] uv = new Vector2[vertices.Length]; 
        int[] triangles = new int[rayCount*3]; 

        vertices[0] = origin;

        int vertexIndex = 1; 
        int triangleIndex = 0;
        for (int i= 0; i <=rayCount; i++){
            float angleRad = angle * (Mathf.PI/180f);
            Vector3 vertex;
            Vector3 vectorAngle = new Vector3(Mathf.Cos(angleRad), Mathf.Sin(angleRad));
           
            RaycastHit2D raycastHit2D = Physics2D.Raycast(origin, vectorAngle, viewDistance, layerMask);
            if (raycastHit2D.collider == null){
                //no hit
                vertex = origin + vectorAngle * viewDistance;
            }
            else{
                // Objects has been hit
                vertex = raycastHit2D.point; 
            }
             
            vertices[vertexIndex] = vertex; 

            
            if (i>0){
                triangles[triangleIndex + 0] = 0;
                triangles[triangleIndex + 1] = vertexIndex - 1;
                triangles[triangleIndex + 2] = vertexIndex;

                triangleIndex += 3;
            }
            vertexIndex++; 
            angle -= angleInc;
        }

        mesh.vertices = vertices; 
        mesh.uv = uv; 
        mesh.triangles = triangles; 
    }

    public void SetOrigin(Vector3 origin){
        this.origin = origin; 
    }

    public void SetDirection(Vector3 aimDir){
        Vector3 dir = aimDir.normalized;
        float n = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg; 
        if (n < 0){n += 360;}

        startingAngle = n + fov/2f; 
    }

    public void SetViewDistance(float viewDistance){
        this.viewDistance = viewDistance;  
    }
    public void SetFoV(float fov){
        this.fov = fov;
    }
}

