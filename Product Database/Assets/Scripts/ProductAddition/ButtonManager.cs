using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonManager : MonoBehaviour
{
    public GameObject Page1;
    public GameObject Page2;
    public GameObject Page3;
    public GameObject Page4;

    public Button Nextbutton;

    private int page_index = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (page_index >= 4)
        {
            Nextbutton.gameObject.SetActive(false);
        }
        else
        {
            Nextbutton.gameObject.SetActive(true);
        }

        if (page_index <= 0)
        {
            UnityEngine.SceneManagement.SceneManager.LoadScene(1); // go back to main menu
        }
        else if (page_index == 1)
        {
            Page1.SetActive(true);
            Page2.SetActive(false);
            Page3.SetActive(false);
            Page4.SetActive(false);
        }
        else if (page_index == 2)
        {
            Page1.SetActive(false);
            Page2.SetActive(true);
            Page3.SetActive(false);
            Page4.SetActive(false);
        }
        else if (page_index == 3)
        {
            Page1.SetActive(false);
            Page2.SetActive(false);
            Page3.SetActive(true);
            Page4.SetActive(false);
        }
        else
        {
            Page1.SetActive(false);
            Page2.SetActive(false);
            Page3.SetActive(false);
            Page4.SetActive(true);
        }
    }

    public void Next()
    {
        page_index += 1;
        if (page_index > 4) page_index = 4;
    }

    public void Back()
    {
        page_index -= 1;
        if (page_index < 0) page_index = 0;
    }
}
