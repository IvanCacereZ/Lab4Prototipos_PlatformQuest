using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coins : MonoBehaviour
{
    public int value;
    [SerializeField] private GameIntEvent EventModifyCoins;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            EventModifyCoins.Raise(value);
            //PointSystem.modifyPoints(value);
            Destroy(this.gameObject);
        }
    }
}
