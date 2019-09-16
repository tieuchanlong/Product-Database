using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;
using System.IO;

public class ProductInfo : MonoBehaviour
{
    public InputField InputName;
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Price;
    public TextMeshProUGUI Description;
    public TextMeshProUGUI Usage;
    public RawImage img;

    public GameObject SearchPage;
    public GameObject DetailPage;
    public static string changedName;
    
    // Start is called before the first frame update
    void Start()
    {
        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ProductSearch()
    {

        StartCoroutine(CallSearch());
    }

    IEnumerator CallSearch()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", InputName.text);
        form.AddField("price", "");
        form.AddField("description", "");
        form.AddField("usage", "");
        form.AddField("img", "");
        WWW www = new WWW("http://localhost/sqlconnect/product_get.php", form);  //access a page and get infor from it
        yield return www;

        changedName = InputName.text;

        string[] productinfos = www.text.Split(new char[] { '*' });
        Debug.Log(www.text);
        Name.text = productinfos[0];
        Price.text = productinfos[1];
        Description.text = productinfos[2];
        Usage.text = productinfos[3];

        byte[] bytes = Convert.FromBase64String(productinfos[4]);

        Texture2D tex = new Texture2D(2, 2);
        tex.LoadImage(bytes);
        img.texture = tex;


        InputName.text = "";
        SearchPage.SetActive(false);
        DetailPage.SetActive(true);
    }
}
