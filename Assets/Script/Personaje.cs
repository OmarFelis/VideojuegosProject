using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using Unity.VisualScripting;
using UnityEngine;

public class personaje : MonoBehaviour
{
    public float velocidadMovimiento = 5.0f;
    public float velocidadRotacion = 200.0f;
    private Animator anima;
    public float x, y;
    public Rigidbody rb;
    public float fuerzaDeSalto = 8;
    public bool puedoSaltar;
    private float velocidadOriginal;
    public ParticleSystem velocidadParticulas; // Referencia al sistema de partículas

    void Start()
    {
        anima = GetComponent<Animator>();
        puedoSaltar = false;
        velocidadOriginal = velocidadMovimiento; // Guarda la velocidad original

        if (velocidadParticulas != null)
        {
            velocidadParticulas.Stop(); // Asegúrate de que el sistema de partículas esté detenido al inicio
        }
    }

    private void FixedUpdate()
    {
        transform.Translate(0, 0, y * Time.deltaTime * velocidadMovimiento);
        transform.Rotate(0, x * Time.deltaTime * velocidadRotacion, 0);
    }

    void Update()
    {
        x = Input.GetAxis("Horizontal");
        y = Input.GetAxis("Vertical");

        anima.SetFloat("EjeX", x);
        anima.SetFloat("EjeY", y);

        if (puedoSaltar)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                anima.SetBool("salte", true);
                rb.AddForce(new Vector3(0, fuerzaDeSalto, 0), ForceMode.Impulse);
            }
            anima.SetBool("tocoSuelo", true);
        }
        else
        {
            estoyCayendo();
        }
    }

    public void estoyCayendo()
    {
        anima.SetBool("tocoSuelo", false);
        anima.SetBool("salte", false);
    }

    public void AumentarVelocidadTemporal()
    {
        StartCoroutine(AumentarVelocidadCoroutine());
    }

    //FUNCION PARA AUMENTAR LA VELOCIDAD PERSONAJE
    private IEnumerator AumentarVelocidadCoroutine()
    {
        velocidadMovimiento *= 2; // Duplica la velocidad
        if (velocidadParticulas != null)
        {
            velocidadParticulas.Play(); // Activa las partículas
        }

        yield return new WaitForSeconds(2); // Espera 2 segundos

        velocidadMovimiento = velocidadOriginal; // Restablece la velocidad original

        if (velocidadParticulas != null)
        {
            velocidadParticulas.Stop(); // Detiene las partículas
        }
    }
}
