using FishNet.Component.Animating;
using FishNet.Object;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;

public class Porta : NetworkBehaviour,IInteractable
{

    [SerializeField]
    private Animator anim;
    [SerializeField]
    private AudioSource audio;

    private bool temEnergia = true;

    private bool valor = true;

    [SerializeField]
    private int consumoEnergia = 50;

    private NetworkAnimator netanim;




    public delegate void EnergiaUsada(int consumo);
    public event EnergiaUsada Usada;


    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        
            
        


    }


    public void Interact()
    {

        if (temEnergia)
        {

            Debug.Log("aquiFoi");
            valor = !valor;

            audio.Play();
            animSetBool(valor);
            
            if (valor)
            {
                
                Debug.Log("consumoFoi");
                Usada(-consumoEnergia);
            }
            else
            {
                Usada(consumoEnergia);
            }

            
            

        }
        else
        {
            
        }

        
    }

    [ServerRpc]
    //reseta quando acaba a energia?
    public void OnEnergia(bool power)
    {
        temEnergia = power;
        anim.SetBool("interagiu", true);
        valor = true;

        
    }

    public void animSetBool(bool boleana)
    {
        anim.SetBool("interagiu", boleana);
        animSetBoolObs(boleana);
    }


    //Fazer um  atualizador de variavel 





    [ObserversRpc] 
    public void Observer(bool power) 
    {
        temEnergia = power;
        anim.SetBool("interagiu", true);
        valor = true;

    }

    public void animSetBoolObs(bool boleana)
    {
        anim.SetBool("interagiu", boleana);
    }





}