using UnityEngine;
using System.Collections;

public class AuraCollect : MonoBehaviour
{
    private Player myPlayer;
    private Side mySide;
    private Health myHealth;

    [SerializeField] private int CollectAmount;
    [SerializeField] private int CollectRate;
    [SerializeField] private float CollectRange;
    [SerializeField] private int AurastealAmount;

    private bool canCollect;
    private bool isCollecting;
    private bool isTargetInRange;

    private void Start()
    {
        mySide = GetComponent<Side>();
        myPlayer = mySide.MyPlayer.GetComponent<Player>();
        myHealth = GetComponent<Health>();
        StartCoroutine(AutomatedAuraCollect());
    }

    public void ClickForAura()
    {
        CollectAura(CollectAmount);
    }

    IEnumerator AutomatedAuraCollect()
    {
        while (true)
        {
            CollectAura(CollectAmount * CollectRate);
            yield return new WaitForSeconds(1);
        }
    }

    public void CollectAura(int collectedAura)
    {
        myPlayer.AuraBalance += collectedAura;
        myPlayer.UpdateInterface();
    }

    public void CollectAuraFromTarget(GameObject targetObject)
    {
        var targetHealth = targetObject.GetComponent<Health>();
        var targetPlayer = targetObject.GetComponent<Side>().MyPlayer.GetComponent<Player>();

        if (myHealth.CurrentHealth < myHealth.MaxHealth)
        {
            if ((myHealth.CurrentHealth + AurastealAmount) > myHealth.MaxHealth)
            {
                myHealth.CurrentHealth = myHealth.MaxHealth;
            }
            else
            {
                myHealth.CurrentHealth += AurastealAmount;
            }
        } else
        {
            if (targetHealth.CurrentHealth < AurastealAmount)
            {
                myPlayer.AuraBalance += targetHealth.CurrentHealth;
                myPlayer.UpdateInterface();
                targetHealth.TakeDamage(AurastealAmount);
            } else
            {
                myPlayer.AuraBalance += AurastealAmount;
                myPlayer.UpdateInterface();
                targetHealth.TakeDamage(AurastealAmount);
            }
        }
    }
}
