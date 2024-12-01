using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using TMPro;
using UnityEngine;
using UnityImage = UnityEngine.UI.Image;
using EditorImage = Microsoft.Unity.VisualStudio.Editor.Image;
using UnityEngine.UI;
using UnityEditor.SearchService;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;


public class detectarColision : MonoBehaviour
{
    public personaje logicaPersonaje;
    public TextMeshProUGUI contador;
    public UnityImage barraVida;

    public AudioSource audioAtaque;

    

    int puntos = 10;
    float vida = 100;

    void Start()     
    {
        if (audioAtaque == null)
        {
            Debug.LogError("No se asignó un AudioSource para 'audioAtaque' en el Inspector.");
        }
        contador.text = "10";
        barraVida.fillAmount = 1;


    }
    



    private void OnTriggerEnter(Collider collider)
    {
        // Detecta la colisión con diferentes cubos y muestra mensajes en la consola
        if (collider.name == "CubeR")
        {
            Debug.Log("Choco con el cuadro rojo ABC");
        }

        if (collider.name == "Cube (2)")
        {
            Debug.Log("Entro con el cuadro verde ABC");
            
        }
        
        if(collider.tag == "arma"){
            Debug.Log("Daño");
            vida -=20;
            barraVida.fillAmount = vida /100;
             if(vida <= 0){
                SceneManager.LoadScene(2);
              }
            //sonido de ataque
            // Reproduce el sonido de ataque
             if (audioAtaque != null)
            {
                audioAtaque.Play();
            }

        }


    }

    private void OnTriggerExit(Collider collider)
    {
        if (collider.name == "CubeR")
        {
            Debug.Log("Salio");
        }

        if (collider.name == "Cube (2)")
        {
            Debug.Log("Salio con el cuadro verde ABC");
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "coins")
        {
            Destroy(collision.collider.gameObject);
            puntos --;
            contador.text = puntos.ToString();

            if(puntos <=0){
                SceneManager.LoadScene(1);
            }
        }

        //CUANDO COLISIONA CON TAG PRUEBA AUMENTA VELOCIDAD
        if (collision.collider.tag == "prueba")
        {
            Debug.Log("Colisión con el objeto de prueba, velocidad aumentada.");
            logicaPersonaje.AumentarVelocidadTemporal();
            Destroy(collision.collider.gameObject); // Elimina el objeto si es necesario
        }

        if (collision.collider.tag == "masvida"){

            Destroy(collision.collider.gameObject);
              vida +=10;
              barraVida.fillAmount = vida /100;
              
        }
    }
}
