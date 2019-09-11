﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEditor;

public class UpdateProductPage : MonoBehaviour
{
    public GameObject ProductManager;
    public TMP_InputField NameInput;
    public TMP_InputField PriceInput;
    public TMP_InputField DescriptionInput;
    public TMP_InputField UsageInput;
    public RawImage img;
    string path;
    public static string imagestr;
    public static Texture2D ImgText;

    // Start is called before the first frame update
    void Start()
    {
        img.texture = ProductManager.GetComponent<ProductInfo>().img.texture;
        NameInput.text = ProductManager.GetComponent<ProductInfo>().Name.text;
        PriceInput.text = ProductManager.GetComponent<ProductInfo>().Price.text;
        DescriptionInput.text = ProductManager.GetComponent<ProductInfo>().Description.text;
        UsageInput.text = ProductManager.GetComponent<ProductInfo>().Usage.text;
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    public void OpenExplorer()
    {
        path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
        GetImage();
    }

    void GetImage()
    {
        if (path != null)
        {
            UpdateImage();
            //ConvertImg();
        }
    }

    void UpdateImage()
    {
        WWW www = new WWW("file:///" + path);
        img.texture = www.texture;
    }

    /*public void ConvertImg()
    {
        ImgText = (Texture2D)img.GetComponent<RawImage>().texture;
        byte[] TextureBytes = ImgText.EncodeToPNG();
        img = System.Convert.ToBase64String(TextureBytes);
    }*/
}
