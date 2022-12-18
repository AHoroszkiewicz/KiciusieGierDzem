using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManagerObj : MonoBehaviour
{ 
    public void GoToTestScene() 
    {
        SceneManager.LoadScene(sceneName: "Test");
    }
}
