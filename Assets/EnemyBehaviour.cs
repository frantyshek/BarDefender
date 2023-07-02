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
    [SerializeField] AudioClip[] gulpAudioClips;
    [SerializeField] AudioClip[] attackAudioClips;
    [SerializeField] AudioSource audioS;

    float timeSinceLastAttack = Mathf.Infinity;

    Move move;

    GameObject targetDealDamage;

    private void Awake()
    {
        move = GetComponent<Move>();
        audioS = GetComponent<AudioSource>();
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
            int rnd = Random.Range(0, attackAudioClips.Length);
            audioS.PlayOneShot(attackAudioClips[rnd]);
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
        int rnd = Random.Range(0, gulpAudioClips.Length);
        audioS.PlayOneShot(gulpAudioClips[rnd]);
        Destroy(gameObject);
    }

    public Item GetWantedItem() { return wantedItem; }
}
