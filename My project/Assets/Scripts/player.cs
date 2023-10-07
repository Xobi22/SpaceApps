using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player : MonoBehaviour
{
    public float velocidadH = 1.5f;
    public float velocidadV = 2.5f;
    float multispeed = 1.5f;
    float hori;
    float verti;
    [SerializeField]
    private GameObject laser;
    public float tiempoDeDisparo = 0.5f;
    private float puedoDisparar = 0.0f;
    int lives = 3;
    public bool TripleShoot = false;
    public bool HyperSpeed = false;
    public bool shield = false;
    public GameObject tripleShootPrefab;
    public GameObject shieldsprite;
    private GameManager gameManager;
    private AudioSource LazerSound;
    public GameObject[] damageAnim;
    private int hitCount = 0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Movimiento();
    }

    void Movimiento()
    {
        hori = Input.GetAxis("Horizontal");
        verti = Input.GetAxis("Vertical");

        if (HyperSpeed == false) //verificar que el usuario no tenga el PU Speed
        {
            transform.Translate(Vector3.right * Time.deltaTime * velocidadH * hori); // Nos permite mover a un objeto
            transform.Translate(Vector3.up * Time.deltaTime * velocidadV * verti);
        }
        else
        {
            transform.Translate(Vector3.right * Time.deltaTime * velocidadH * hori * multispeed); // Nos permite mover a un objeto
            transform.Translate(Vector3.up * Time.deltaTime * velocidadV * verti * multispeed);
        }


        // Limite de movimiento en la pantalla
        if (transform.position.x < -10.5f) // condiciones if que hacen preguntas
        {
            //Debug.Log("El cubo toco YA la parte izquierdo de la pantalla");
            transform.position = new Vector3(10.5f, transform.position.y, 0);
        }
        else if (transform.position.x > 10.5f)
        {
            transform.position = new Vector3(-10.5f, transform.position.y, 0);
        }
        if (transform.position.y > 6)
        {
            transform.position = new Vector3(transform.position.x, -6, 0);
        }
        else if (transform.position.y < -6)
        {
            transform.position = new Vector3(transform.position.x, 6, 0);
        }
    }
}
