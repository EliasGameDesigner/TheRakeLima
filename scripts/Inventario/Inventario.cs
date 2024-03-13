using FishNet.Object;
using FishNet.Connection;
using FishNet;
using System;
using System.Collections;
using System.Collections.Generic;

using UnityEngine;


public class Inventario : NetworkBehaviour
{

    public GameObject Mao;
    public GameObject[] slotMao;
    public GameObject slotSelecionado;
    public int numeroSlotSelecionado;
    public Objects[] slots;
    public WeaponData data;

    private bool valor;
    public Transform InteractionSource;
    public float InteractRange;


    [HideInInspector] public GameObject spawnedObject;


    public override void OnStartClient()
    {
        base.OnStartClient();
        if (base.IsOwner)
        {

        }
        else
        {
          GetComponent<Inventario>().enabled= false;
        }
    }


    // Start is called before the first frame update
    void Start()
    {
        




    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.E))
        {
            Ray r = new Ray(InteractionSource.position, InteractionSource.forward);
            if (Physics.Raycast(r, out RaycastHit hitInfo, InteractRange))
            {
                Debug.Log("Ray foi");
                if (hitInfo.collider.gameObject.tag == "Objeto")
                {
                    GameObject hit = hitInfo.collider.gameObject;
                    for (int i = 0; i < slots.Length; i++)
                    {
                        if (slots[i] == null)
                        {
                            slots[i] = hit.transform.GetComponent<ObjectType>().objectType;
                            //Instantiate(slots[i].Model, slotMao[i].transform);
                            SpawnObject(slots[i].Model, slotMao[i], this);

                             
                            DespawnObject(hit.gameObject);
                            break;
                        }
                        if (slots[i].name == hit.transform.GetComponent<ObjectType>().name)
                        {
                            Debug.Log("ja possui o objeto");
                        }
                        if (slots[0]  && slots[1])
                        {
                            //Destroy(slotSelecionado.transform.GetChild(0).gameObject);
                            DespawnObject(slotSelecionado.transform.GetChild(0).gameObject);

                            slots[numeroSlotSelecionado] = null;
                            slots[numeroSlotSelecionado] = hit.transform.GetComponent<ObjectType>().objectType;

                            //Instantiate(slots[numeroSlotSelecionado].Model, slotMao[numeroSlotSelecionado].transform);
                            SpawnObject(slots[numeroSlotSelecionado].Model, slotMao[numeroSlotSelecionado], this);

                            DespawnObject(hit.gameObject);
                            break;

                        }
                    }
                }

            }

        }


        if(Input.GetKeyDown(KeyCode.Tab)) 
        {

            AtivaDesativa();

            if (slotMao[0].gameObject.activeSelf)
            {
                slotSelecionado = slotMao[0].gameObject;
                numeroSlotSelecionado = 0;
            }
            else
            {
                slotSelecionado = slotMao[1].gameObject;
                numeroSlotSelecionado = 1;
            }

        }

        

        


    }

    [ServerRpc]
    public void SpawnObject(GameObject obj, GameObject parente, Inventario script)
    {
        GameObject spawned = Instantiate(obj, parente.transform);
        
        
        ServerManager.Spawn(spawned);
        spawned.transform.SetParent(parente.transform);
        
        SetSpawnedObject(spawned, parente, script);
    }


    public void DespawnObject(GameObject obj)
    {
        ServerManager.Despawn(obj);
        SetDespawnObes(obj);
        
    }


    public void AtivaDesativa()
    {
        valor = !valor;

        
        slotMao[0].gameObject.SetActive(!valor);
        slotMao[1].gameObject.SetActive(valor);
    }


    //colocar os negocio no observer pq n ta sincronizando quando o objeto fica visivel ou invisivel a mão


    [ObserversRpc]
    public void SetSpawnedObject(GameObject spawned, GameObject parente, Inventario script)
    {
        script.spawnedObject= spawned;


        spawned.transform.parent = parente.transform;

        

        
    }

    public void SetDespawnObes(GameObject obj)
    {
        ServerManager.Despawn(obj);
    }

   

}
