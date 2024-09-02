using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayingSide mySide;
    public int AuraBalance;
    public int BaseHP;
    public int TotalUnits;
    public int CurrentUnits;

    private void Start()
    {
        AuraBalance = 0;
    }

    public void UpdateInterface()
    {
        Debug.Log(mySide + "'s Balance: " + AuraBalance);
    }
}
