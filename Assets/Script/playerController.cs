using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;



public class playerController : MonoBehaviour
{
    public float speed = 30.0f;//Velocidad del player
    public float turnSpeed = 5f;//Rotacion del player
    public float horizontalInput;
    public float verticalInput;

    public GameObject proyectil;
    private bool IsCoolDown = true;
    public float shootSpeed= 4f;//Velocidad de disparo

    public GameObject canon;

    public int maxHealth = 100;//vida max
    public int currentHealth;
    public HealthBar healthBar; //Variable de la barra de vida

    public bool GameOver;
    public bool Victory;

    public ParticleSystem fireWorkParticleSystem; //Particulas de la moneda
 
    public ParticleSystem explosionParticleSystem;


    public TextMeshProUGUI pointText;
    public int score = 0;
    public int maxScore = 30;
    public int points;

    private SoundManager soundManager;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameOver)//Caraga la pantalla de game over
        {
            SceneManager.LoadScene("GameOver");
        }

        if (Victory)//carga la pantalla de victoria
        {
            SceneManager.LoadScene("Victory");
        }
        if (score == maxScore)//Cuando conseguimos todas las monedas ganamos
        {
            Victory = true;
        }

        //Cuando el valor de la barra es 0 el juego finaliza
        if (currentHealth == 0)
        {
            GameOver = true;
        }


        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        
        if (!GameOver)
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
        }

        //Aparición del proyectil
        if (Input.GetKey(KeyCode.Mouse0) && IsCoolDown && !GameOver )
        {
            Instantiate(proyectil, canon.transform.position, canon.transform.rotation);

            StartCoroutine(CoolDown());

            soundManager.SelecionAudio(0, 0.2f);
        }

    }

    private IEnumerator CoolDown() //Cool Down del disparo
    {
        IsCoolDown = false;
        yield return new WaitForSeconds(shootSpeed);
        IsCoolDown = true;
    }

    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }


    private void OnCollisionEnter(Collision otherCollider)
    {
        if (!GameOver)
        {
            if (otherCollider.gameObject.CompareTag("Money")) //Moneda
            {
                Destroy(otherCollider.gameObject);

                fireWorkParticleSystem.Play(); //Particualas

                Instantiate(fireWorkParticleSystem, transform.position, explosionParticleSystem.transform.rotation);
                UpdateScore(points); //Permite sumar los puntos de cada objeto

                soundManager.SelecionAudio(2, 0.2f);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Bullet") //Cuando la bala colisiona con el player la vida baja 
        {
             TakeDamage(5);
        }

    }

    public void UpdateScore(int pointsToAdd)
    {
        score++;//Linea per actualitzar l'score
        pointText.text = $"Coins: {score}/{maxScore}";

        Debug.Log($"Tienes");
    }

    private void Awake()
    {
        soundManager = FindObjectOfType<SoundManager>();
    }

}
