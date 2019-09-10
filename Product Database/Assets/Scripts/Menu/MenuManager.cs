﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void AccessAddProduct()
    {
        SceneManager.LoadScene(2);
    }

    public void AccessSearchProduct()
    {
        SceneManager.LoadScene(3);
    }

    public void ExitMenu()
    {
        SceneManager.LoadScene(0);
    }
}
