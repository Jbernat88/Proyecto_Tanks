using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollision : MonoBehaviour
{
    public ParticleSystem particulas;
    public ParticleSystem wall;
    public ParticleSystem cofres;
    public ParticleSystem player;

    private void OnTriggerEnter(Collider otherCollider)
    {
        if(gameObject.CompareTag("Proyectil")&& otherCollider.gameObject.CompareTag("Enemy"))
        {
            //Si la bala colisiona con un enemigo se destruyen ambos
            Destroy(gameObject);//Bala
            Destroy(otherCollider.gameObject);//Enemigo

            particulas = Instantiate(particulas, transform.position, particulas.transform.rotation);
            particulas.Play();
        }

        if (gameObject.CompareTag("Proyectil") && otherCollider.gameObject.CompareTag("Wall"))
        {
            //Si la bala colisiona con una Pared o Suelo se destruye
            Destroy(gameObject);

            wall = Instantiate(wall, transform.position, wall.transform.rotation);
            wall.Play();
        }

        if (gameObject.CompareTag("Proyectil") && otherCollider.gameObject.CompareTag("Chest"))
        {
            //Si la bala colisiona con un Cofre se destruyen ambos
            Destroy(gameObject);
            Destroy(otherCollider.gameObject);//Cofre

            cofres = Instantiate(cofres, transform.position, cofres.transform.rotation);
            cofres.Play();
        }

        if (gameObject.CompareTag("Bullet") && otherCollider.gameObject.CompareTag("Wall"))
        {
            //Si la bala colisiona con una Pared o Suelo se destruye
            Destroy(gameObject);

            wall = Instantiate(wall, transform.position, wall.transform.rotation);
            wall.Play();
        }

    }
}
