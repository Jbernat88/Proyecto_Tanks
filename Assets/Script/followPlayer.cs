using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public float speedV;
    public float speedH;

    private float yaw;
    private float pitch;

    private float xRotation;
    private float yRotation;

    public GameObject cabina;
    public GameObject canon;


    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        yaw = -speedH * Input.GetAxis("Mouse X");
        pitch = speedV * Input.GetAxis("Mouse Y");
        xRotation -= yaw;
        xRotation=Mathf.Clamp(xRotation, -90, 90);

        //cabina.transform.Rotate(Vector3.up, xRotation * Time.deltaTime);
        cabina.transform.localRotation=Quaternion.Euler(0, xRotation, 0);

        yRotation -= pitch;
        yRotation = Mathf.Clamp(yRotation, -40, 40);

      
        canon.transform.localRotation = Quaternion.Euler(yRotation, 0, 0);



    }

}
