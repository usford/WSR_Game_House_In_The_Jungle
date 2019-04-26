using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Scriptable Object/New Weapon")]
public class Weapons : ScriptableObject
{
    [Tooltip("Название оружия")]
    [SerializeField]
    private string nameWeapon;

    [Tooltip("Картинка оружия")]
    [SerializeField]
    private  Sprite spriteWeapon;

    [Tooltip("Урон")]
    [SerializeField]
    private int damage;

    [Tooltip("Тип оружия/эффект")]
    [SerializeField]
    private Type type;

    [Tooltip("Дополнительный эффект")]
    [SerializeField]
    private AdditionalEffect additionalEffect; //Дополнительный эффект

    public enum Type
    {
        Lava, //Лава
        Ocean, //Океан
        Forest, //Камень и лес
        Air //Воздух и гроза
    }

    public enum AdditionalEffect
    {
        None, //Нет дополнительных эффектов
        IgnoresProtection, //Игнорирует защиту соперника
        TakesAEnemyTwoAPPerTurn, //Отнимает у игрока 2 од на ход
        TakesAEnemyThreeAPPerTurn, //Отнимает у игрока 3 од на ход
        TheEnemyHasOnlyAttackOnTheMove, //Блокирует врагу все действия кроме атаки на ход
        WhenAttackingHealsYouFortyDamageHealth, //При атаке восстанавливает вам 40 ед. здоровья
        IncreasesYoursAPByOne, //Увеличивает ваши ОД на 1
        WhenUsingAimingYouCanAttackTwicePerTurnWithThisWeapon, //При использовании прицеливания вы можете атаковать дважды за ход этим оружием
        IncreasesYoursAPByTwo //Увеличивает ваши ОД на 2
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

    public Sprite SpriteWeapon
    {
        get
        {
            return spriteWeapon;
        }
        set
        {
            spriteWeapon = value;
        }
    }

    public int Damage
    {
        get
        {
            return damage;
        }
        set
        {
            damage = value;
        }
    }

    public Type TypeWeapon
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

    public AdditionalEffect AdditionalEffectWeapon
    {
        get
        {
            return additionalEffect;
        }
        set
        {
            additionalEffect = value;
        }
    }
}

