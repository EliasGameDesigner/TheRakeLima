using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{


    /*
    public GameObject weaponObject;
    private GameObject m�o;


    private void Awake()
    {
        selectionWhell = FindObjectOfType<SelectionWhell>();
        m�o = GameObject.Find("WeaponLocal");
       // weaponObject = new GameObject();

    }

    
    void Update()
    {

        //Mostra/desmostra o inventario e coloca o item na m�o
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            
        }


        if (Input.GetKeyUp(KeyCode.Tab))
        {
           

            
            GameObject selectedWeapon = selectionWhell.selectedWeapon;

            // Verifica se a nova arma � diferente da atual
            if (selectedWeapon.name.Replace("(Clone)", "") != weaponObject.name.Replace("(Clone)", ""))
            {
                // Destruir o objeto da arma atual se ele existir
                if (weaponObject != null)
                {
                    Destroy(weaponObject);
                }


                // Instanciar o novo objeto da arma e definir seu pai e posi��o
                weaponObject = Instantiate(selectedWeapon, m�o.transform);

                
                weaponObject.transform.position = m�o.transform.position;
                weaponObject.transform.rotation = m�o.transform.rotation;
            }

            



        }

        if (weaponObject == null)
        {
            GameObject vazio = Instantiate(selectionWhell.weaponData.weapons[4].Model);
            weaponObject = vazio;
            weaponObject.transform.SetParent(m�o.transform);
            weaponObject.transform.position = m�o.transform.position;
            weaponObject.transform.rotation = m�o.transform.rotation;


        }



    }*/
}
