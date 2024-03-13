using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using FishNet.Object;

public class Gerador : MonoBehaviour
{

    private bool consertado;
    public AudioClip AudioParado;
    public AudioClip AudioLigando;

    public Animator animator;


    public AudioSource AudioGlobal;
    public AudioSource Audio;

    public poste[] posteScript;

    public bool Segurando = false;

    private int consumoEnergia;


    public delegate void AlterarEnergia(bool power);

    public event AlterarEnergia Energia;

    public Voltrimetro voltrimetro;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if (!consertado)
        {
            if (Segurando)
            {
                Audio.clip = AudioLigando;
                animator.SetBool("consertando", true);

            }

            if (!Segurando)
            {
                animator.SetBool("consertando", false);
                Audio.clip = AudioParado;
                Audio.Play();

            }


        }


        if (Input.GetKeyDown(KeyCode.Insert))
        {
            Desligar();
        }

        //VOltrimetor 

        if(consumoEnergia >= 100)
        {
            Desligar();
            consumoEnergia= 0;
        }



    }

    
     

    void TocarSom()
    {
        Audio.Play();
    }


    void Funcionando()
    {
        consertado = true;
        animator.SetBool("funcionando", true);
        Audio.clip = AudioParado;
        Audio.Play();

        if (Energia != null)
        {
            Energia(consertado);
        }

    }

    void LigaPoste(){
        foreach(poste obj in posteScript){
            obj.Consertado();
        }
    }

    public void Desligar(){
        animator.SetBool("funcionando", false);
        consertado = false;

        if(Energia != null)
        {
            Energia(consertado);
        }
        foreach (poste obj in posteScript)
        {
            obj.Bleckaut();
        }


    }

    public void Piscar()
    {
        foreach(poste obj in posteScript){
            obj.Acender();
        }
    }


    public void TocarAudioGlobal(){

        AudioGlobal.Play();
        
    }


    public void onAdicionarConsumo(int consumo)
    {
        
        consumoEnergia += consumo;
        Debug.Log("B" + consumoEnergia);
        voltrimetro.onAtualizarConsumo(consumoEnergia);
        Debug.Log("A" + consumo);
        Debug.Log("B" + consumoEnergia);

    }

    




}
