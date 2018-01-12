using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour {

    GameObject Player;

	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player");
	}
	

	void LateUpdate () {
        transform.position = Player.transform.position;
	}
}
