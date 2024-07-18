using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;


public class ItemDisplayer : MonoBehaviour
{

    public TextMeshProUGUI damageText;
    public TextMeshProUGUI titleText;
    public Button equipButton;
    public ItemData itemData;


    [SerializeField] private Image icon;

    public void Display(ItemData selectData)
    {
        if (titleText != null)
        {
            titleText.text = selectData.name;
        }

        if (icon != null)
        {
            icon.sprite = selectData.icon;
        }

        if (damageText != null)
        {
            damageText.text = selectData.damage.ToString();
        }

        itemData = selectData;

    }


    public void EquipThisItem()
    {
        if (itemData == null)
        {
            return;
        }

        PlayerManager.Instance.playerCombat.EquipWeapon(itemData);

    }
}


