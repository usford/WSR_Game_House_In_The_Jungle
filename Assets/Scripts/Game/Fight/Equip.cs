using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Equip : MonoBehaviour
{
    [Tooltip("Броня")]
    [SerializeField]
    private Armors armor;

    [Tooltip("Оружие")]
    [SerializeField]
    private Weapons weapon;

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
}
