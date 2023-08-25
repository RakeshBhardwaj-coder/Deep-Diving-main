using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamDefination : MonoBehaviour
{
    public GamType Type { get; private set; }
    public int Power { get; private set; }
    public string Ability { get; private set; }

    public GamDefination(GamType type)
    {
        Type = type;
        SetAttributesByType(type);
    }

    private void SetAttributesByType(GamType type)
    {
        switch (type)
        {
            case GamType.Gold:
                Power = 0;
                Ability = "Melee Attack";
                break;

            case GamType.Diamond:
                Power = 1;
                Ability = "Ranged Attack";
                break;

            case GamType.Ruby:
                Power = 1;
                Ability = "Area of Effect Attack";
                break;

        }
    }
}
