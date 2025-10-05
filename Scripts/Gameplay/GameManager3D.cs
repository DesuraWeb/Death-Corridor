using UnityEngine;

public class GameManager3D : MonoBehaviour
{
    public static GameManager3D Instance { get; private set; }

    [Header("Gameplay")]
    public int lives = 3;
    public int score = 0;

    [Header("UI")]
    public UIManager ui; // à lier depuis la scène (UI → UIManager)

    void Awake()
    {
        if (Instance != null && Instance != this) { Destroy(gameObject); return; }
        Instance = this;
    }

    void Start()
    {
        // Sécurité si pas lié manuellement
        if (ui == null) ui = FindObjectOfType<UIManager>();
        ui?.SetScore(score);
        ui?.SetLives(lives);
    }

    public void OnEnemyKilled()
    {
        score += 10;         // ajuste la valeur si besoin
        ui?.SetScore(score);
    }

    public void OnPlayerHit()
    {
        lives--;
        ui?.SetLives(lives);
        if (lives <= 0) GameOver();
    }

    void GameOver()
    {
        Debug.Log("GAME OVER");
        Time.timeScale = 0f;
        // (Optionnel) afficher un panneau Game Over ici
    }
}
