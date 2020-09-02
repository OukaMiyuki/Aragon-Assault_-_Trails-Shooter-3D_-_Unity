using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevelOnDeathController : MonoBehaviour {
    [SerializeField] float levelLoadDelay = 2f;

    private void nextScene() {
        Invoke("loadScene", levelLoadDelay);
    }

    private void loadScene() {
        SceneManager.LoadScene(1);
    }
}
