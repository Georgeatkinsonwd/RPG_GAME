using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponPickUp : MonoBehaviour
{
    private InventoryManager inventoryManager;
  
    void Start()
    {
       inventoryManager = GameObject.FindWithTag("Inventory Canvas").GetComponent<InventoryManager>();
    }


     void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "Weapon")
        {
            InventoryManager.Instance.AddItem(collider.gameObject.GetComponent<ItemDisplayer>().itemData);

            Destroy(collider.gameObject);

        }
    }
}
