using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class OpenFile : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShownInExplore(string folder)
    {
        Debug.Log("TOMBOL");
        //EditorUtility.RevealInFinder(Application.streamingAssetsPath + "/" + folder + "/");
        Application.OpenURL(Application.streamingAssetsPath + "/" + folder);
    }

    public void ChangeScene(string scene)
    {
        SceneManager.LoadScene(scene);
    }
}
