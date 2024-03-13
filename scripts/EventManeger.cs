using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventManeger : MonoBehaviour
{
    // Start is called before the first frame update

    public  Gerador gerador;
    public Interruotor interruptor;
    public Porta porta;
    public Voltrimetro voltrimetro;




    void Start()
    {
        




        gerador.Energia += interruptor.OnEnergia;
        gerador.Energia += porta.OnEnergia;
        
        porta.Usada += gerador.onAdicionarConsumo;
        interruptor.Usada += gerador.onAdicionarConsumo;
        


    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Conectar()
    {
        voltrimetro = FindObjectOfType<Voltrimetro>();
        gerador.Energia += voltrimetro.OnEnergia;
        gerador.voltrimetro = voltrimetro;

    }
}
