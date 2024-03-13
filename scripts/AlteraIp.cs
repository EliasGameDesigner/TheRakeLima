using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using FishNet.Transporting.Tugboat;

public class AlteraIp : MonoBehaviour
{

    public TMP_InputField ipTexto;

    public Tugboat tugboat;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (ipTexto.text == "")
        {
            ipTexto.text = "localhost";
        }

        tugboat.SetClientAddress(ipTexto.text);
    }
}
