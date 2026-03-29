using System;
using UnityEngine;

public class CoinScript : MonoBehaviour
{
    [SerializeField] private int value = 1; 


    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerRecollection player = other.GetComponent<PlayerRecollection>();

        if (player != null)
        {
            player.coincounter += value;
            Destroy(gameObject); 
        }
    }
}
    //[SerializeField] private PlayerRecollection player;


    //// Start is called once before the first execution of Update after the MonoBehaviour is created
    //void Start()
    //{
        
    //}

    //// Update is called once per frame
    //void Update()
    //{
        
    //}

    //private void OnTriggerEnter2D(Collider2D collision)
    //{
    //    if (collision.gameObject.tag == "Player")
    //    {
    //        player.CollectCoins();
    //        Destroy(this.gameObject);
    //    }
    //}

