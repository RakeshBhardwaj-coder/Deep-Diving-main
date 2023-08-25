using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreasureDefination : MonoBehaviour
{
    public TreasureType Type { get; private set; }
    public int Power { get; private set; }
    public string Ability { get; private set; }

    public TreasureDefination(TreasureType type)
    {
        Type = type;
        SetAttributesByType(type);
    }

    private void SetAttributesByType(TreasureType type)
    {
        switch (type)
        {
            case TreasureType.Gold:
                Power = 0;
                Ability = "Melee Attack";
                break;

            case TreasureType.Diamond:
                Power = 1;
                Ability = "Ranged Attack";
                break;

            case TreasureType.Ruby:
                Power = 1;
                Ability = "Area of Effect Attack";
                break;

        }
    }
}
