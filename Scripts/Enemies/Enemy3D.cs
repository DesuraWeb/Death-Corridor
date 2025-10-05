using UnityEngine;

public class Enemy3D : MonoBehaviour
{
    public float speed = 4f;
    public int hp = 3;

    void Update()
    {
        transform.Translate(Vector3.back * speed * Time.deltaTime);
    }

    public void TakeDamage(int dmg)
    {
        hp -= dmg;
        if (hp <= 0)
            Die();
    }

    void Die()
    {
        Destroy(gameObject);
        GameManager3D.Instance.OnEnemyKilled();
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            GameManager3D.Instance.OnPlayerHit();
            Destroy(gameObject);
        }
    }
}
