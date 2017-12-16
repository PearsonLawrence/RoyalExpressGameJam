using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {

    public GameObject Canvas1, Canvas2;
    public Image Fade;
    public float FadeSpeed;
    public bool fadein = true, fadeOut;
    public bool Begin, GameBegin;
    public bool start;
    public bool win;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if(fadein)
        {
            Color fader = new Color(0, 0, 0, Time.deltaTime * FadeSpeed);
            Fade.color -= fader;
            if(Fade.color.a <= .1)
            {
                if(Begin)
                {

                    Canvas1.SetActive(true);
                }
                fadein = false;
            }
        }
        if(fadeOut)
        {
            Color fader = new Color(0, 0, 0, Time.deltaTime * FadeSpeed);
            Fade.color += fader;
            if (Fade.color.a >= 1)
            {
                if(start)
                {
                    SceneManager.LoadScene("Level1");
                }
                else if(win)
                {
                    SceneManager.LoadScene("Menu");

                }

                fadeOut = false;// = false;
            }
        }
	}

    public void StartClick()
    {
        
        Canvas1.SetActive(false);
        Canvas2.SetActive(true);

    }

    public void PlayClick()
    {
        fadeOut = true;
        fadein = fadein = false;
        start = true;
    }
    public void QuitClick()
    {
        Application.Quit();
  