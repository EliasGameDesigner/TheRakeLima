using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using UnityEngine;
using UnityEngine.Experimental.GlobalIllumination;

public class Interruotor : MonoBehaviour, IInteractable
{
    public Animator anim;
    public AudioSource AudioInterruptor;
    public AudioSource AudioLampada;
    
    public Light luz;

    public bool valor = false;



    public bool TemEnergia = true;


    public int ConsumoEnergia;

    public delegate void EnergiaUsada(int consumo);
    public event EnergiaUsada Usada;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Interact()
    {
        
        

        if (TemEnergia)
        {
            valor = !valor;

            anim.SetBool("interagiu", valor);


            if (valor)
            {
                AudioLampada.Play();
                luz.range = 9.13f;
                Usada(ConsumoEnergia);
            }
            else
            {
                AudioLampada.Stop();
                luz.range = 0;
                Usada(-ConsumoEnergia);
                
            }

        }
        else
        {
            AudioLampada.Stop();
            luz.range = 0;
        }
        

    }


    public void OnEnergia(bool power)
    {
        TemEnergia = power;
        if(TemEnergia == false)
        {
            AudioLampada.Stop();
            luz.range = 0;
            
        }
        valor = false;
    }



}
