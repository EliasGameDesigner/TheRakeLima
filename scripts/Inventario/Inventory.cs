using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{


    /*
    public GameObject weaponObject;
    private GameObject mão;


    private void Awake()
    {
        selectionWhell = FindObjectOfType<SelectionWhell>();
        mão = GameObject.Find("WeaponLocal");
       // weaponObject = new GameObject();

    }

    
    void Update()
    {

        //Mostra/desmostra o inventario e coloca o item na mão
        if (Input.GetKeyDown(KeyCode.Tab))
        {
            
            
        }


        if (Input.GetKeyUp(KeyCode.Tab))
        {
           

            
            GameObject selectedWeapon = selectionWhell.selectedWeapon;

            // Verifica se a nova arma é diferente da atual
            if (selectedWeapon.name.Replace("(Clone)", "") != weaponObject.name.Replace("(Clone)", ""))
            {
                // Destruir o objeto da arma atual se ele existir
                if (weaponObject != null)
                {
                    Destroy(weaponObject);
                }


                // Instanciar o novo objeto da arma e definir seu pai e posição
                weaponObject = Instantiate(selectedWeapon, mão.transform);

                
                weaponObject.transform.position = mão.transform.position;
                weaponObject.transform.rotation = mão.transform.rotation;
            }

            



        }

        if (weaponObject == null)
        {
            GameObject vazio = Instantiate(selectionWhell.weaponData.weapons[4].Model);
            weaponObject = vazio;
            weaponObject.transform.SetParent(mão.transform);
            weaponObject.transform.position = mão.transform.position;
            weaponObject.transform.rotation = mão.transform.rotation;


        }



    }*/
}
