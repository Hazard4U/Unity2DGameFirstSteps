using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    public float MOVE_SPEED;
    public Transform[] waypoints;
    public SpriteRenderer spriteRenderer;

    private Transform target;
    private int destPoint = 0;

    void Start()
    {
        target = waypoints[destPoint];
    }

    void Update()
    {
        Vector3 dir = target.position - transform.position;
        transform.Translate(dir.normalized * MOVE_SPEED * Time.deltaTime, Space.World);

        if (Vector3.Distance(transform.position, target.position) < 0.3f)
        {
            destPoint = (destPoint + 1) % waypoints.Length;
            target = waypoints[destPoint];
        }

        Animation(dir.x);
    }

    void Animation(float dirX){
        spriteRenderer.flipX = dirX<0;
    }

    private void OnCollisionEnter2D(Collision2D collision2D){
        PlayerHealth playerHealth = collision2D.gameObject.GetComponent<PlayerHealth>();
        playerHealth.TakeDamage(20);
    }
}
