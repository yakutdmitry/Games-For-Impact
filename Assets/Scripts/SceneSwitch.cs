using System;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneSwitch : MonoBehaviour
{
    public string Scene;

    public void Switch()
    {
        SceneManager.LoadScene(Scene);
    }
}
