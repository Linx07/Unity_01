using UnityEngine.UI;
using UnityEngine;
using System.Security.Cryptography;

public class Wallet : MonoBehaviour
{
    public int balance;
    public Text textBalance;

    public void Update()
    {
        ShowBalace();
    }

    public bool Payment(int price)
    {
        if (balance - price >= 0)
        {
            balance -= price;
            return true;
        }
        return false;
    }

    public void GetMoney(int amount)
    {
        balance += amount;
    }

    private void ShowBalace()
    {
        if (textBalance != null)
        {
            textBalance.text = balance + "$";
        }
    }
}
