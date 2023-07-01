using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{

    [SerializeField] float speed;
    [SerializeField] Item wantedItem;
    [SerializeField] float attackCooldown;
    [SerializeField] int damage;
    [SerializeField] float range;

    float timeSinceLastAttack = Mathf.Infinity;

    Move move;

    GameObject targetDealDamage;

    private void Awake()
    {
        move = GetComponent<Move>();
    }

    public void Initialize(GameObject _target)
    {
        targetDealDamage = _target;
    }

    void Update()
    {
        timeSinceLastAttack += Time.deltaTime;

        if (targetDealDamage == null) return;
        if (!GetIsInRange())
        {
            move.MoveTo(targetDealDamage.transform.position);
        }
        else
        {
            move.Cancel();
            DealDamage();
        }
    }

    private void DealDamage()
    {
        if (timeSinceLastAttack > attackCooldown)
        {
            targetDealDamage.GetComponent<Barier>().TakeDamage(damage);
            timeSinceLastAttack = 0;
        }
    }

    private bool GetIsInRange()
    {
        return Vector3.Distance(transform.position, targetDealDamage.transform.position) < range;
    }

    public void Destroy()
    {
        Destroy(gameObject);
    }

    public Item GetWantedItem() { return wantedItem; }
}
