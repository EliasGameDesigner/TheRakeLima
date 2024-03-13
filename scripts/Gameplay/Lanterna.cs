using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lanterna : MonoBehaviour
{

    public Light luz;
    public AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(0))
        {
            audio.Play();
            luz.enabled = !luz.enabled;
        }
    }
}
