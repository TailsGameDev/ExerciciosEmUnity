using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Kick : MonoBehaviour {

    bool K;

	void Start () {
		
	}
	
	void Update () {
        if (Input.GetButtonDown("Jump"))
        {
            Invoke("KickTrue", 0.2f);
        }
	}

    void KickTrue()
    {
        K = true;
        Invoke("KickFalse", 0.1f);
    }

    void KickFalse()
    {
        K = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (K == true)
        {
            other.SendMessage("Fall");
            K = false;
        }
    }
}
