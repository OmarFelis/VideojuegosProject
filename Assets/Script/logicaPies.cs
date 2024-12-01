using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class logicaPies : MonoBehaviour
{
    public personaje logicaPersonaje;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerStay(Collider collider){
        logicaPersonaje.puedoSaltar = true;
    }

    private void OnTriggerExit (Collider collider){
        logicaPersonaje.puedoSaltar = false;
    }
}
