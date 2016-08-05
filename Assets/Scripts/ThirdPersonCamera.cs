using UnityEngine;
using System.Collections;

public class ThirdPersonCamera : MonoBehaviour {

    public Transform target;
    public float smooth = 0.3f;
    public float distance;
    public float height;

    private float yVelocity = 0.0f;

    public Animator ani;
    public GameObject robot;
    public GameObject shoot;

    void Start() {
        ani.enabled = false;
        var playerControl = robot.GetComponent<playerController>();
        playerControl.enabled = true;
        var shootControl = shoot.GetComponent<Shooter>();
        shootControl.enabled = true;
    }


    void Update () {
        float yAngle = Mathf.SmoothDampAngle(transform.eulerAngles.y,
            target.eulerAngles.y,
            ref yVelocity, smooth);
        Vector3 position = target.position;
        position += Quaternion.Euler(0, yAngle, 0) * new Vector3(0, height, -distance);
        transform.position = position;
        transform.LookAt(target);
	}
}
