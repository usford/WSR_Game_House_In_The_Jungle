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

    public SpriteRenderer characterImage;
    public Character character;


    public void Fight()
    {
        gameObject.SetActive(false);
        panelFight.SetActive(true);
        countSpheres.SetActive(false);
        //character.CharacteristicData.Armor.SpriteArmor

        armorHero.GetComponent<Image>().sprite = character.CharacteristicData.Armor.SpriteArmor;
        weaponHero.GetComponent<Image>().sprite = character.CharacteristicData.Weapon.SpriteWeapon;

        imageHero.GetComponent<Image>().sprite = characterImage.sprite;
    }
}
