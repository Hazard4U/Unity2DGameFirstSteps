using UnityEngine;

public class PickUpObject : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D collider2D){
        if(collider2D.CompareTag("Player")){
            Inventory.instance.AddCoins(1);
            Destroy(gameObject);
        }
    }
}
