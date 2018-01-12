using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Esse script faz o objeto ter o mesmo transform de um objeto com a tag Player.
//Ele serve para que uma Câmera seja filha dele, e siga o Player.

public class CamFollow : MonoBehaviour {

    //Criando variável Player do tipo GameObject
    GameObject Player;

	void Start () {
        //Capturando o GameObject com a tag Player
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	
    //LateUpdate é usado para calcular a posição da câmera depois da posição do jogador.
	void LateUpdate () {
        //a posição desse objeto recebe a posição do player todo frame.
        transform.position = Player.transform.position;
	}
}
