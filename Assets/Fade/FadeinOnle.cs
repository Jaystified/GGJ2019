using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
/// <summary>
/// フェードインオンリー
/// </summary>

public class FadeinOnle : MonoBehaviour
{
    [SerializeField]
    [Header("透明度が変わるスピード")]
    float fadeSpeed = 0.02f;
    float red, green, blue, alfa;

    

    Color visible = new Color(1f, 1f, 1f, 1f);
    Color invisible = new Color(1f, 1f, 1f, 0f);

    //フェードイン処理の開始を完了するフラグ
    public bool isFadeIn = false;
    //透明度を変更するパネルのイメージ
    Image fadeImage;
    // Start is called before the first frame update
    void Start()
    {
        
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
        if (isFadeIn)
        {
            StartFadeIn();
           
        }
    }
    void StartFadeIn()
    {
        
            alfa -= fadeSpeed;                //a)不透明度を徐々に下げる
            SetAlpha();                      //b)変更した不透明度パネルに反映する
            if (alfa <= 0)
            {                    //c)完全に透明になったら処理を抜ける
                isFadeIn = false;
                fadeImage.enabled = false;    //d)パネルの表示をオフにする
            }
            void SetAlpha()
            {
                fadeImage.color = new Color(red, green, blue, alfa);
            }
            
        

        
    }

   
}

