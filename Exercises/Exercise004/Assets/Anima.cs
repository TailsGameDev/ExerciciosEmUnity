using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anima : MonoBehaviour {
    // é o componente animator desse game object
    Animator anim;

    //serão os componentes Horizontal e Vertical de Input
    float H, V;

	void Start () {
        //capturando o componente animator
        anim = GetComponent<Animator>();
	}
	
	void Update () {

        //capturando H e V, que são variáveis estáticas da classe Move;
        H = Move.H;
        V = Move.V;

        //verifica se a tecla espaço foi apertada
        if (Input.GetButtonDown("Jump"))
        {
            //Faz H e V = 0 para que a personagem volte para a animação Idle e possa então ir para Spinkick
            H = 0;
            V = 0;

            //ativa o trigger Spinkick. Uma vez no Idle, a personagem poderá executar a animação Spinkick
            anim.SetTrigger("Spinkick");
        }

	}

    private void FixedUpdate()
    {
        //verifica se há movimento
        if (Mathf.Abs(H) + Mathf.Abs(V) < 0.2f)
        {
            //configura o parâmetro booleano Run do animator como falso
            anim.SetBool("Run", false);
        }
        else
        {
            anim.SetBool("Run", true);
        }

    }
}
