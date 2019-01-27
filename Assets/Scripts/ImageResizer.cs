using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageResizer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        GameObject theBar = gameObject;
        var theBarRectTransform = theBar.transform as RectTransform;
        theBarRectTransform.sizeDelta = new Vector2(Screen.width, Screen.height);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
