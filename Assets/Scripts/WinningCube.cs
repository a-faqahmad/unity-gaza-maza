using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WinningCube : MonoBehaviour
{
    [SerializeField] private GameManager gameManager;
    void OnTriggerEnter() {
        gameManager.EndLevel();
    }
}
