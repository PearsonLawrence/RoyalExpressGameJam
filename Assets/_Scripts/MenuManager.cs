using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class MenuManager : MonoBehaviour {

    public GameObject Canvas1, Canvas2, Canvas3, Canvas4, Canvas5;
    public Image Fade;
    public float FadeSpeed;
    public bool fadein = true, fadeOut;
    public bool Begin, GameBegin;
    public bool start;
    public bool win;
    public bool cutscene;
    public Cam cam;
    public MainMenuCam MCam;
	// Use this for initialization
	void Start () {
        cam = GetComponent<Cam>();
        MCam = GetComponent<MainMenuCam>();
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
                else if(GameBegin)
                {
                    
                    cam.start = false;
                }
                else if (cutscene)
                {
                    cutscene = false;
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
                else if(cutscene)
                {
                    transform.position = MCam.Point1.transform.position;
                    transform.rotation = MCam.Point1.transform.rotation;
                    Canvas3.SetActive(true);
                    Canvas2.SetActive(false);
                    MCam.Num = 0;
                    MCam.move = true;

                    Canvas1.SetActive(false);
                    fadein = true;
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
    public void PlayCutClick()
    {
        fadeOut = true;
        fadein = false;
        start = true;
        cutscene = false;
        Canvas5.SetActive(false);
        
        Canvas1.SetActive(false);
        Canvas2.SetActive(false);
    }
    public void PlayClick()
    {
        fadeOut = true;
        fadein =  false;
        cutscene = true;
        Canvas2.SetActive(false);
        Begin = false;
        Canvas1.SetActive(false);
    }
    public void QuitClick()
    {
        Application.Quit();
    }
    public void NextClick1()
    {
        transform.position = MCam.Point2.transform.position;
        transform.rotation = MCam.Point2.transform.rotation;
        Canvas3.SetActive(false);
        Canvas4.SetActive(true);

        Canvas1.SetActive(false);
        MCam.Num = 1;

    }
    public void NextClick2()
    {
        transform.position = MCam.Point3.transform.position;
        transform.rotation = MCam.Point3.transform.rotation;
        Canvas4.SetActive(false);

        Canvas1.SetActive(false);
        Canvas5.SetActive(true);
        MCam.Num = 2;

    }
    public void StartClickFinal()
    {

        fadeOut = true;
        fadein = false;
        start = true;
    }
}
