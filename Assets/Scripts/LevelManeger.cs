using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManeger : MonoBehaviour
{
    public GameObject levels;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LevelOne()
    {
        SceneManager.LoadScene(1);
    }
    public void LevelTwo()
    {
        SceneManager.LoadScene(2);
    }
    public void LevelThree()
    {
        SceneManager.LoadScene(3);
    }
    public void LevelFour()
    {
        SceneManager.LoadScene(4);
    }
    public void LevelFive()
    {
        SceneManager.LoadScene(5);
    }
    public void Quit()
    {
        Application.Quit();
    }
}
