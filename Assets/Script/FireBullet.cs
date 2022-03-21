using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireBullet : MonoBehaviour
{
    public GameObject bullet;
    [SerializeField]
    private float timer = 2f;//tiempo de disparo de la torreta
   //private float timerCount = 0f;

    [SerializeField]
    private int counter;
    private int maxCounter = 9999;//Max de disparos
    // Start is called before the first frame update
    void Start()
    {
        StartCoroutine(FireBullets_CR());
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator FireBullets_CR()
    {
        Debug.Log("Inicio coroutine");
        for(int i=0; i<maxCounter; i++)
        {
            counter++;
            Instantiate(bullet, transform.position, transform.rotation);//Se instancia la bala
            yield return new WaitForSeconds(timer);//Se vuelve a instanciar dependiendo de la variable timer
        }

        Debug.Log("Fin courotin");
    }
}
