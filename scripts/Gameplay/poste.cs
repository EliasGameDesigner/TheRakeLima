using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poste : MonoBehaviour
{
    private Animator meuAnimator;

    // Start is called before the first frame update
    void Start()
    {
        meuAnimator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void Consertado(){
        
        meuAnimator.SetBool("funcionando", true);
    }
    public void Bleckaut() 
    {
        meuAnimator.SetBool("funcionando", false);
    }

   public  void Acender(){
        meuAnimator.SetBool("Pisca", true);
    }
    void Apagar(){
        meuAnimator.SetBool("Pisca", false);
    }
}
