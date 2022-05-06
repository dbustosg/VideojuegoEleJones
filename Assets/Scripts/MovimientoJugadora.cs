using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoJugadora : MonoBehaviour
{
    // Variables
    [Range(1, 10)] public float speed;
    Rigidbody2D rb2d;
    SpriteRenderer spRd;

    private Animator animator;
    bool isJumping = false;
    [Range(1, 500)] public float potenciaSalto;
    public int gemas;

    //Variable para vida de powerUp
    [Range(0, 5)] public int vida;
    public bool vulnerable; //indica cuando estamos vulnerables
    bool isDead;

    //Para atacar en melee
    public bool isMelee;

    //Control del canvas
    public Canvas canvas;
    private ControlHUD hud;

    //Control objeto GameManager, para el control de vidas al cambiar de escena
    private GameManager gameManager;

    //Control joystick
    public Joystick joystick;
    //Movimiento con joystick
    private float movimientoH;

    //Control botón acuchillar
    private GameObject botonMelee;

    //Control botón pistola
    private GameObject botonShoot;

    //Control del disparo
    public GameObject ShootPrefab;
    public bool isShooting;

    //Reproducción de audio
    public AudioClip saltoSfx;
    public AudioClip vidaSfx;
    public AudioClip shootSfx;
    public AudioClip knifeSfx;
    private AudioSource audioSource; //Quien lo reproduce

    //Este método se ejecuta antes del start cuando se crea la Escena
    private void Awake()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Start is called before the first frame update
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spRd = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        animator.SetBool("isDead", false); //Asignamos a false la variable isDead para no activar la animacion de morir
        vulnerable = true; //Vulnerable = true para que pueda ser dañado
        gemas = 0; //inicializamos las gemas

        //Control de vidas con el game manager
        gameManager = FindObjectOfType<GameManager>();

        //Animación acuchillar
        isMelee = false;
        botonMelee = GameObject.Find("BtnMelee");
        if (!gameManager.tengoCuchillo)
            botonMelee.SetActive(false);

        //Control del canvas
        hud = canvas.GetComponent<ControlHUD>();
        //hud.setVidasTxt(vida); //Control de vidas del HUD, sin el GameManager
        hud.setVidasTxt(gameManager.getVidas());

        //Animación disparar
        isShooting = false;
        botonShoot = GameObject.Find("BtnShoot");
        if (!gameManager.tengoPistola)
            botonShoot.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        //Control de powerUps del HUD

        //Para contar las gemas del nivel:
        //hud.setPowerUpTxt(GameObject.FindGameObjectsWithTag("Diamond").Length);

        hud.setPowerUpTxt(gemas);
    }

    private void FixedUpdate()
    {
        if (!isDead)
        {
            //float movimientoH = Input.GetAxisRaw("Horizontal");

            //Direccion personaje
            if((joystick.Horizontal >= .2f) || (joystick.Horizontal <= -.2f))
                movimientoH = joystick.Horizontal;
            else
                movimientoH = 0f;
            

            rb2d.velocity = new Vector2(movimientoH * speed, rb2d.velocity.y);
            
            //Control de la dirección del muñeco
            if (movimientoH > 0)
                spRd.flipX = false;
            else if (movimientoH < 0)
                spRd.flipX = true;

            //Control de la animación
            if (movimientoH != 0)
                animator.SetBool("isWalking", true);
            else
                animator.SetBool("isWalking", false);

            //Para el salto
            /**
            float movimientoV = joystick.Vertical;
            //if (Input.GetButton("Jump") && !isJumping)
            if(movimientoV >= .5f && !isJumping)
            {
                rb2d.AddForce(Vector2.up * potenciaSalto);
                isJumping = true;
                animator.SetBool("isJumping", isJumping);
            }
            */

            if (gameManager.tengoCuchillo)
                botonMelee.SetActive(true);

            if (gameManager.tengoPistola)
                botonShoot.SetActive(true);

            /*
            //Para usar el cuchillo
            if (Input.GetButton("Fire1") && tengoCuchillo) //pulso la tecla CTRL
            {
                isMelee = true;
                animator.SetBool("isMelee", isMelee);
                Invoke("PararMelee", 2.5f);
            }*/
        }
        else
        {
            rb2d.velocity = new Vector2(0, rb2d.velocity.y);
        }
    }

    //Controlará la colisión contra el suelo, para los saltos
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Suelo") || collision.gameObject.CompareTag("Torre"))
        {
            isJumping = false;
            rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            animator.SetBool("isJumping", isJumping);
        }
    }

    public void IncrementarVida(int cantidad)
    {
        gameManager.aumentarVidas(cantidad);
        hud.setVidasTxt(gameManager.getVidas()); //Actualizamos vidas del HUD
    }

    public void DecrementarVida()
    {
        if (vulnerable && !isDead)
        {
            vulnerable = false;
            gameManager.decrementarVidas();

            if(gameManager.getVidas() <= 0)
            {
                isDead = true;
                animator.SetBool("isDead", isDead);

                Invoke("TerminarPartida", 2f);

            }
            else
            {
                Invoke("HacerVulnerable", 1f);
                spRd.color = Color.red;
            }

            //Reproducir audio de vida
            audioSource.PlayOneShot(vidaSfx);
        }
        //Actualizamos vidas del HUD
        hud.setVidasTxt(gameManager.getVidas());
    }

    private void HacerVulnerable()
    {
        vulnerable = true;
        spRd.color = Color.white;
    }

    private void ReanudarPartida()
    {
        isDead = false;
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        Time.timeScale = 1f;
    }

    public void IncrementarGemas(int cantidad)
    {
        gemas += cantidad;
    }

    //Para activar la mecanica acuchillar
    public void CogerCuchillo()
    {
        gameManager.tengoCuchillo = true;
    }

    private void PararMelee()
    {
        isMelee = false;
        animator.SetBool("isMelee", isMelee);
    }

    //Boton acuchillar
    public void btnMelee()
    {
        isMelee = true;
        animator.SetBool("isMelee", isMelee);
        Invoke("PararMelee", 0.5f);

        //Reproducir audio de cuchillo
        audioSource.PlayOneShot(knifeSfx);
    }

    //Boton salto
    public void btnJump()
    {
        if (!isJumping && !isDead)
        {
            rb2d.AddForce(Vector2.up * potenciaSalto);
            isJumping = true;
            animator.SetBool("isJumping", isJumping);

            //Reproducir audio de salto
            audioSource.PlayOneShot(saltoSfx);
        }
    }

    //Boton disparar
    public void btnShoot()
    {
        //Animación
        isShooting = true;
        animator.SetBool("isShooting", isShooting);
        Invoke("PararShoot", 0.5f);
        Invoke("Disparar", 0.5f);
    }

    //Para activar la mecanica de la pistola
    public void CogerPistola()
    {
        gameManager.tengoPistola = true;
    }

    //Parar animacion disparar
    public void PararShoot()
    {
        isShooting = false;
        animator.SetBool("isShooting", isShooting);
    }

    public void Disparar()
    {
        //Control del disparo
        Shooting scriptShoot = ShootPrefab.GetComponent<Shooting>();

        if (spRd.flipX == false)
        {
            //Ataque hacia la derecha
            scriptShoot.Velocidad = System.Math.Abs(scriptShoot.Velocidad);
        }
        else if (spRd.flipX == true)
        {
            //Ataque hacia la izquierda
            scriptShoot.Velocidad = -System.Math.Abs(scriptShoot.Velocidad);
        }

        //Creamos una instancia del prefab en nuestra escena, concretamente en la posición de nuestro personaje
        Instantiate(ShootPrefab, transform.position, Quaternion.identity);
        
        //Reproducir audio de disparo
        audioSource.PlayOneShot(shootSfx);
    }

    //Terminar partida
    private void TerminarPartida()
    {
        
        gameManager.TerminarJuego(false);

    }

    private void OnTriggerStay2D(Collider2D collider)
    {
        if (collider.gameObject.CompareTag("Meta"))
        {
            PlayerPrefs.SetInt("Gemas", gemas);
            gameManager.TerminarJuego(true);

        }
    }
}
