using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class BeginMenu : MonoBehaviour
{
    private GameObject[] btnWeapons;
    private GameObject[] btnArmors;

    private List<Weapons> weapons = new List<Weapons>(); //Оружие элементаля
    private List<Armors> armors = new List<Armors>(); //Броня элементаля

   

    


    [SerializeField]
    private GameObject panelWeapon;


    [SerializeField]
    private GameObject panelArmor;

    [SerializeField]
    private GameObject selectedWeapon;

    [SerializeField]
    private GameObject selectedArmor;

    [SerializeField]
    private Characteristic characteristic;

    private void Awake()
    {
        panelWeapon.SetActive(false);
        panelArmor.SetActive(false);

        btnWeapons = new GameObject[3];
        btnWeapons[0] = GameObject.Find("Button_Weapon1");
        btnWeapons[1] = GameObject.Find("Button_Weapon2");
        btnWeapons[2] = GameObject.Find("Button_Weapon3");

        btnArmors = new GameObject[3];
        btnArmors[0] = GameObject.Find("Button_Armor1");
        btnArmors[1] = GameObject.Find("Button_Armor2");
        btnArmors[2] = GameObject.Find("Button_Armor3");

        weapons.AddRange(Resources.LoadAll<Weapons>("Data/Weapons/"));
        armors.AddRange(Resources.LoadAll<Armors>("Data/Armors/"));
    }

    private void Start()
    {
        RandomItem();
    }

    public void NewGame()
    {
        if (selectedWeapon.GetComponent<MouseOnItem>().Weapon != null && selectedArmor.GetComponent<MouseOnItem>().Armor != null)
        {
            characteristic.Weapon = selectedWeapon.GetComponent<MouseOnItem>().Weapon;
            characteristic.Armor = selectedArmor.GetComponent<MouseOnItem>().Armor;
            SceneManager.LoadScene("Main", LoadSceneMode.Single);
        }

        if (selectedWeapon.GetComponent<MouseOnItem>().Weapon == null)
        {
            Debug.Log("Нет оружия");
        }

        if (selectedArmor.GetComponent<MouseOnItem>().Armor == null)
        {
            Debug.Log("Нет брони");
        }
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
    }

    private void RandomItem()
    {
        int random = Random.Range(0, weapons.Count);
        for (int i = 0; i < 3; i++)
        {
            //Оружия
            random = Random.Range(0, weapons.Count);
            btnWeapons[i].GetComponent<MouseOnItem>().Weapon = weapons[random];
            btnWeapons[i].GetComponent<Image>().sprite = weapons[random].SpriteWeapon;
            weapons.RemoveAt(random);

            //Броня
            random = Random.Range(0, armors.Count);
            btnArmors[i].GetComponent<MouseOnItem>().Armor = armors[random];
            btnArmors[i].GetComponent<Image>().sprite = armors[random].SpriteArmor;
            armors.RemoveAt(random);
        }
    }
}
