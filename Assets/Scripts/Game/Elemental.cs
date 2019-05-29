﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Elemental : MonoBehaviour
{
    [Tooltip("Характеристика")]
    [SerializeField]
    private Characteristic characteristicData;

    private List<Weapons> weapons = new List<Weapons>(); //Оружие элементаля
    private List<Armors> armors = new List<Armors>(); //Броня элементаля

    private SpriteRenderer sprite;

    public GameObject panelDiscription; //Описание монстра при начале боя


    //Панель с описанием элементаля
    private Transform[] pnlDiscriptionChildren;

    public Characteristic CharacteristicData
    {
        get
        {
            return characteristicData;
        }
        set
        {
            characteristicData = value;
        }
    }

    private void Awake()
    {   
        weapons.AddRange(Resources.LoadAll<Weapons>("Data/Weapons/"));
        armors.AddRange(Resources.LoadAll<Armors>("Data/Armors/"));
        sprite = GetComponentInChildren<SpriteRenderer>();

        pnlDiscriptionChildren = new Transform[50];

        for (int i = 0; i < panelDiscription.transform.childCount; i++)
        {
            pnlDiscriptionChildren[i] = panelDiscription.transform.GetChild(i);
        }  
    }

    //Красный FF3800 RGB(255, 56, 0)
    //Голубой FFFFFF RGB(255, 255, 255) (Белый цвета, т.к. сама моделька голубая)
    //Зелёный 3EFF00 RGB(62, 255, 0)
    //Фиолетовый 9246B0 RGB(146, 70, 176)

    private void Start()
    {
        int random = Random.Range(0, 4);
        switch(random)
        {
            case 0:
                sprite.color = Color.red;
                characteristicData.TypePerson = Characteristic.Type.Lava;
                break;

            case 1:
                sprite.color = Color.white;
                characteristicData.TypePerson = Characteristic.Type.Ocean;
                break;

            case 2:
                sprite.color = Color.green;
                characteristicData.TypePerson = Characteristic.Type.Forest;
                break;

            case 3:
                sprite.color = new Color(0.757311f, 0.3685475f, 0.7735849f, 1f);
                characteristicData.TypePerson = Characteristic.Type.Air;
                break;
        }
        RandomWeapon();
        RandomArmor();
    }

    private void Update()
    {
    }
    /// <summary>
    /// Экипировка рандомный оружием
    /// </summary>
    private void RandomWeapon()
    {
        //Очистка массива от ненужного оружия
        List<Weapons> search = new List<Weapons>();
        foreach (Weapons field in weapons)
        {
            if (field.TypeWeapon.ToString() != characteristicData.TypePerson.ToString())
            {
                search.Add(field);
            }
        }
        foreach (Weapons field in search)
        {
            weapons.Remove(field);
        }

        //Экипировка элементаля оружием
        int random = Random.Range(0, weapons.Count);
        characteristicData.Weapon = weapons[random];
    }

    /// <summary>
    /// Экипировка рандомной бронёй
    /// </summary>
    private void RandomArmor()
    {
        //Очистка массива от ненужной брони
        List<Armors> search = new List<Armors>();
        foreach (Armors field in armors)
        {
            if (field.TypeArmor.ToString() != characteristicData.TypePerson.ToString())
            {
                search.Add(field);
            }
        }
        foreach (Armors field in search)
        {
            armors.Remove(field);
        }

        //Экипировка элементаля бронёй
        int random = Random.Range(0, armors.Count);
        characteristicData.Armor = armors[random];
    }

    //private void OnMouseDown()
    //{
    //    Debug.Log("HP: " + characteristicData.HP);
    //    Debug.Log("ОД: " + characteristicData.ActionPoints);
    //    switch(characteristicData.TypePerson)
    //    {
    //        case Characteristic.Type.Lava:
    //            Debug.Log("Тип элементаля: " + "Лава");
    //            break;

    //        case Characteristic.Type.Ocean:
    //            Debug.Log("Тип элементаля: " + "Океан");
    //            break;

    //        case Characteristic.Type.Forest:
    //            Debug.Log("Тип элементаля: " + "Камень и лес");
    //            break;

    //        case Characteristic.Type.Air:
    //            Debug.Log("Тип элементаля: " + "Воздух и гроза");
    //            break;

    //    }
    //    Debug.Log("Название оружия: " + characteristicData.Weapon.NameWeapon);
    //    Debug.Log("Название брони: " + characteristicData.Armor.NameArmor);
    //}

    /// <summary>
    /// Начало боя
    /// </summary>
    /// <param name="col"></param>
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.CompareTag("Player"))
        {
            panelDiscription.SetActive(true);

            pnlDiscriptionChildren[4].GetComponent<Text>().text = characteristicData.HP.ToString();
            pnlDiscriptionChildren[5].GetComponent<Text>().text = characteristicData.ActionPoints.ToString();
            pnlDiscriptionChildren[7].GetComponent<Text>().text = characteristicData.TypePerson.ToString();
            pnlDiscriptionChildren[9].GetComponent<Text>().text = characteristicData.Weapon.NameWeapon.ToString();
            pnlDiscriptionChildren[11].GetComponent<Text>().text = characteristicData.Armor.NameArmor.ToString();

            //GameObject go = Instantiate(gameObject, Vector3.zero, Quaternion.identity);
            //go.transform.SetParent(panelDiscription.transform);
            
            pnlDiscriptionChildren[12].GetComponent<Elemental>().CharacteristicData = gameObject.GetComponent<Elemental>().CharacteristicData;
            pnlDiscriptionChildren[12].GetComponent<Elemental>().panelDiscription = gameObject.GetComponent<Elemental>().panelDiscription;

            pnlDiscriptionChildren[12].GetComponentInChildren<SpriteRenderer>().sprite = gameObject.GetComponentInChildren<SpriteRenderer>().sprite;
            pnlDiscriptionChildren[12].GetComponentInChildren<SpriteRenderer>().color = gameObject.GetComponentInChildren<SpriteRenderer>().color;
        }
    }
}
