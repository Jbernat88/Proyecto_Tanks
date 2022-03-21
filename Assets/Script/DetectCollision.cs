using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DetectCollision : MonoBehaviour
{
    //Variables de las particulas
    public ParticleSystem particulas;
    public ParticleSystem wall;
    public ParticleSystem cofres;
    public ParticleSystem player;

    private SoundManager soundManager;

    private void OnTriggerEnter(Collider otherCollider)
    {
        if(gameObject.CompareTag("Proyectil")&& otherCollider.gameObject.CompareTag("Enemy"))
        {
            //Si la bala colisiona con un enemigo se destruyen ambos
            Destroy(gameObject);//Bala
            Destroy(otherCollider.gameObject);//Enemigo

            particulas = Instantiate(particulas, transform.position, particulas.transform.rotation);
            particulas.Play();
            soundManager.SelecionAudio(3, 0.5f);
        }

        if (gameObject.CompareTag("Proyectil") && otherCollider.gameObject.CompareTag("Wall"))
        {
            //Si la bala colisiona con una Pared o Suelo se destruye
            Destroy(gameObject);

            wall = Instantiate(wall, transform.position, wall.transform.rotation);
            wall.Play();

            soundManager.SelecionAudio(1, 0.5f);
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

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }
}
