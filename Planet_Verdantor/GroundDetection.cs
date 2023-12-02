using UnityEngine;

public class GroundDetection : MonoBehaviour
{
    public LayerMask groundLayer; // Set this to the terrain layer
    public Terrain terrain; // Reference to your terrain

    public bool IsOnGround()
    {
        Vector3 rayOrigin = transform.position + Vector3.up * 0.1f; // Offset slightly above the object
        float rayDistance = 0.2f; // Adjust as needed

        RaycastHit hit;
        if (Physics.Raycast(rayOrigin, Vector3.down, out hit, rayDistance, groundLayer))
        {
            // Check if the hit point is on the terrain
            if (hit.collider.GetComponent<TerrainCollider>() == terrain.GetComponent<TerrainCollider>())
            {
                return true;
            }
        }

        return false;
    }
}
