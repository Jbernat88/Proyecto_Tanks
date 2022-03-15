using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
    public float speed = 30.0f;
    public float turnSpeed = 5f;
    public float horizontalInput;
    public float verticalInput;

    public GameObject proyectil;
    private bool IsCoolDown = true;
    public float shootSpeed= 4f;

    public GameObject canon;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        //Movimiento hacia delante
        transform.Translate(Vector3.forward * speed * Time.deltaTime * verticalInput);
        //Movimiento vertical y horizontal del player con las teclas
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        //Rotación Vertical del player
        transform.Rotate(Vector3.left * speed * Time.deltaTime * verticalInput);

        //Rotación Horizontal del player
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        //Aparición del proyectil
        if (Input.GetKey(KeyCode.Mouse0) && IsCoolDown )
        {
            Instantiate(proyectil, canon.transform.position, canon.transform.rotation);

            StartCoroutine(CoolDown());
        }

    }

    private IEnumerator CoolDown() //Cool Down del disparo
    {
        IsCoolDown = false;
        yield return new WaitForSeconds(shootSpeed);
        IsCoolDown = true;
    }
}
