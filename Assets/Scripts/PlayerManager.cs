using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance { get; private set; }

    public PlayerCombat playerCombat;
    public PlayerMovement playerMovement;
    public WeaponPickUp weaponPickUp;
    public Image equippedWeapon;
    public Image equippedWeaponIcon;
    public TextMeshProUGUI equippedWeaponDamageText;
    public TextMeshProUGUI equippedWeaponNameText;
    public GameObject weaponSprite;


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }

    }



}
