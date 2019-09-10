using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UpdateProductPage : MonoBehaviour
{
    public GameObject ProductManager;
    public TMP_InputField NameInput;
    public TMP_InputField PriceInput;
    public TMP_InputField DescriptionInput;
    public TMP_InputField UsageInput;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        NameInput.text = ProductManager.GetComponent<ProductInfo>().Name.text;
        PriceInput.text = ProductManager.GetComponent<ProductInfo>().Price.text;
        DescriptionInput.text = ProductManager.GetComponent<ProductInfo>().Description.text;
        UsageInput.text = ProductManager.GetComponent<ProductInfo>().Usage.text;
    }
}
