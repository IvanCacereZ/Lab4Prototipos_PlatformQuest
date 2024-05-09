using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hearts : MonoBehaviour
{
    public int Value;
    [SerializeField] private GameIntEvent EventModifyLife;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventModifyLife.Raise(Value);
            Destroy(this.gameObject);
        }
    }
}
