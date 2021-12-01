using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class LoadObject : MonoBehaviour
{
    [SerializeField]
    public FileInfo[] fileInfo;
    public List<Sprite> spriteTexture;
    public List<string> nameCheck;
    public GameObject test;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ScanFolder", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            ScanFolder();
           // SpawnObject();
            Debug.Log("TESTT");
        }
    }

    public void SpawnObject(Sprite tex)
    {
        Instantiate(test, transform.position, transform.rotation);

        var last = spriteTexture.Count - 1;

        test.GetComponent<Renderer>().sharedMaterial.mainTexture = tex.texture;

    }

    public void ScanFolder()
    {
        Load("A");
    }

    public void Load(string folder)
    {
        string path = Application.streamingAssetsPath + "/";
        DirectoryInfo dir = new DirectoryInfo(path + folder);

        fileInfo = dir.GetFiles("*.*").OrderBy(a => a.CreationTime).Where(a => a.Extension != ".meta").ToArray();

        Debug.Log(fileInfo[1]);

        if (fileInfo.Length > 0)
        {
            foreach (var info in fileInfo)
            {
                if (nameCheck.Contains(info.ToString()) != true)
                {
                    nameCheck.Add(info.ToString());
                    string a = info.ToString();

                    //SpawnObject();
                    ImageLoader();
                }
                Debug.Log(info);
            }
        }

        //ConvertToSprite();

    }

    void ImageLoader()
    {
        int a = nameCheck.Count - 1;
        byte[] pngBytes = File.ReadAllBytes(fileInfo[a].ToString());
        
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(pngBytes);
        
        Sprite fromTex = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

        SpawnObject(fromTex);
    }

    ////public void ConvertToSprite()
    ////{
    ////    for (int i = 0; i < spriteTexture.Length; i++)
    ////    {
    ////        if (spriteTexture[i] != null)
    ////        {
    ////            string path = fileInfo[i].ToString(); ;
    ////            spriteTexture[i].sprite = GetSpritefromImage(path);
    ////            spriteTexture[i].preserveAspect = true;

    ////        }
    ////        else
    ////        {
    ////            Debug.LogWarning("Null references in EditableImages");
    ////        }
    ////    }
    ////}

}
