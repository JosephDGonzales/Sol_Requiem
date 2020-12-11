using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeAttack : MonoBehaviour
{
    private Health playerHealth;

    private GameObject Player;
    private Transform target;

    public float attackRange;
    public int damage;
    private float lastAttackTime;
    public float attackDelay;

    private Animator meleeAnim;

    public string meleeAnimName;

    // Start is called before the first frame update
    void Start()
    {
        meleeAnim = GetComponent<Animator>();

        Player = GameObject.FindWithTag("Player");
        playerHealth = Player.GetComponent<Health>();
        target = Player.GetComponent<Transform>();

        //meleeAnim.enabled = false;


    }

    // Update is called once per frame
    void Update()
    {
        //meleeAnim.enabled = false;
        meleeAnim.SetBool("isAttacking", false);
        float distanceToPlayer = Vector3.Distance(transform.position, target.position);
        if (distanceToPlayer < attackRange)
        {
            //meleeAnim.enabled = true;
            meleeAnim.SetBool("isAttacking", true);
            if (Time.time > lastAttackTime + attackDelay)
            {
                Debug.Log("You got Hit my dood");
                PlayerTakeDamage();
                lastAttackTime = Time.time;
            }
        }
    }

    void PlayerTakeDamage()
    {
        playerHealth.TakeDamage(damage);
    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, attackRange);
    }
}
