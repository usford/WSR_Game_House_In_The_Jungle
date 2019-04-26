using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Characteristic", menuName = "Scriptable Object/New Characteristic")]
public class Characteristic : ScriptableObject
{
    [Tooltip("HP персонажа")]
    [SerializeField]
    private int hp;

    [Tooltip("Очки действия")]
    [SerializeField]
    private int actionPoints;

    [Tooltip("Тип существа")]
    [SerializeField]
    private Type type;

    [Tooltip("Оружие")]
    [SerializeField]
    private Weapons weapon;

    [Tooltip("Броня")]
    [SerializeField]
    private Armors armor; //Броня

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
        set
        {
            actionPoints = value;
        }
    }

    public Type TypePerson
    {
        get
        {
            return type;
        }
        set
        {
            type = value;
        }
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
} 
