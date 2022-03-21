using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    public ParticleSystem fireWorkParticleSystem; //Particulas de la moneda
    private int monedasRecolectables = 0;
    public ParticleSystem explosionParticleSystem;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    // Update is called once per frame
    void Update()
    {
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

        //Rotación Vertical del player
        transform.Rotate(Vector3.left * speed * Time.deltaTime * verticalInput);

        //Rotación Horizontal del player
        transform.Rotate(Vector3.up, turnSpeed * Time.deltaTime * horizontalInput);

        //Aparición del proyectil
        if (Input.GetKey(KeyCode.Mouse0) && IsCoolDown && !GameOver )
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

                monedasRecolectables++; //Cada vez que cogemos una moneda sumamos 1 en el marcador

                Debug.Log(monedasRecolectables);

                fireWorkParticleSystem.Play(); //Particualas

                Instantiate(fireWorkParticleSystem, transform.position, explosionParticleSystem.transform.rotation);
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


}
