using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_AudioBar : MonoBehaviour
{
    public GameObject UIMaster;
    UI_Master uiMaster;

    protected float minFloat = .00f;
    protected float maxFloat = 1.00f;
    protected float randomFloat;
    protected float waitTime = 30.0f;

    private void Start()
    {
        uiMaster = UIMaster.GetComponent<UI_Master>();
    }

    // Update is called once per frame
    void Update()
    {
        BarChange();

        BarAmount();
    }

    void BarAmount()
    {
        switch (UI_Master.stationPlaying)
        {
            case 1:

                minFloat = .01f;
                maxFloat = .26f;
                waitTime = .1f;
                uiMaster.happyFace.SetActive(false);
                uiMaster.sleepyFace.SetActive(true);
                uiMaster.angryFace.SetActive(false);
                break;
            case 2:

                minFloat = .10f;
                maxFloat = .58f;
                waitTime = .3f;
                uiMaster.happyFace.SetActive(true);
                uiMaster.sleepyFace.SetActive(false);
                uiMaster.angryFace.SetActive(false);
                break;
            case 3:
                minFloat = .62f;
                maxFloat = 1.01f;
                waitTime = 1f;
                uiMaster.happyFace.SetActive(false);
                uiMaster.sleepyFace.SetActive(false);
                uiMaster.angryFace.SetActive(true);
                break;
            default:
                uiMaster.happyFace.SetActive(false);
                uiMaster.sleepyFace.SetActive(false);
                uiMaster.angryFace.SetActive(false);

                minFloat = .00f;
                maxFloat = .00f;
                break;
        }
    }
    void ChangeRandomNumber()
    {
        randomFloat = UnityEngine.Random.Range(minFloat, maxFloat);
    }

    void BarChange()
    {
        if (UI_Master.stationPlaying == 1 || UI_Master.stationPlaying == 2 || UI_Master.stationPlaying == 3)
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
}

