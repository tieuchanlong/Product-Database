using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor;

public class FileExplorer1 : MonoBehaviour
{
    string path;
    public RawImage image;
    public static string imagestr;
    public static Texture2D ImgText;

    public void OpenExplorer()
    {
        Debug.Log("Pressed");
#if UNITY_EDITOR
        path = EditorUtility.OpenFilePanel("Overwrite with png", "", "png");
#endif
        GetImage();
    }

    public void GetImage()
    {
        if (path != null)
        {
            UpdateImage();
            ConvertImg();
        }
    }

    public void UpdateImage()
    {
        WWW www = new WWW("file:///" + path);

        if (www.texture != null) image.texture = www.texture;
    }

    public void ConvertImg()
    {
        ImgText = (Texture2D)image.GetComponent<RawImage>().texture;
        byte[] TextureBytes = ImgText.EncodeToPNG();
        imagestr = System.Convert.ToBase64String(TextureBytes);
    }
}
