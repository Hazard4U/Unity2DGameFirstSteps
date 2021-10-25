using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public int coinAmount;
    public Text coinAmountText;
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
        coinAmountText.text = coinAmount.ToString();
    }


}
