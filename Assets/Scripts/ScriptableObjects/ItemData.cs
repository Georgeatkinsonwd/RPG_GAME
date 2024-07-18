using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "blankItem", menuName = "ScriptableObjects/item", order = 1)]
public class ItemData : ScriptableObject
{

    public Sprite icon;
    
    public int damage;
}
