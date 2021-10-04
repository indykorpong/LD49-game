using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneManager : MonoBehaviour
{
    public void ChangeScene(string _scene)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_scene);
    }

    public void ChangeScene(int _index)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(_index);
    }

    public void BackToMenu()
    {
        GameManager.Instance.DestroySelf();
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }

    public void LoadStage(string _name)
    {
        if (GameManager.Instance)
        {
            GameManager.Instance.DestroySelf();
        }
        UnityEngine.SceneManagement.SceneManager.LoadScene(_name);
    }
}
