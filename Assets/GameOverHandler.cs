using Player;
using PlayerScripts;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOverHandler : MonoBehaviour
{
    // Start is called before the first frame update
    private void Start()
    {
        Health.OnDeath += ShowGameOver;
    }

    private void OnDisable()
    {
        Health.OnDeath -= ShowGameOver;
    }


    private void ShowGameOver()
    {
        gameObject.SetActive(true);
        SceneManager.LoadScene("Game-Over-Scene", LoadSceneMode.Single);
    }
}