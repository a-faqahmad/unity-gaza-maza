using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] private levelTexts leveltext;
    [SerializeField] private GameObject panel;
    
    private bool levelCompleted = false;
    private float successDelay = 1f;
    public void BeginLevel() {
        leveltext.Begin();
    }
    public void EndLevel() {
        FindObjectOfType<delliksawMovement>().stopMovement();
        Invoke("showSuccess", successDelay);
        levelCompleted = true;
    }
    
    void Update() {
        if (levelCompleted) {
            if(Input.GetKey(KeyCode.Space)) {
                LoadNextLevel();
            }
        }
    }
    
    public void showSuccess() {
        panel.gameObject.SetActive(true);
    }
    
    public void Restart() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    
    private void LoadNextLevel() {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
