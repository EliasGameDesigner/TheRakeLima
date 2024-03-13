using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public struct Weapon_info
{
    public string name;
    public Sprite sprite;
    public GameObject Model;
}

[CreateAssetMenu(fileName = "Data", menuName = "ScriptableObjects/WeaponData", order = 1)]
public class WeaponData : ScriptableObject
{
   public List<Weapon_info> weapons;
   
}



