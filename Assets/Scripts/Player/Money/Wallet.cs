using UnityEngine.UI;
using UnityEngine;

public class Wallet : MonoBehaviour
{
    public int balance;
    public Text textBalance;

    private void Start()
    {
        UpdateBalance();
    }

    public bool Payment(int price)
    {
        if (balance - price >= 0)
        {
            balance -= price;
            UpdateBalance();
            return true;
        }
        return false;
    }

    public void GetMoney(int amount)
    {
        balance += amount;
        UpdateBalance();
    }

    private void UpdateBalance()
    {
        if (textBalance != null)
        {
            textBalance.text = balance + "$";
        }
    }
}
