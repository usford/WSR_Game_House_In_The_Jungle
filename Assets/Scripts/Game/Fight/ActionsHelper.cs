using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.UI;

public class ActionsHelper : MonoBehaviour
{
    public Characteristic character;
    public Elemental _enemy;
    private Characteristic enemy;

    //Equip
    public Equip equipHero;
    public Equip equipEnemy;

    //UI
    public GameObject characterAP;
    public GameObject characterHP;

    public GameObject enemyAP;
    public GameObject enemyHP;



    private void Start()
    {
        enemy = _enemy.GetComponent<Elemental>().CharacteristicData;
    }

    /// <summary>
    /// Атака
    /// </summary>
    /// <param name="cost"></param>
    public void Attack(int cost)
    {
        //Минус од
        int textAP = Int32.Parse(characterAP.GetComponentInChildren<Text>().text);
        textAP -= cost;
        characterAP.GetComponentInChildren<Text>().text = textAP.ToString();

        //Минус хп у противника
        float textHP = Int32.Parse(enemyHP.GetComponentInChildren<Text>().text);
        textHP -=  equipHero.Weapon.Damage - (equipHero.Weapon.Damage * (equipEnemy.Armor.Protection / 100f));

        enemyHP.GetComponentInChildren<Text>().text = textHP.ToString();
    }
}
