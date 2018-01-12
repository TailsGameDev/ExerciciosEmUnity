using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//This script sends a message to other if there is a collision and the bool K is true.

public class Kick : MonoBehaviour {

    //criando bool K
    bool K;

	void Start () {
		
	}
	
	void Update () {
        //Verifica a tecla espaço foi apertada
        if (Input.GetButtonDown("Jump"))
        {
            //chama o método KickTrue depois de 0.2 segundos
            Invoke("KickTrue", 0.2f);
        }
	}

    //faz K = true e invoca o KickFalse
    void KickTrue()
    {
        K = true;
        Invoke("KickFalse", 0.1f);
    }

    //Volta o K para false
    void KickFalse()
    {
        K = false;
    }

    //se há algo dentro do colisot desse objeto, é mandada uma mensagem para que o método Fall seja executado.
    private void OnTriggerStay(Collider other)
    {
        //verifica se K é true
        if (K == true)
        {
            other.SendMessage("Fall");
            //faz o K falso de novo
            K = false;
        }
    }
}
