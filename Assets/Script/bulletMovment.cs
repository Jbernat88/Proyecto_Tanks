using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletMovment : MonoBehaviour
{
    public float speed = 10f;//Velocidad de la bala   
    public float timelife = 5f;

    public GameObject explosionEffect;
   
    void Start()
    {
        Destroy(gameObject, timelife); //En 5 segundos se destruye la bala
    }

    // Update is called once per frame
    void Update()
    { 
        //Movimiento en forward
        transform.Translate(Vector3.forward * speed * Time.deltaTime);
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player") //Cuando colisione con el player se destruye la bala y se activa el effecto de particulas
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);    
        }

        if (other.tag == "Wall") //Cuando colisione con el player se destruye la bala y se activa el effecto de particulas
        {
            Instantiate(explosionEffect, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }

}
