using Unity.VisualScripting;
using UnityEngine;

public class UVScroller : MonoBehaviour
{
    public float scrollSpeed = 1f;
    private Mesh mesh;
    private Vector2[] uvs;
    private float scrollTimer = 0f;

    void Start()
    {
        mesh = GetComponent<MeshFilter>().mesh;
        uvs = mesh.uv;
        DisplayUVCoordinates(); // Call the method to display the UV coordinates
    }

    void Update()
    {
        scrollTimer += Time.deltaTime;

        float uvOffset = ((Mathf.Sin(scrollTimer * scrollSpeed) + 1) / 2) * 5 * scrollSpeed;

        for (int i = 0; i < uvs.Length; i++)
        {
            uvs[i] = new Vector2(uvs[i].x, uvs[i].y + uvOffset);
           
        }
        mesh.uv = uvs;
    }

    // Method to display the UV coordinates
    void DisplayUVCoordinates()
    {
        for (int i = 0; i < uvs.Length; i++)
        {
            Debug.Log("UV Coordinate " + i + ": " + uvs[i]);
        }
    }
}