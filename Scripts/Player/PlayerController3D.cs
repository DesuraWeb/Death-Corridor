using UnityEngine;

public class PlayerController3D : MonoBehaviour
{
    [Header("Déplacement latéral")]
    public float moveSpeed = 10f;
    public float laneOffset = 2f;
    public int maxLaneIndex = 2;

    [Header("Tir automatique")]
    public GameObject bulletPrefab;
    public Transform firePoint;
    public float fireRate = 0.25f; // tire toutes les 0.25 secondes

    private int laneIndex = 0;
    private Vector3 targetPos;
    private float fireTimer;

    void Start()
    {
        targetPos = transform.position;
        fireTimer = fireRate;
    }

    void Update()
    {
        HandleMovementInput();
        MoveToLane();
        AutoShoot();
    }

    void HandleMovementInput()
    {
        // Gauche
        if (Input.GetKeyDown(KeyCode.LeftArrow) || Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.Q))
        {
            laneIndex = Mathf.Max(laneIndex - 1, -maxLaneIndex);
            targetPos = new Vector3(laneIndex * laneOffset, transform.position.y, transform.position.z);
        }

        // Droite
        if (Input.GetKeyDown(KeyCode.RightArrow) || Input.GetKeyDown(KeyCode.D))
        {
            laneIndex = Mathf.Min(laneIndex + 1, maxLaneIndex);
            targetPos = new Vector3(laneIndex * laneOffset, transform.position.y, transform.position.z);
        }
    }

    void MoveToLane()
    {
        transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime * moveSpeed);
    }

    void AutoShoot()
    {
        fireTimer -= Time.deltaTime;

        if (fireTimer <= 0f)
        {
            Shoot();
            fireTimer = fireRate; // reset du timer
        }
    }

    void Shoot()
    {
        if (bulletPrefab == null || firePoint == null)
        {
            Debug.LogWarning("⚠️ BulletPrefab ou FirePoint non assigné !");
            return;
        }

        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
    }
}
