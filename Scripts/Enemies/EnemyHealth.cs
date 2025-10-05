using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    [Header("HP")]
    public int maxHealth = 30;
    int currentHealth;

    void OnEnable() => currentHealth = maxHealth;

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0) Die();
    }

    void Die()
    {
        // Sécurité si GameManager pas encore dans la scène
        if (GameManager3D.Instance != null) GameManager3D.Instance.OnEnemyKilled();
        Destroy(gameObject);
    }
}
