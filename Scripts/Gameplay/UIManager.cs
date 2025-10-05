using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("Refs")]
    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI livesText;

    public void SetScore(int score) => scoreText.text = $"Score : {score}";
    public void SetLives(int lives) => livesText.text = $"Vies : {lives}";
}
