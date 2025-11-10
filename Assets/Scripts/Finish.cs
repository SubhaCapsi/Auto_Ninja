using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public GameObject player;
    public GameObject completeUI;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Time.timeScale = 0f;
            completeUI.SetActive(true);
        }
    }
}
