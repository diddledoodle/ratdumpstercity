using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class LoadScreenScript : MonoBehaviour {

    [SerializeField]
    private string scenetoLoad;

    public void LoadByScene(string scenetoLoad)
    {
        SceneManager.LoadScene(scenetoLoad);
    }
}


