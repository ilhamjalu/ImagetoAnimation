using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
using System;

public class CropScript : MonoBehaviour
{
    public TMP_InputField tinggi, lebar;
    public float cTinggi, cLebar;
    public RawImage cropImage, originalImage, resultImage;

    // For saving to the _savepath
    int _CaptureCounter = 0;

    public Slider sliderHeight, sliderWidth;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        //var tinggiCrop = cropImage.rectTransform.rect.height;

        //if(tinggi.text != "")
        //{
        //    cTinggi = float.Parse(tinggi.text);
        //}
        //else
        //{
        //    cLebar = cropImage.rectTransform.rect.height;
        //}

        //if (lebar.text != "")
        //{
        //    cLebar = float.Parse(lebar.text);
        //}
        //else
        //{
        //    cLebar = cropImage.rectTransform.rect.width;
        //}

        var a = cropImage.GetComponent<RectTransform>();
        a.sizeDelta = new Vector2(sliderWidth.value, sliderHeight.value);
    }

    public void Cropping(string folder)
    {
        Texture2D croppedTexture = new Texture2D((int)cropImage.rectTransform.rect.width, (int)cropImage.rectTransform.rect.height);
        Texture2D originalTexture = (Texture2D)originalImage.mainTexture;
        Texture2D originalTextureResized = ResizeTexture2D(originalTexture, (int)originalImage.rectTransform.rect.width, (int)originalImage.rectTransform.rect.height);
        croppedTexture.SetPixels(originalTextureResized.GetPixels((int)cropImage.rectTransform.anchoredPosition.x, (int)cropImage.rectTransform.anchoredPosition.y, (int)cropImage.rectTransform.rect.width, (int)cropImage.rectTransform.rect.height));
        croppedTexture.Apply();
        resultImage.texture = croppedTexture;

        string _SavePath = Application.streamingAssetsPath + "/";
        string path = _SavePath + folder + "/";

        System.IO.File.WriteAllBytes(path + _CaptureCounter.ToString() + ".png", croppedTexture.EncodeToPNG());
        ++_CaptureCounter;

        Debug.Log("RESULT CROP");
    }

    Texture2D ResizeTexture2D(Texture2D originalTexture, int resizedWidth, int resizedHeight)
    {
        RenderTexture renderTexture = new RenderTexture(resizedWidth, resizedHeight, 32);
        RenderTexture.active = renderTexture;
        Graphics.Blit(originalTexture, renderTexture);
        Texture2D resizedTexture = new Texture2D(resizedWidth, resizedWidth);
        resizedTexture.ReadPixels(new Rect(0, 0, resizedWidth, resizedHeight), 0, 0);
        resizedTexture.Apply();
        return resizedTexture;
    }
}
