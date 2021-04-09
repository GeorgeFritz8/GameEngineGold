using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    public int minDamage = 5;
    public int maxDamage = 20;
    private Animator animator;
    public float attackTime = 2f;
    private float lastattackTime = 0f;
    public bool isAttacking = false;
    public ParticleSystem particles;
    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        float time = Time.time;
        if (time >= (lastattackTime + attackTime) && isAttacking )
        {
            isAttacking = false;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Health script = collision.gameObject.GetComponent<Health>();
            script.takeDamage(Random.Range(minDamage, maxDamage + 1));
            animator.SetTrigger("Attack");
            Debug.Log("attack");
            lastattackTime = Time.time;
            isAttacking = true;
            animator.SetBool("IsWalking", false);
            particles.Stop();
        }
    }
}
