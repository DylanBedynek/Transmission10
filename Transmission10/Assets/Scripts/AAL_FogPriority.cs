using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AAL_FogPriority : MonoBehaviour {

    public Color colorMain;
    private string currentColor;

    private Material fogMaterial;
    public int fogNumber;
    public static bool changeAlpha;

    [SerializeField]
    private float lerpSpeed = 5f;
    float cAlpha;

    void Start()
    {
        colorMain = this.gameObject.GetComponent<Renderer>().material.color;
        if(fogNumber==1)    
            colorMain.a = 0f;
        var cAlpha = colorMain.a;
        currentColor = "black";
    }

    public void ChangeColor(string colorNumber)
    {
        if(colorNumber == "r")
        {
            //red
            colorMain = new Color(1f, 0f, 0f, 1f);
            this.gameObject.GetComponent<Renderer>().material.color = colorMain;
            currentColor = "r";
        }
        else if(colorNumber == "b")
        {
            //blue
            colorMain = new Color(0f, 0f, 1f, 1f);
            this.gameObject.GetComponent<Renderer>().material.color = colorMain;
            currentColor = "b";

        }
        else if (colorNumber == "g")
        {
            //green
            colorMain = new Color(0f, 1f, 0f, 1f);
            this.gameObject.GetComponent<Renderer>().material.color = colorMain;
            currentColor = "g";

        }
        else if(colorNumber == "black")
        {
            //black
            colorMain = new Color(0f, 0f, 0f, 1f);
            this.gameObject.GetComponent<Renderer>().material.color = colorMain;
            currentColor = "black";


        }

    }
    
    //public void FogOff()
    //{
    //    //turns the fog in the level off by making the material transparent
    //    cAlpha = colorMain.a;
    //    colorMain.a = Mathf.Lerp(1f,0f,lerpSpeed*Time.deltaTime);
    //    gameObject.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, cAlpha);
    //}

    //public void FogOn()
    //{
    //    //turns the fog in the level on by making the material opaque
    //    var cAlpha = colorMain.a;
    //    colorMain.a = Mathf.Lerp(0f, 1f, lerpSpeed * Time.deltaTime);
    //    gameObject.GetComponent<Renderer>().material.color = new Color(0f, 0f, 0f, cAlpha);
    //}

    IEnumerator FadeTo(float aValue, float aTime)
    {
        float alpha = this.gameObject.GetComponent<Renderer>().material.color.a;
        for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
        {
            if (currentColor == "r")
            {
                Color newColor = new Color(1, 0, 0, Mathf.Lerp(alpha, aValue, t));
                this.gameObject.GetComponent<Renderer>().material.color = newColor;
                yield return null;
            }
            else if (currentColor == "b")
            {
                Color newColor = new Color(0, 0, 1, Mathf.Lerp(alpha, aValue, t));
                this.gameObject.GetComponent<Renderer>().material.color = newColor;
                yield return null;
            }
            else if (currentColor == "g")
            {
                Color newColor = new Color(0, 1, 0, Mathf.Lerp(alpha, aValue, t));
                this.gameObject.GetComponent<Renderer>().material.color = newColor;
                yield return null;
            }
            else if (currentColor == "black")
            {
                Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha, aValue, t));
                this.gameObject.GetComponent<Renderer>().material.color = newColor;
                yield return null;
            }
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
            StartCoroutine(FadeTo(1.0f, 0.0f));
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
            StartCoroutine(FadeTo(0.0f, 1.0f));
    }
}
