using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//UnityEngine.UI incluída para usar texto e Slider
using UnityEngine.UI;

public class HitHim : MonoBehaviour {

    //gs será o game object que contém o componente slider
    GameObject gs;

    //s será o componente slider, que é tipo uma barrinha de arrastar comum para volume
    Slider s;

    //MaxHealth será a vida máxima. Ou, o valor máximo do slider
    public float MaxHealth;

    //Health será a vida atual, ou valor atual o slider
    float Health;

    // D será o Damage, Dano, que o personagem recebe a cada evento.
    public float D;

    //RS é um game object para fazer a tela avermelhar. Red Screen -> RS
    public GameObject RS;

    //anim é o componente Animator do objeto, para gerenciar as animações
    Animator anim;

    //AS é o componente AudioSource desse objeto, isto é, o inimigo
    AudioSource AS;

    //DS é o Death Sound, o som do inimigo morrendo;
    AudioClip DS;

    //Booleana para saber se o som de morte DS já foi executado
    bool DSPlayed;

	void Start () {

        //capturando objeto pela Tag slider, atribuída na Unity
        gs = GameObject.FindGameObjectWithTag("slider");

        //armazenando o componente slider na variável s
        s = gs.GetComponent<Slider>();

        //vida atual recebe a vida máxima no start
        Health = MaxHealth;

        //armazenando o componente Animator em anim
        anim = GetComponent<Animator>();

        //armazenando o componente AudioSource em AS
        AS = GetComponent<AudioSource>();

        //carrega o arquivo dead1.wav da pasta Resources como um AudioClip
        DS = Resources.Load("dead1") as AudioClip;

        //o DS ainda não foi executado no começo
        DSPlayed = false;
    }
	
	void Update () {

        //Faz a propriedade HP do animator ser igual à variável Health
        anim.SetFloat("HP", Health);

        //quando aperta espaço, se a vida é maior que zero, dá um hit, portanto chama umas funções
        if (Input.GetKeyDown(KeyCode.Space) && Health > 0)
        {
            SubtractLife();
            RedScreen();
            AnimaInimigo();
            if(Health > 0)
                SomDeHit();
        }

        //restaura a vida do inimigo ao apertar R
        if (Input.GetKeyDown(KeyCode.R)) {
            Health = MaxHealth;
            s.value = Health;
            //como a vida enxe, o boneco fica vivo, então não morreu ainda. Som de morte = false
            DSPlayed = false;
        }

        //Verificações e decide se toca o som de morte DS ou não, e faz DSPlayed = true
        GerenciaDeathSound();
	}

    //Subtrai a vida do personagem, ou reduz valor do Slider
    void SubtractLife()
    {
        //Subtrai o dano da vida atual, atribuindo resultado à vida atual.
        Health = Health - D;

        //deixa o Slider habilitado para Input
        s.interactable = true;

        //Altera valor do Slider usando a variável Health, que é a vida atual
        s.value = Health;

        //desabilita o Input para o Slider
        s.interactable = false;
    }

    //faz a tela ficar vermelha através de um objeto transparente colocado em frente à câmera
    void RedScreen()
    {
        //ativa, ele, fazendo com que apareça
        RS.SetActive(true);
        // invoca a função para desativá-lo com 0.1 segundo de delay
        Invoke("DesativarObjeto", .1f);
    }

    //desativa o objeto vermelho com transparência, fazendo-o  desaparecer
    void DesativarObjeto()
    {
        RS.SetActive(false);
    }

    //gerencia animação do inimigo tomando dano
    void AnimaInimigo()
    {
        //faz o bool TomaDano, de anim, ser verdadeiro
        anim.SetBool("TomaDano", true);
        //chama uma função para fazer o TomaDano falso após 0.1 segundo
        Invoke("DestomaDano", 0.1f);
    }

    //torna o booleano TomaDano falso.
    void DestomaDano()
    {
        anim.SetBool("TomaDano", false);
    }

    void SomDeHit()
    {
        AS.Play();
    }

    //Gerencia o Som de Morte DS
    void GerenciaDeathSound()
    {
        // Verifica se a vida é zero e se já foi excutado o som
        if (Health == 0 && DSPlayed == false)
        {
            //Executa o som
            AS.PlayOneShot(DS);
            //Informa que o som foi executado fazendo DSPlayed = true.
            DSPlayed = true;
        }
    }
}
