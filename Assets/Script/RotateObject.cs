using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public float speed = 80f;
    public float forwardInput;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
       
      
     //Las Ruedas giran cuando se accionan las teclas "Verticales"
      forwardInput = Input.GetAxis("Vertical");
      transform.Rotate(Vector3.right * speed * Time.deltaTime * forwardInput);
        
       
    }
}
