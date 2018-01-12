using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallOrNot : MonoBehaviour {

    //anim é o componente animator desse gameObject, que é a Inimiga
    Animator anim;

	void Start () {
        //armazenando o componente Animator em anim.
        anim = GetComponent<Animator>();
	}
	
    //essa função é chamada em outro script com o método SendMessage.
    void Fall()
    {
        //ativa o trigger referente à queda.
        anim.SetTrigger("DamageDown");
    }
}
