using UnityEngine;

public class ScreenWrap : MonoBehaviour
{
    private void Update()
    {
        var cam = Camera.main;
        var viewportPosition = cam.WorldToViewportPoint(transform.position);
        
        var newPosition = transform.position;
 
        if (viewportPosition.x > 1 || viewportPosition.x < 0)
        {
            newPosition.y = -newPosition.y;
        }
 
        if (viewportPosition.y > 1 || viewportPosition.y < 0)
        {
            newPosition.y = -newPosition.y;
        }
 
        transform.position = newPosition;
    }
}
