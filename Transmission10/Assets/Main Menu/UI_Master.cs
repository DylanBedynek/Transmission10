using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_Master : MonoBehaviour {


    // public Image audioBars;
    public static int stationPlaying = 1;

    public GameObject happyFace;
    public GameObject sleepyFace;
    public GameObject angryFace;

    private void Start()
    {
        stationPlaying = 0;    
    }
  
}

#region Keeping code for any mistakes made later on
/*
public class UI_Master : MonoBehaviour
{


    // public Image audioBars;
    public int stationPlaying = 1;
    float minFloat = .00f;
    float maxFloat = 1.00f;
    float randomFloat;

    public float waitTime = 30.0f;
    private void Start()
    {
        stationPlaying = 0;
    }
    // Update is called once per frame
    void Update()
    {
        BarChange();
        BarAmount();
    }

    void BarChange()
    {
        if (stationPlaying == 1 || stationPlaying == 2 || stationPlaying == 3)
        {
            if (this.gameObject.GetComponent<Image>().fillAmount < .33)
                this.gameObject.GetComponent<Image>().color = Color.blue;

            if (this.gameObject.GetComponent<Image>().fillAmount < .66 && this.gameObject.GetComponent<Image>().fillAmount > .33)
                this.gameObject.GetComponent<Image>().color = Color.green;

            if (this.gameObject.GetComponent<Image>().fillAmount < 1 && this.gameObject.GetComponent<Image>().fillAmount > .66)
                this.gameObject.GetComponent<Image>().color = Color.red;



            if (this.gameObject.GetComponent<Image>().fillAmount > randomFloat)
                this.gameObject.GetComponent<Image>().fillAmount -= waitTime * Time.deltaTime;

            if (this.gameObject.GetComponent<Image>().fillAmount < randomFloat)
                this.gameObject.GetComponent<Image>().fillAmount += waitTime * Time.deltaTime;

            if (this.gameObject.GetComponent<Image>().fillAmount > randomFloat + .0005 || this.gameObject.GetComponent<Image>().fillAmount > randomFloat - .0005 || this.gameObject.GetComponent<Image>().fillAmount == 1)
                ChangeRandomNumber();
        }
        else
        {
            this.gameObject.GetComponent<Image>().fillAmount = 0;
        }
    }
    void BarAmount()
    {
        switch (stationPlaying)
        {
            case 1:

                minFloat = .01f;
                maxFloat = .26f;
                waitTime = .1f;

                break;
            case 2:

                minFloat = .10f;
                maxFloat = .58f;
                waitTime = .3f;
                break;
            case 3:
                minFloat = .62f;
                maxFloat = 1.01f;
                waitTime = 1f;
                break;
            default:
                minFloat = .00f;
                maxFloat = .00f;
                break;
        }
    }
    void ChangeRandomNumber()
    {
        Debug.Log("called ChangeRandomNumber();");
        randomFloat = UnityEngine.Random.Range(minFloat, maxFloat);
        Debug.Log(randomFloat);
    }


}
*/

#endregion