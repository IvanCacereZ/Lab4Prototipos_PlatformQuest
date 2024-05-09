using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int value;
    public Transform[] pivots;
    public bool isMoved = true;
    public float moveSpeed = 5f;
    private int currentPatrolIndex = 0;
    [SerializeField]private GameIntEvent EventModifyLife;
    private void Update()
    {
        if (isMoved)
        {
            Movement();
        }
    }
    private void Movement()
    {
        Vector3 direction = (pivots[currentPatrolIndex].position - transform.position).normalized;
        transform.Translate(direction * moveSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, pivots[currentPatrolIndex].position) < 0.1f)
        {
            currentPatrolIndex = (currentPatrolIndex + 1) % pivots.Length;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<SpriteRenderer>().color != this.GetComponent<SpriteRenderer>().color)
        {
            EventModifyLife.Raise(value);
        }
        else
        {
            collision.GetComponent<PlayerController>().IsInColor = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        collision.GetComponent<PlayerController>().IsInColor = false;
    }
}
