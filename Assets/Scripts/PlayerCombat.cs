using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.VFX;

public class PlayerCombat : MonoBehaviour
{
    public NavMeshAgent _agent;
    public GameObject inventory;
    public float attackSpeed;
    public float maxHealth, currentHealth;
    public HealthBar healthBar;

    private Enemy targetEnemy;
    private ItemData currentWeapon;
    [SerializeField] private float damage = 1;
    private float distance;
    private bool isAttacking = false;


    void Update()
    {
        Attack();
    }


    void Attack()
    {
        if (Input.GetMouseButton(0))
        {
            Ray attackEnemy = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(attackEnemy, out var hitInfo) && hitInfo.collider.CompareTag("Enemy"))
            {
                _agent.destination = hitInfo.point;
                targetEnemy = hitInfo.collider.gameObject.GetComponent<Enemy>();

            }

        }
        if (AttackRangeCheck() && targetEnemy.currentHealth > 0)
        {

            StartCoroutine(StartAutoAttack());

        }

    }

    public bool AttackRangeCheck()
    {
        if (targetEnemy == null)
        {
            return false;
        }
        else
        {
            distance = Vector3.Distance(_agent.transform.position, targetEnemy.transform.position);
        }


        if (distance < 3)
        {
            return true;
        }
        return false;
    }


    IEnumerator StartAutoAttack()
    {
        if (isAttacking)
        {
            yield break;
        }

        isAttacking = true;
        yield return new WaitForSeconds(attackSpeed);
        targetEnemy.currentHealth -= damage;
        isAttacking = false;



    }

    public void EquipWeapon(ItemData weaponToEquip)
    {
        currentWeapon = weaponToEquip;
        damage = currentWeapon.damage;
        if (PlayerManager.Instance.equippedWeapon != null)
        {
            PlayerManager.Instance.weaponSprite.SetActive(true);
            PlayerManager.Instance.equippedWeapon.sprite = weaponToEquip.icon;
            PlayerManager.Instance.equippedWeaponIcon.sprite = weaponToEquip.icon;
            PlayerManager.Instance.equippedWeaponNameText.text = weaponToEquip.name;
            PlayerManager.Instance.equippedWeaponDamageText.text = "Damage:" + weaponToEquip.damage.ToString();


        }

    }

}
