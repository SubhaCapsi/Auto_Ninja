using UnityEngine;
using UnityEngine.SceneManagement;
public class GameOver : MonoBehaviour
{
    // public GameObject gameOverUI;
    public GameObject completeUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Restart()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    public void Resume()
    {
        completeUI.SetActive(false);
        Time.timeScale = 1f; 
    }

    public void MainMenu()
    {
        SceneManager.LoadScene(0);
    }
    
    public void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        SceneManager.LoadScene(nextSceneIndex);
    }
}
