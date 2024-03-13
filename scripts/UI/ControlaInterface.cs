using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ControlaInterface : MonoBehaviour
{
    // Start is called before the first frame update

    public Canvas Menu;
    public Scrollbar Sensi;
    public bool valor;
    public FirstPersonLook camera;

    void Start()
    {
        
    }


    public void ExibirMenu()
    {
        valor = !valor;
        Menu.enabled = valor;
    }

    // Update is called once per frame
    void Update()
    {


        camera.sensitivity = Sensi.value;

    }
}
