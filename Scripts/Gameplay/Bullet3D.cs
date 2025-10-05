using UnityEngine;

public class Bullet3D : MonoBehaviour
{
    public float speed = 25f;
    public int damage = 10;
    public float lifeTime = 3f;

    void Start() => Destroy(gameObject, lifeTime);

    void Update() => transform.Translate(Vector3.forward * speed * Time.deltaTime, Space.Self);

    void OnTriggerEnter(Collider other)
    {
        // Cherche un EnemyHealth sur ce qu'on touche
        if (other.TryGetComponent(out EnemyHealth hp))
        {
            hp.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}
