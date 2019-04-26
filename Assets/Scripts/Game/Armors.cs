using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Armor", menuName = "Scriptable Object/New Armor")]
public class Armors : ScriptableObject
{
    [Tooltip("Название брони")]
    [SerializeField]
    private string nameArmor;

    [Tooltip("Картинка брони")]
    [SerializeField]
    private Sprite spriteArmor;

    [Tooltip("Защита в процентах")]
    [SerializeField]
    private int protection;

    [Tooltip("Тип брони/эффект")]
    [SerializeField]
    private Type type;

    [Tooltip("Дополнительный эффект")]
    [SerializeField]
    private AdditionalEffect additionalEffect;

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
        UnderProtectionDoubleAttack, //При использовании защиты вы можете атаковать дважды за свой ход
        counterattackCostLessAPThree, //Контратаки стоят на 3 ОД меньше
        RestoresYouToThirtyHealthAtTheEndOfTheTurn, //Восстанавливает вам 30 ед. здоровья в конце хода
        EachOfYourBlowTakesOneAPFromTheEnemy, //Каждый ваш удар отнимает 1 ОД у врага
        ReducesTheAPByTwoAndYourStrikesBlockAllEnemyActionsExceptTheAttack, //Уменьшает ОД на 2, а ваши удары блокируют все действия противника кроме атаки
        BlocksTheUseOfProtection, //Блокирует использование защиты
        UseOfProtectionRecoversTwentyDamageHealth, //Использование защиты также восстанавливает 20 ед. здоровья
        UsingAimingRestoresFortyUnitsHealth, //Использование прицеливания также восстанавливает 40 ед. здоровья
        IncreasesYoursAPByTwo //Увеличивает ваши ОД на 2
    }

    public string NameArmor
    {
        get
        {
            return nameArmor;
        }
        set
        {
            nameArmor = value;
        }
    }

    public Sprite SpriteArmor
    {
        get
        {
            return spriteArmor;
        }
        set
        {
            spriteArmor = value;
        }
    }

    public Type TypeArmor
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

    public int Protection
    {
        get
        {
            return protection;
        }
        set
        {
            protection = value;
        }
    }

    public AdditionalEffect AdditionalEffectArmor
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
