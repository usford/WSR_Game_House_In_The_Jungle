using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MouseOnItem : MonoBehaviour
{
    [Tooltip("Оружием")]
    [SerializeField]
    private GameObject panelWeapon;

    [Tooltip("Панель с бронёй")]
    [SerializeField]
    private GameObject panelArmor;

    [Tooltip("Оружие")]
    [SerializeField]
    private Weapons weapon;

    [Tooltip("Броня")]
    [SerializeField]
    private Armors armor;


    [Tooltip("Тип")]
    [SerializeField]
    private Type type;

    [Tooltip("Кнопка с оружием")]
    [SerializeField]
    private GameObject btnSelectedWeapon;

    [Tooltip("Кнопка с бронёй")]
    [SerializeField]
    private GameObject btnSelectedArmor;

    public enum Type
    {
        Weapon,
        Armor
    }

    public Weapons Weapon
    {
        get
        {
            return weapon;
        }
        set
        {
            weapon = value;
        }
    }

    public Armors Armor
    {
        get
        {
            return armor;
        }
        set
        {
            armor = value;
        }
    }

    //Панель с оружием
    private Transform[] pnlWeaponChildren;

    //Панель с бронёй
    private Transform[] pnlArmorChildren;

    private void Awake()
    {
        if (panelWeapon != null)
        {
            pnlWeaponChildren = new Transform[10];
            for (int i = 0; i < panelWeapon.transform.childCount; i++)
            {
                pnlWeaponChildren[i] = panelWeapon.transform.GetChild(i);
            }
        }

        if (panelArmor != null)
        {
            pnlArmorChildren = new Transform[10];
            for (int i = 0; i < panelArmor.transform.childCount; i++)
            {
                pnlArmorChildren[i] = panelArmor.transform.GetChild(i);
            }
        }

    }
    public void OnMouseEnter()
    {
        switch (type)
        {
            case Type.Weapon:
                {
                    if (weapon != null)
                    {
                        pnlWeaponChildren[1].GetComponent<Text>().text = "Название оружия: ";
                        pnlWeaponChildren[2].GetComponent<Text>().text = "Урон: ";
                        pnlWeaponChildren[3].GetComponent<Text>().text = "Тип оружия: ";
                        pnlWeaponChildren[4].GetComponent<Text>().text = "Дополнительный эффект: ";

                        panelWeapon.SetActive(true);
                        pnlWeaponChildren[0].GetComponent<Image>().sprite = weapon.SpriteWeapon;
                        pnlWeaponChildren[1].GetComponent<Text>().text += weapon.NameWeapon;
                        pnlWeaponChildren[2].GetComponent<Text>().text += weapon.Damage;

                        switch (weapon.TypeWeapon)
                        {
                            case Weapons.Type.Lava:
                                pnlWeaponChildren[3].GetComponent<Text>().text += "Лава";
                                break;

                            case Weapons.Type.Ocean:
                                pnlWeaponChildren[3].GetComponent<Text>().text += "Океан";
                                break;

                            case Weapons.Type.Forest:
                                pnlWeaponChildren[3].GetComponent<Text>().text += "Камень и лес";
                                break;

                            case Weapons.Type.Air:
                                pnlWeaponChildren[3].GetComponent<Text>().text += "Воздух и гроза";
                                break;
                        }

                        pnlWeaponChildren[4].GetComponent<Text>().text += weapon.AdditionalEffectWeapon;
                    }

                    break;
                }

            case Type.Armor:
                {
                    if (armor != null)
                    {
                        pnlArmorChildren[1].GetComponent<Text>().text = "Название брони: ";
                        pnlArmorChildren[2].GetComponent<Text>().text = "Защита: ";
                        pnlArmorChildren[3].GetComponent<Text>().text = "Тип брони: ";
                        pnlArmorChildren[4].GetComponent<Text>().text = "Дополнительный эффект: ";

                        panelArmor.SetActive(true);
                        pnlArmorChildren[0].GetComponent<Image>().sprite = armor.SpriteArmor;
                        pnlArmorChildren[1].GetComponent<Text>().text += armor.NameArmor;
                        pnlArmorChildren[2].GetComponent<Text>().text += armor.Protection + "%";

                        switch (armor.TypeArmor)
                        {
                            case Armors.Type.Lava:
                                pnlArmorChildren[3].GetComponent<Text>().text += "Лава";
                                break;

                            case Armors.Type.Ocean:
                                pnlArmorChildren[3].GetComponent<Text>().text += "Океан";
                                break;

                            case Armors.Type.Forest:
                                pnlArmorChildren[3].GetComponent<Text>().text += "Камень и лес";
                                break;

                            case Armors.Type.Air:
                                pnlArmorChildren[3].GetComponent<Text>().text += "Воздух и гроза";
                                break;
                        }

                        pnlArmorChildren[4].GetComponent<Text>().text += armor.AdditionalEffectArmor;
                    }
                    break;
                }
        }
    }

    public void OnMouseExit()
    {
        switch (type)
        {
            case Type.Weapon:
                {
                    panelWeapon.SetActive(false);
                    break;
                }

            case Type.Armor:
                {
                    panelArmor.SetActive(false);
                    break;
                }
        }
    }

    public void OnClick()
    {
        switch(type)
        {
            case Type.Weapon:
                {
                    btnSelectedWeapon.GetComponent<MouseOnItem>().weapon = weapon;
                    btnSelectedWeapon.GetComponent<Image>().sprite = weapon.SpriteWeapon;
                    break;
                }

            case Type.Armor:
                {
                    btnSelectedArmor.GetComponent<MouseOnItem>().armor = armor;
                    btnSelectedArmor.GetComponent<Image>().sprite = armor.SpriteArmor;
                    break;
                }
        }
    }
}
