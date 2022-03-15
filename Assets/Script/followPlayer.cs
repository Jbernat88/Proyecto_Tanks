using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followPlayer : MonoBehaviour
{
    public float speedV;
    public float speedH;

    private float yaw;
    private float pitch;

    public GameObject cabina;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch += speedV * Input.GetAxis("Mouse Y") * Time.deltaTime;
        pitch=Mathf.Clamp(pitch, -20, 0);

        cabina.transform.Rotate(Vector3.up, yaw * Time.deltaTime);
        //transform.Rotate(Vector3.right, pitch);
    }
}
