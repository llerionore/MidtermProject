using System.Collections;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public Vector2 currentPosition;

    void Start()
    {
        currentPosition = new Vector2(transform.position.x, transform.position.y);
    }

    public void MoveCamera(Vector2 moveAmount)
    {
        currentPosition += moveAmount;
        StartCoroutine(SmoothMove(new Vector3(currentPosition.x, currentPosition.y, transform.position.z)));
    }
    private IEnumerator SmoothMove(Vector3 targetPosition)
    {
        while ((transform.position - targetPosition).sqrMagnitude > 0.01f)
        {
            transform.position = Vector3.Lerp(transform.position, targetPosition, 10f * Time.deltaTime);
            yield return null;
        }
        transform.position = targetPosition;
    }

}
