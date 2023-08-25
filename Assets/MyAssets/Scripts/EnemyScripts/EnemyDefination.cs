using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class EnemyDefination : MonoBehaviour
{
    public EnemyType Type { get; private set; }
    public int Power { get; private set; }
    public string Ability { get; private set; }

    public EnemyDefination(EnemyType type)
    {
        Type = type;
        SetAttributesByType(type);
    }

    private void SetAttributesByType(EnemyType type)
    {
        switch (type)
        {
            case EnemyType.Fish:
                Power = 0;
                Ability = "Melee Attack";
                break;

            case EnemyType.DartFish:
                Power = 1;
                Ability = "Ranged Attack";
                break;

            case EnemyType.BigFish:
                Power = 1;
                Ability = "Area of Effect Attack";
                break;

        }
    }
}
