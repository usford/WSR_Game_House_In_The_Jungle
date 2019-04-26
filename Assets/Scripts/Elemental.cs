using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elemental : MonoBehaviour
{
    [Tooltip("Характеристика")]
    [SerializeField]
    private Characteristic characteristicData;

    private List<Weapons> weapons = new List<Weapons>(); //Оружие элементаля
    private List<Armors> armors = new List<Armors>(); //Броня элементаля

    private SpriteRenderer sprite;

    private void Awake()
    {
        weapons.AddRange(Resources.LoadAll<Weapons>("Data/Weapons/"));
        armors.AddRange(Resources.LoadAll<Armors>("Data/Armors/"));
        sprite = GetComponentInChildren<SpriteRenderer>();
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
                Debug.Log(sprite.color + "::::: "+characteristicData.name);
                characteristicData.TypePerson = Characteristic.Type.Lava;
                break;

            case 1:
                sprite.color = Color.white;
                Debug.Log(sprite.color + "::::: " + characteristicData.name);
                characteristicData.TypePerson = Characteristic.Type.Ocean;
                break;

            case 2:
                sprite.color = Color.green;
                Debug.Log(sprite.color + "::::: " + characteristicData.name);
                characteristicData.TypePerson = Characteristic.Type.Forest;
                break;

            case 3:
                sprite.color = new Color(0.757311f, 0.3685475f, 0.7735849f, 1f);
                Debug.Log(sprite.color + "::::: " + characteristicData.name);
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

    private void OnMouseDown()
    {
    }
}
