using System.Collections;
using System.Collections.Generic;

using UnityEngine;
using UnityEngine.Events;


interface IInteractable
{
    public void Interact();
}

interface ISegurar
{
   
}

public class Interactor : MonoBehaviour
{

    [SerializeField]
    private UnityEvent Interagindo;


    public Transform InteractionSource;
    public float InteractRange;

    int LayerMask = 6;

    // Start is called before the first frame update
    void Start()
    {
        
    }


    public void Interagir()
    {
        Ray r = new Ray(InteractionSource.position, InteractionSource.forward);
        if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
        {
            if (hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
            {
                interactObj.Interact();
            }


            if (hitInfo.collider.gameObject.TryGetComponent(out Gerador gerador))
            {
                gerador.Segurando = true;
                Interagindo.Invoke();
            }


        }
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E)) 
        {
            Ray r = new Ray(InteractionSource.position, InteractionSource.forward);
            if(Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if(hitInfo.collider.gameObject.TryGetComponent(out IInteractable interactObj))
                {
                    interactObj.Interact();
                }


                if(hitInfo.collider.gameObject.TryGetComponent(out Gerador gerador))
                {
                    gerador.Segurando = true;
                    Interagindo.Invoke();
                }
                

            }



        }

        if(Input.GetKeyUp(KeyCode.E))
        {
            Ray r = new Ray(InteractionSource.position, InteractionSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                if (hitInfo.collider.gameObject.TryGetComponent(out Gerador gerador))
                {
                    gerador.Segurando = false;
                    Interagindo.Invoke();
                }
            }



        }
        






    }
}
