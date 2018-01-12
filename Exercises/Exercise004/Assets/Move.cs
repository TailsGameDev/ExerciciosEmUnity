using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    //H e V armazenam os Inputs Vertical e Horizontal
    public static float H, V;

    //dir é a direção do movimento
    Vector3 dir;

    //vParameter é a velocidade
    public float vParameter;

    //positionFreezed é para "congelar" o movimento.
    bool PositionFreezed;

    //incremento é o que deve ser somado à posição atual para calcular a próxima
    Vector3 incremento;

	void Start () {
        //faz v = 5 no começo
        vParameter = 5;

        //a posição não começa congelada
        PositionFreezed = false;
	}
	
	void Update () {
        //capturando e armazenando os Inputs
        H = Input.GetAxis("Horizontal");
        V = Input.GetAxis("Vertical");

        //montando o vetor direção
        dir = new Vector3(H, 0, V);
    }

    private void FixedUpdate()
    {
        //incremento é calculado considerando direção, velocidade, e o tempo de cada frame
        incremento = dir * vParameter * Time.deltaTime;

        //translada o objeto (move-o) somando o incremento à posição atual
        transform.Translate(incremento);
    }

    //quando há colisão, a posição deve ser travada para que ela não atravesse as coisas
    private void OnCollisionEnter(Collision collision)
    {
        PositionFreezed = true;
    }

    //se ela mesmo assim entrou um pouco, a posição deve ser recalculada também
    private void OnCollisionStay(Collision collision)
    {
        PositionFreezed = true;
    }

    //quando ela sai de um colisor, ela pode se mexer.
    private void OnCollisionExit(Collision collision)
    {
        PositionFreezed = false;
    }

    //depois de todas as contas
    private void LateUpdate()
    {
        //se a posição está como congelada
        if (PositionFreezed)
        {
            //remova o incremento que foi somado e um pouquinho mais.
            transform.position = (transform.position - incremento*1.1f);
        }
    }
}
