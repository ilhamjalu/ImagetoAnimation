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
            nameCheck.Clear();
        }
    }

    public void ScanFolder()
    {
        Load("Mobil", 0);
        Load("Helicopter", 1);
        Load("Truck", 2);
        Load("Truck Tangki", 3);
        Load("Truck PD", 4);
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
                for(int i = 0; i < fileInfo.Length; i++)
                {
                    if (nameCheck.Contains(fileInfo[i].ToString()) != true)
                    {
                        nameCheck.Add(fileInfo[i].ToString());
                        //int i = nameCheck.Add(info.ToString().Length);

                        //for(int x = 0; x <= info.ToString().Length; x++)
                        //{
                        ImageLoader(fileInfo[i].ToString(), x, index);
                        //}

                        x++;
                        yield return new WaitForSeconds(2);
                    }
                }
                //foreach (var info in fileInfo)
                //{
                //    //StartCoroutine(Delay());
                //    if (nameCheck.Contains(info.ToString()) != true)
                //    {
                //        nameCheck.Add(info.ToString());
                //        //int i = nameCheck.Add(info.ToString().Length);

                //        //for(int x = 0; x <= info.ToString().Length; x++)
                //        //{
                //            ImageLoader(info.ToString(), x, index);
                //        //}

                //        x++;
                //    }
                //    Debug.Log(info);
                //    yield return new WaitForSeconds(2);
                //}
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

        //var rotate = Quaternion.Euler(-90, 0, 0);

        GameObject obj = Instantiate(test[index], test[index].transform.position, Quaternion.identity);
        obj.AddComponent<MeshRenderer>();
        obj.GetComponent<MeshRenderer>().material = mat;
    }




}
