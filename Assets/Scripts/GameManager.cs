using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    [SerializeField] private GameObject GameOverUI;
    [SerializeField] private TextMeshProUGUI ScoreText;
    [SerializeField] private Animator GameOverAnim;

    private PlayerMovement playerMovement;

    private void Start()
    {
        playerMovement = FindObjectOfType<PlayerMovement>();
    }

    public void GameOver()
    {
        GameOverUI.SetActive(true);
        ScoreText.text = "Score: " + playerMovement.Score;
        GameOverAnim.SetTrigger("GameOver");
        Time.timeScale = 0f;
    }
}
