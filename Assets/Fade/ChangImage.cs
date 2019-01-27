using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ChangImage : MonoBehaviour
{
    //一枚目の画像
    [SerializeField]
    [Header("一枚目")]
    Sprite image0;

    //二枚目の画像
    [SerializeField]
    [Header("二枚目")]
    Sprite image1;

    //三枚目の画像
    [SerializeField]
    [Header("三枚目")]
    Sprite image2;

    //4枚目の画像
    [SerializeField]
    [Header("シーン変更用")]
    Sprite image3;


    [SerializeField]
    [Header("何秒事")]
    public float timeOut = 5;
private float timeTrigger = 0;
    public Image image;

    

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        timeTrigger += Time.deltaTime;

        if (timeTrigger >= timeOut)
        {
            scrollImage_1();
        }
        if (timeTrigger >= timeOut*2)
        {
            scrollImage_2();
        }
        if (timeTrigger >= timeOut*3)
        {
            scrollImage_3();
        }
        if(timeTrigger>= timeOut*4)
        {
            scrollImage_4();
            SceneManager.LoadScene("Blocks");
        }
         
       
    }

    void scrollImage_1()
    {
        image0 = Resources.Load<Sprite>("1P");
        image = this.GetComponent<Image>();
        image.sprite = image0;
    }

    void scrollImage_2()
    {
        image1 = Resources.Load<Sprite>("2P");
        image = this.GetComponent<Image>();
        image.sprite = image1;
    }

    void scrollImage_3()
    {
        image2 = Resources.Load<Sprite>("3P");
        image = this.GetComponent<Image>();
        image.sprite = image2;
    }

    void scrollImage_4() //シーン変更用
    {
        image3 = Resources.Load<Sprite>("3P");
        image = this.GetComponent<Image>();
        image.sprite = image3;
    }


    //void scrollImage()
    //{
    //    //3つをループさせる
    //    //1枚目
    //    {
    //        image1 = Resources.Load<Sprite>("1P");
    //        image = this.GetComponent<Image>();
    //        image.sprite = image1;
    //    }

    //    //2枚目
    //    {
    //        image2 = Resources.Load<Sprite>("WIN");
    //        image = this.GetComponent<Image>();
    //        image.sprite = image2;
    //    }

    //    //3枚目
    //    {
    //        image3 = Resources.Load<Sprite>("1P");
    //        image = this.GetComponent<Image>();
    //        image.sprite = image3;
    //    }
    //}


}
