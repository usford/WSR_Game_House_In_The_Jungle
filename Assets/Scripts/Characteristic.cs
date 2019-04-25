using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Characteristic", menuName = "Scriptable Object/New Characteristic")]
public class Characteristic : ScriptableObject
{
    [SerializeField]
    private int hp; //HP персонажа
    [SerializeField]
    private int actionPoints; //Очки действия
    [SerializeField]
    private Type type; //Тип персонажа/элементаля
    [SerializeField]
    private Weapons weapon; //Оружие
    [SerializeField]
    private string armor; //Броня

    public enum Type
    {
        Hero, //Герой
        Lava, //Лава
        Ocean, //Океан
        Forest, //Камень и лес
        Air //Воздух и гроза
    }

    public int HP
    {
        get
        {
            return hp;
        }
        set
        {
            hp = value;
        }
    }

    public int ActionPoints
    {
        get
        {
            return actionPoints;
        }
    }

    public Type typePerson
    {
        get
        {
            return type;
        }
    }

    public Weapons Weapon
    {
        get
        {
            return weapon;
        }
    }

    public string Armor
    {
        get
        {
            return armor;
        }
    }
} 
