using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

/// <summary>
/// フェードアウト(暗転)
/// </summary>
public class Fadeout : MonoBehaviour
{
    [SerializeField]
    [Header("透明度が変わるスピード")]
    float fadeSpeed = 0.02f;
    float red, green, blue, alfa;

    //フェードアウト完了を管理するフラグ
    public bool isFadeOut = false;
    //フェードイン処理の開始を完了するフラグ
    public bool isFadeIn = false;
    //透明度を変更するパネルのイメージ
    Image fadeImage;

    private bool starting = false;

    // Start is called before the first frame update
    void Start()
    {
        fadeImage = GetComponent<Image>();
        red = fadeImage.color.r;
        green = fadeImage.color.g;
        blue = fadeImage.color.b;
        alfa = fadeImage.color.a;

        
    }

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

        if (isFadeOut)
        {
            StartFadeOut();
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
    }

    void StartFadeOut()
    {
        fadeImage.enabled = true;  // a)パネルの表示をオンにする
        if (Input.GetKey(KeyCode.Space))
        {
            starting = true;
        }
        if (starting)
        {
            alfa += fadeSpeed;         // b)不透明度を徐々にあげる
            SetAlpha();               // c)変更した透明度をパネルに反映する
            if (alfa >= 1)
            {             // d)完全に不透明になったら処理を抜ける
                isFadeOut = false;
                SceneManager.LoadScene("Description");
            }
        }
    }

    void SetAlpha()
    {
        fadeImage.color = new Color(red, green, blue, alfa);
    }
}
