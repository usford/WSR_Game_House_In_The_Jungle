using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Scriptable Object/New Weapon")]
public class Weapons : ScriptableObject
{
    [SerializeField]
    private string nameWeapon; //Название оружия
    [SerializeField]
    private int damage; //Урон
    [SerializeField]
    private Type type; //Тип оружия
    [SerializeField]
    private string additionalEffect; //Дополнительный эффект

    public enum Type
    {
        Lava, //Лава
        Ocean, //Океан
        Forest, //Камень и лес
        Air //Воздух и гроза
    }

    public string NameWeapon
    {
        get
        {
            return nameWeapon;
        }
        set
        {
            nameWeapon = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }
    }

    public Type TypeWeapon
    {
        get
        {
            return type;
        }
    }

    public string AdditionalEffect
    {
        get
        {
            return additionalEffect;
        }
    }
}

