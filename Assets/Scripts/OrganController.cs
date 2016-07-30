using UnityEngine;
using System.Collections;

public class OrganController : MonoBehaviour {
    private float startTime;
    public float speed;
    private bool moving;
    private Vector3 destPosition;
    private Vector3 startPosition;
    float pendiente;

    void Update()
    {
        if (moving)
        {
            transform.position = Vector3.Lerp(startPosition, destPosition, (Time.time - startTime) / speed);
            if ((Time.time - startTime) >= speed)
                moving = false;
        }
    }

    public void Move(Vector3 endPosition)
    {
        startTime = Time.time;
        destPosition = endPosition;
        startPosition = transform.position;
        moving = true;
        pendiente = (destPosition.z - startPosition.z) / (destPosition.x - startPosition.x);
        if (pendiente < 0)
            pendiente = 360 - pendiente + 180;
        transform.localEulerAngles = new Vector3(0f, transform.rotation.y + Mathf.Atan(pendiente) * Mathf.Rad2Deg, 0);

    }
}
