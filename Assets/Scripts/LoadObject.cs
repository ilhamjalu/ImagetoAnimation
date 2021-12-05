using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Linq;

public class LoadObject : MonoBehaviour
{
    public FileInfo[] fileInfo;
    public List<Sprite> spriteTexture;
    public List<string> nameCheck;
    public GameObject[] test;
    public Material testMat;
    public Material[] material;

    float nextFire = 0.0f, fireRate = 0.8f;

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("ScanFolder", 0f, 5f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ScanFolder()
    {
        Load("A", 0);
        Load("B", 1);
    }

    public void Load(string folder, int index)
    {
        string path = Application.streamingAssetsPath + "/";
        DirectoryInfo dir = new DirectoryInfo(path + folder);

        fileInfo = dir.GetFiles("*.*").OrderBy(a => a.CreationTime).Where(a => a.Extension != ".meta").ToArray();
        material = new Material[fileInfo.Count()];
        Debug.Log(fileInfo.Length);

        if (fileInfo.Length > 0)
        {
            int x = 0;

            StartCoroutine(Delay());
            IEnumerator Delay()
            {
                foreach (var info in fileInfo)
                {
                    //StartCoroutine(Delay());
                    if (nameCheck.Contains(info.ToString()) != true)
                    {
                        nameCheck.Add(info.ToString());

                        ImageLoader(info.ToString(), x, index);

                        x++;
                    }
                    Debug.Log(info);
                    yield return new WaitForSeconds(2);
                }
            }
            
        }
    }

    void ImageLoader(string a, int x, int index)
    {
        byte[] pngBytes = File.ReadAllBytes(a);
        
        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(pngBytes);
        
        //Sprite fromTex = Sprite.Create(tex, new Rect(0.0f, 0.0f, tex.width, tex.height), new Vector2(0.5f, 0.5f), 100.0f);

        material[x] = Instantiate(testMat, transform.position, transform.rotation);
        material[x].mainTexture = tex;

       
        SpawnObject(material[x], index);

    }

    public void SpawnObject(Material mat, int index)
    {
        //GameObject obj = Instantiate(test[Random.Range(0,test.Length)], transform.position, transform.rotation);

        var rotate = Quaternion.Euler(-90, 0, 0);

        GameObject obj = Instantiate(test[index], transform.position, rotate);
        obj.AddComponent<MeshRenderer>();
        obj.GetComponent<MeshRenderer>().material = mat;
    }




}
