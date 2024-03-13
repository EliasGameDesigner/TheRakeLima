using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class SelectionWhell : MonoBehaviour
{
    public Transform slotPrefab;
    public WeaponData weaponData;

    RectTransform slotParent;
    RectTransform background;
    TextMeshProUGUI weponName;

    List<GameObject> slots = new List<GameObject>();

    public int slotsQtt = 4;

    float distance = 300f;

    float angleInterval = 0;

    public GameObject selectedWeapon;
    
    private void Awake()
    {
        background = transform.GetChild(0).GetComponent<RectTransform>();
        slotParent = transform.GetChild(1).GetComponent<RectTransform>();
        weponName =  transform.GetChild(2).GetComponent<TextMeshProUGUI>();

        selectedWeapon = weaponData.weapons[0].Model;
    }

    // Start is called before the first frame update
    void Start()
    {

        for(int i = 0; i< slotsQtt; ++i)
        {
            GameObject newSlot = Instantiate(slotPrefab, slotParent).gameObject;
            slots.Add(newSlot);

            Image weaponImage = newSlot.transform.GetChild(0).GetComponent<Image>();

            weaponImage.sprite = weaponData.weapons[i].sprite;
            weaponImage.SetNativeSize();
            
        }

        angleInterval = 360f / slotsQtt;

        for (int i = 0; i < slotsQtt; ++i)
        {

            var angle = (angleInterval * i) * Mathf.Deg2Rad;

            Vector2 position = new Vector2(Mathf.Cos(angle), Mathf.Sin(angle)) * distance;

            slots[i].GetComponent<RectTransform>().localPosition = position;
            slots[i].GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, angle * Mathf.Rad2Deg - 90);

            Transform weponImage = slots[i].transform.GetChild(0);
            weponImage.GetComponent<RectTransform>().localRotation = Quaternion.Euler(0, 0, -angle * Mathf.Rad2Deg + 90);
        }
        gameObject.SetActive(false);
    }

    public void Open()
    {
        gameObject.SetActive(true);
    }
    public void Close()
    {
        gameObject.SetActive(false);
    }

    void Selection()
    {
        Vector2 mousePos = Camera.main.ScreenToViewportPoint(Input.mousePosition);
        Vector2 mouseDir = (mousePos - Vector2.one * 0.5f).normalized;

        for (int i = 0; i < slots.Count; ++i)
        {
            var angle = Vector2.Angle(slots[i].transform.up,mouseDir);

            Image slotImage = slots[i].GetComponent<Image>();
            if (angle <= angleInterval / 2)
            {
                slotImage.color = Color.Lerp(slotImage.color, Color.white, 0.01f);
                weponName.text = weaponData.weapons[i].name;
                selectedWeapon = weaponData.weapons[i].Model;
            }
            else
            {
                slotImage.color = Color.Lerp(slotImage.color, Color.white * 0.04f, 0.01f);
            }
        }




       
    }

    // Update is called once per frame
    void Update()
    {
        Selection();
    }
}
