using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class PageManage : MonoBehaviour
{
    public GameObject ProductDetails;
    public GameObject ProductUpdate;
    public TMP_InputField NameInput;
    public TMP_InputField PriceInput;
    public TMP_InputField DescriptionInput;
    public TMP_InputField UsageInput;


    public int pageindex = 0;
    
    // Start is called before the first frame update
    void Start()
    {
        ProductDetails.SetActive(false);
        ProductUpdate.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void ReturnMenu()
    {
        SceneManager.LoadScene(1); // return to the menu
    }

    public void UpdateProduct()
    {
        ProductDetails.SetActive(false);
        NameInput.text = GetComponent<ProductInfo>().Name.text;
        PriceInput.text = GetComponent<ProductInfo>().Price.text;
        DescriptionInput.text = GetComponent<ProductInfo>().Description.text;
        UsageInput.text = GetComponent<ProductInfo>().Usage.text;
        ProductUpdate.SetActive(true);
    }

    public void SaveProduct()
    {
        StartCoroutine(AddProduct());

        ProductDetails.SetActive(true);
        ProductUpdate.SetActive(false);
    }

    IEnumerator AddProduct()
    {
        WWWForm form = new WWWForm();

        form.AddField("newname", NameInput.text);
        form.AddField("price", PriceInput.text);
        form.AddField("description", DescriptionInput.text);
        form.AddField("usage", UsageInput.text);
        form.AddField("img", FileExplorer.imagestr);

        WWW www = new WWW("http://localhost/sqlconnect/product_update.php", form);  //access a page and get infor from it
        yield return www;
        if (www.text == "0")
        {
            Debug.Log("Product updated successfully.");
        }
        else
        {
            Debug.Log("Product creation failed. Error #" + www.text);
        }
    }




}
