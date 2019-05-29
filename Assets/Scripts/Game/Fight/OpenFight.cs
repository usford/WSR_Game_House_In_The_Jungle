using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OpenFight : MonoBehaviour
{
    public GameObject panelFight;
    public GameObject countSpheres;

    public GameObject armorHero;
    public GameObject weaponHero;
    public GameObject imageHero;
    public Equip equipHero;
    public GameObject hpHero;
    public GameObject odHero;

    public GameObject armorEnemy;
    public GameObject weaponEnemy;
    public GameObject imageEnemy;
    public SpriteRenderer characterImage;
    public Equip equipEnemy;
    public GameObject hpEnemy;
    public GameObject odEnemy;


    public Character character;


    private Transform[] child;
    private void Start()
    {
        
    }

    public void Fight()
    {
        child = new Transform[13];


        for (int i = 0; i < gameObject.transform.childCount; i++)
        {
            child[i] = gameObject.transform.GetChild(i);
        }

        gameObject.SetActive(false);
        panelFight.SetActive(true);
        countSpheres.SetActive(false);

        //Перенос героя
        armorHero.GetComponent<Image>().sprite = character.CharacteristicData.Armor.SpriteArmor;
        weaponHero.GetComponent<Image>().sprite = character.CharacteristicData.Weapon.SpriteWeapon;

        imageHero.GetComponent<Image>().sprite = characterImage.sprite;

        equipHero.Armor = character.CharacteristicData.Armor;
        equipHero.Weapon = character.CharacteristicData.Weapon;

        hpHero.GetComponentInChildren<Text>().text = character.CharacteristicData.HP.ToString();
        odHero.GetComponentInChildren<Text>().text = character.CharacteristicData.ActionPoints.ToString();

        //Перенос врага
        armorEnemy.GetComponent<Image>().sprite = child[12].GetComponent<Elemental>().CharacteristicData.Armor.SpriteArmor;
        weaponEnemy.GetComponent<Image>().sprite = child[12].GetComponent<Elemental>().CharacteristicData.Weapon.SpriteWeapon;

        imageEnemy.GetComponent<Image>().sprite = child[12].GetComponentInChildren<SpriteRenderer>().sprite;
        imageEnemy.GetComponent<Image>().color = child[12].GetComponentInChildren<SpriteRenderer>().color;

        imageEnemy.GetComponent<Elemental>().CharacteristicData = child[12].GetComponent<Elemental>().CharacteristicData;
        imageEnemy.GetComponent<Elemental>().panelDiscription = child[12].GetComponent<Elemental>().panelDiscription;

        equipEnemy.Armor = child[12].GetComponent<Elemental>().CharacteristicData.Armor;
        equipEnemy.Weapon = child[12].GetComponent<Elemental>().CharacteristicData.Weapon;

        hpEnemy.GetComponentInChildren<Text>().text = child[4].GetComponent<Text>().text;
        odEnemy.GetComponentInChildren<Text>().text = child[5].GetComponent<Text>().text;

    }
}
