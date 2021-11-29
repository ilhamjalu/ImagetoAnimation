using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Linq;

public class LoadObject : MonoBehaviour
{
    [SerializeField]
    public FileInfo[] fileInfo;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScanFolder();
            Debug.Log("TESTT");
        }
    }

    public void ScanFolder()
    {
        Load("A");
    }

    public void Load(string folder)
    {
        string path = Application.streamingAssetsPath + "/";
        DirectoryInfo dir = new DirectoryInfo(path+folder);

        var val = dir.GetFiles("*.meta");


        fileInfo = dir.GetFiles("*.*").OrderBy(a => a.CreationTime).Where(a => a.Extension != ".meta").ToArray();

        foreach(var test in fileInfo)
        {
            Debug.Log(test);
        }
        
    }
}
