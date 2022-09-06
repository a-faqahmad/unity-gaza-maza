using UnityEngine;

public class Exit : MonoBehaviour
{
    public void ExitGame() {
        Debug.Log("Game exitted successfully!");
        Application.Quit();
    }
}
