using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed = 0.5f;
    public float pauseTime = 3f;
    private float pastPauseTime = 0f;
    private bool isMoving = false;
    private int moveDirection = -1;
    public float leftStopPoint = 0f;
    public float rightStopPoint = 0f;
    private Animator animator;
    private EnemyAttack enemyAttack;
    public ParticleSystem particles;
    // Start is called before the first frame update

    void Start()
    {
        animator = GetComponent<Animator>();
        enemyAttack = GetComponent<EnemyAttack>();
    }

    // Update is called once per frame
    void Update()
    {
        if (isMoving && !enemyAttack.isAttacking)
        {
            if (!particles.isPlaying)
            {
                particles.Play();
            }

            animator.SetBool("IsWalking", true);
            transform.Translate(moveDirection * speed * Time.deltaTime, 0, 0, Space.World);
            if (transform.position.x <= leftStopPoint && moveDirection == -1)
            {
                particles.Stop();
                isMoving = false;
                animator.SetBool("IsWalking", false);
                pastPauseTime = Time.time;
                moveDirection = 1;
                transform.rotation = Quaternion.Euler(0, 180, 0);
            }

            if (transform.position.x >= rightStopPoint && moveDirection == 1)
            {
                particles.Stop();
                isMoving = false;
                animator.SetBool("IsWalking", false);
                pastPauseTime = Time.time;
                moveDirection = -1;
                transform.rotation = Quaternion.Euler(0, 0, 0);
            }
        }

        float time = Time.time;
        if (time >= (pastPauseTime + pauseTime))
        {
            isMoving = true;
        }
    }
}
