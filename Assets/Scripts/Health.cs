using UnityEngine;

public class Health : MonoBehaviour
{
    public int MaxHealth;
    public int CurrentHealth;

    private void Start()
    {
        CurrentHealth = MaxHealth;
    }

    public void TakeDamage(int damageAmount)
    {
        CurrentHealth -= damageAmount;
        if (CurrentHealth < 0)
        {
            Die();
        }
    }

    public void TakeHeal(int healAmount)
    {
        if (CurrentHealth < MaxHealth)
        {
            if ((CurrentHealth + healAmount) > MaxHealth)
            {
                CurrentHealth = MaxHealth;
            } else {
                CurrentHealth += healAmount;
            }
        }
    }

    private void Die()
    {
        CurrentHealth = 0;
        gameObject.SetActive(false);
    }

    public void Upgrade(int upgradedHealth)
    {
        MaxHealth = upgradedHealth;
        CurrentHealth = MaxHealth;
    }
}
