using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;
using System.IO;
using System.Text;
using TMPro;

public class ProductManager : MonoBehaviour
{
    public InputField Name;
    public InputField Price;
    public InputField Description;
    public InputField Usage;
    public RawImage img;

    public Button submitButton;

    string Namestr = "";
    string Pricestr = "";
    string Descriptionstr = "";
    string Usagestr = "";

    public TextMeshProUGUI NameConfirm;
    public TextMeshProUGUI PriceConfirm;
    public TextMeshProUGUI DescriptionConfirm;
    public TextMeshProUGUI UsageConfirm;
    public RawImage ImgConfirm;

    void Update()
    {
        if (Name.IsActive())
        {
            Namestr = Name.text;
            NameConfirm.text = Namestr;
        }

        if (Price.IsActive())
        {
            Pricestr = Price.text;
            PriceConfirm.text = Pricestr;
        }

        if (Description.IsActive())
        {
            Descriptionstr = Description.text;
            DescriptionConfirm.text = "Description: " + Descriptionstr;
        }
        if (Usage.IsActive())
        {
            Usagestr = Usage.text;
            UsageConfirm.text = "Usage: " + Usagestr;
        }

        if (img.texture != null)
        {
            ImgConfirm.texture = img.texture;
        }

        VerifiInputs();
    }

    public void CallAddProduct()
    {
        StartCoroutine(AddProduct());
    }

    IEnumerator AddProduct()
    {
        WWWForm form = new WWWForm();
        form.AddField("name", Name.text);
        form.AddField("price", Price.text);
        form.AddField("description", Description.text);
        form.AddField("usage", Usage.text);
        form.AddField("img", FileExplorer.imagestr);

        WWW www = new WWW("http://localhost/sqlconnect/product_add.php", form);  //access a page and get infor from it
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Product created successfully.");
            Name.text = "";
            Price.text = "";
            Description.text = "";
            Usage.text = "";
        }
        else
        {
            Debug.Log("Product creation failed. Error #" + www.text);
        }
    }

    public void VerifiInputs()
    {
        submitButton.interactable = (Namestr.Length >= 1 && Pricestr.Length >= 1 && Descriptionstr.Length >= 1 && Usagestr.Length >= 1 && ImgConfirm.texture != null);
    }
}

/*string[] data;
    public string filePath;
    public List<string> newData;
    TextAsset productdata;

    // Start is called before the first frame update
    void Start()
    {
        productdata = Resources.Load<TextAsset>("Product Database");
        filePath = getPath();

        data = productdata.text.Split(new char[] { '\n' });
        newData.Add("Name,Price,Description");
        for (int i=1;i < data.Length; i++)
        {
            if (data[i] != "") newData.Add(data[i]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(Name.text);
        Debug.Log(Price.text);
    }

    public void Submit() // Add new data to the current database
    {
        if (Name.text != "" && Price.text != "")
        {
            Debug.Log("Submitted");
            newData.Add(Name.text + "," + Price.text + "," + Description.text);
            Name.text = "";
            Price.text = "";
        }
    }

    public void Finish() // Update the database when you finish
    {
        System.IO.File.WriteAllText(filePath, string.Empty);

        foreach (string str in newData)
        {
            if (str != "")
            {
                try
                {
                    using (System.IO.StreamWriter file = new System.IO.StreamWriter(filePath, true))
                    {
                        file.WriteLine(str);
                    }
                }
                catch (Exception ex)
                {
                    throw new ApplicationException("This program has an error: ", ex);
                }
            }
            else newData.Remove(str);
        }
    }

    public void Empty() // Update the database when you finish
    {
        System.IO.File.WriteAllText(filePath, string.Empty);
    }

    void OpenFile()
    {

    }

    private string getPath()
    {
        #if UNITY_EDITOR
                return Application.dataPath + "/Resources/" + "Product Database.csv";
        #elif UNITY_ANDROID
                return Application.persistentDataPath+"Saved_data.csv";
        #elif UNITY_IPHONE
                return Application.persistentDataPath+"/"+"Saved_data.csv";
        #else
                return Application.dataPath +"/"+"Saved_data.csv";
        #endif
    }*/
