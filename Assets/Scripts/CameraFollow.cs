using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;       
    public Vector3 offset = new Vector3(-1.5f, 2.5f, -10f); 
    public float smoothSpeed = 0.1f;  

    public float minY = -1f;

    private void LateUpdate()
    {
        if (player == null) return;

        Vector3 targetPos = new Vector3(player.position.x + offset.x, player.position.y + offset.y, offset.z);

        if (targetPos.y < minY)
            targetPos.y = minY;

        transform.position = Vector3.Lerp(transform.position, targetPos, smoothSpeed);
    }
}
