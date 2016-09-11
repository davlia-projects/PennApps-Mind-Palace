using UnityEngine;
using System.Collections;

public class Draw : MonoBehaviour
{
   
    Material mat;
    Vector3 start;
    Vector3 end;
    Color c;

    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    /*   void createMaterial()
     {
         if (!mat)
         {
             Shader shader = Shader.Find("Hidden/Internal-Colored");
             mat = new Material(shader);

             mat.SetInt("_SrcBlend", (int)UnityEngine.Rendering.BlendMode.SrcAlpha);
             mat.SetInt("_DstBlend", (int)UnityEngine.Rendering.BlendMode.OneMinusSrcAlpha);

             mat.SetInt("_Cull",(int)UnityEngine.Rendering.CullMode.Off);
             mat.SetInt("_ZWrite", 0);
         }
     }*/

    public void drawLine(Vector3 start, Vector3 end, Color c)
     {

        GameObject line = new GameObject();
        line.AddComponent<LineRenderer>();
        line.transform.position = start;
        LineRenderer lr = line.GetComponent<LineRenderer>();
        lr.material = new Material(Shader.Find("Particles/Alpha Blended Premultiply"));
        lr.SetColors(c, c);
        lr.SetWidth(0.001f, 0.001f);
        lr.SetPosition(0, start);
        lr.SetPosition(1, end);
        GameObject.Destroy(line, 5.0f);


     }

  /*   public void OnRenderObject() {
         createMaterial();
         GL.PushMatrix();
         mat.SetPass(0);
         GL.LoadOrtho();
         GL.Begin(GL.LINES);
         GL.Color(c);
         GL.Vertex(start);
         GL.Vertex(end);
         GL.PopMatrix();

     }*/
}
