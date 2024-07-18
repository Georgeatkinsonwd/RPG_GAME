using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{

    public static InventoryManager Instance { get; private set; }
    public GameObject inventoryMenu;

    private bool menuToggle;
    [SerializeField] private List<ItemDisplayer> weapons = new List<ItemDisplayer>();



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

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.I) && menuToggle)
        {
            Time.timeScale = 1;
            inventoryMenu.SetActive(false);
            menuToggle = false;
        }
        else if (Input.GetKeyDown(KeyCode.I) && !menuToggle)
        {
            Time.timeScale = 0;
            inventoryMenu.SetActive(true);
            menuToggle = true;
        }
    }


    public void AddItem(ItemData item)
    {
        for (int i = 0; i < weapons.Count; i++)
        {
            if (weapons[i].itemData == null)
            {
                weapons[i].Display(item);
                break;
            }

        }

    }

}
