using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodaGira : MonoBehaviour {

    //serão variáveis para armazenar o Input horizontal e vertical, da classe Move, que é outro script na pasta Assets
    public float ho, ve;
	
	void Update () {
        //capturando H e V vindas da classe Move. H e V são variáveis estáticas. Caso não fossem, o procedimento usaria GetComponent<Script>()
        ho = Move.H;
        ve = Move.V;

        //Verifica se os inputs são zero ou muito próximo disso
        if (Mathf.Abs(ho) + Mathf.Abs(ve) > 0.1f) //o lookAt faz o eixo Z desse objeto apontar para o ponto passado como parâmetro
        transform.LookAt(transform.position + new Vector3(ho, 0, ve));
        //o ponto se trata da posição desse objeto mais a direção do movimento
    }
}
