using UnityEngine;

public class Inventory : MonoBehaviour
{
    public int coinAmount;
    public static Inventory instance;
    private void Awake()
    {
        if(instance != null){
            Debug.LogWarning("Inventory déjà instancié !");
            return;
        }
        instance = this;
    }

    public void AddCoins(int amount){
        coinAmount += amount;
    }
}
