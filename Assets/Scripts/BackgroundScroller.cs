using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [Header("Scrolling Settings")]
    public float scrollSpeed = 3f;    // How fast the background moves
    public Transform player;          // Drag Player here

    private Transform[] backgrounds;  // Array of 4 child backgrounds
    private float backgroundWidth;    // Width of a single background

    private void Start()
    {
        // Get all children of this manager
        int childCount = transform.childCount;
        backgrounds = new Transform[childCount];

        for (int i = 0; i < childCount; i++)
        {
            backgrounds[i] = transform.GetChild(i);
        }

        // Assume all backgrounds have the same width
        SpriteRenderer sr = backgrounds[0].GetComponent<SpriteRenderer>();
        backgroundWidth = sr.bounds.size.x;
    }

    private void Update()
    {
        for (int i = 0; i < backgrounds.Length; i++)
        {
            // Move background left based on player speed
            backgrounds[i].position += Vector3.left * scrollSpeed * Time.deltaTime;

            // Check if the background is completely off-screen to the left
            if (backgrounds[i].position.x < player.position.x - backgroundWidth)
            {
                // Move it to the rightmost position
                float rightMostX = GetRightMostBackgroundX();
                backgrounds[i].position = new Vector3(rightMostX + backgroundWidth, backgrounds[i].position.y, backgrounds[i].position.z);
            }
        }
    }

    // Find the current rightmost background X-position
    private float GetRightMostBackgroundX()
    {
        float maxX = backgrounds[0].position.x;
        foreach (Transform bg in backgrounds)
        {
            if (bg.position.x > maxX)
                maxX = bg.position.x;
        }
        return maxX;
    }
}
