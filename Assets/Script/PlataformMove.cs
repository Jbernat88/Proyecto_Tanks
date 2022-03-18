using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlataformMove : MonoBehaviour
{
    public GameObject Player;
    public GameObject PLatform;


   
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FixedUpdate()
    {
       
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(gameObject && collision.gameObject.CompareTag("Player"))
        {
            Player.transform.position = transform.position;
        }
    }
}
