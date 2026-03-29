using UnityEngine;

public class PlayerRecollection : MonoBehaviour
{
    public int playercoins = 0;
    public bool hasCoins = false;
    public int coincounter = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("coin"))
        {
            playercoins++;
            coincounter++;

            hasCoins = true;

            Destroy(collision.gameObject); 
        }
    }
}
