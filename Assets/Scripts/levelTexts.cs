using UnityEngine.UI;
using UnityEngine;
using TMPro;

public class levelTexts : MonoBehaviour
{
    private bool started = false;
    private float startTime;
    [SerializeField] private TextMeshProUGUI levelName;
    [SerializeField] private TextMeshProUGUI score;
    
    void Start() {
        score.gameObject.SetActive(false);
    }
    void Update()
    {
        if (started) {
            levelName.gameObject.SetActive(false);
            score.gameObject.SetActive(true);
            startTime = Time.time;
            started = false;
        }
        showTime();
    }
    
    public void Begin() {
        started = true;
    }
    
    void showTime() {
        float t = Time.time - startTime;
        string minutes = ((int) t / 60).ToString();
        string seconds = ((int) t % 60).ToString();
        string formatMinute = int.Parse(minutes) < 10 ? "0" : "";
        string formatSecond = int.Parse(seconds) < 10 ? "0" : "";
        score.text = formatMinute + minutes + " : " + formatSecond + seconds;
    }
}
