using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjetoInteragivel : MonoBehaviour, IInteractable
{

public AudioSource audio;
public Animator animator;
public Animation animacao;
bool valor = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    


    public void Interact()
    {
        Debug.Log("aquiFoi");
        valor = !valor;
        
        audio.Play();
        animator.SetBool("interagiu",valor);

    }

}
