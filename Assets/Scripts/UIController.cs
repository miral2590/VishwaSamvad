using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIController : MonoBehaviour
{
    public TMP_Text[] quoteTexts;
    Animator[] quoteTextAnimators;
    public GetCurrentTrackable trackable;
    public GameObject sponsorDetails, dandiAnimation, dialogBox, arCam, cam, backArrow, closeButton;
    //public ClickActionController clickActionController;
    GameObject bgText;
    public Material material;

    public static string[] Quotes = { "An eye for eye only ends up making the whole world blind.",
                        "Where there is love there is life.",
                        "In a gentle way, you can shake the world.",
                        "Action expresses priorities.",
                        "Hate the sin, love the sinner.",
                        "The future depends on what we do in the present.",
                        "The weak can never forgive. Forgiveness is the attribute of the strong.",
                        "Earth provides enough to satisfy every man's needs, but not every man's greed.",
                        "If you don't ask, you don't get it.",
                        "If we could change ourselves, the tendencies in the world would also change.",
                        "A man is a product of his thoughts. What he thinks he becomes.",
                        "I will not let anyone walk through my mind with their dirty feet.",
                        "Nobody can hurt me without my permission.",
                        "Happiness is when what you think, what you say, and what you do are in harmony.",
                        "An ounce of practice is worth a thousand words.",
                        "A coward is incapable of exhibiting love; it is the prerogative of the brave.",
                        "Live as if you were to die tomorrow. Learn as if you were to live forever.",
                        "Freedom is not worth having if it does not include the freedom to make mistakes.",
                        "Service which is rendered without joy helps neither the servant nor the served.",
                        "In a gentle way, you can shake the world."};
    // Start is called before the first frame update
    void Start()
    {
        quoteTextAnimators = new Animator[quoteTexts.Length];
        Screen.orientation = ScreenOrientation.LandscapeLeft;

        bgText = GameObject.Find("BGTxt");
        bgText.SetActive(false);

        for(int i = 0; i<quoteTexts.Length; i++)
        {
            quoteTextAnimators[i] = quoteTexts[i].gameObject.GetComponent<Animator>();
        }
        //dialogBox.SetActive(false);
        //backArrow.SetActive(false);
        //closeButton.SetActive(false);
        //arCam.SetActive(true);
        //cam.SetActive(false);
        StartCoroutine("ChangeQuote");
        //ARCam.SetActive(false);
        //Cam.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }
        //if(trackable.targetName().Equals("Page3"))
        //{
        //    sponsorDetails.SetActive(true);
        //}
        //else if (trackable.targetName().Equals("Page1"))
        //{
        //    bgText.SetActive(true);
        //}
        //else if (trackable.targetName().Equals("DandiMarch"))
        //{
        //    dandiAnimation.SetActive(true);
        //}

    }

    IEnumerator ChangeQuote()
    {
        while(true)
        {
            for (int i = 0; i < quoteTexts.Length; i++)
            {
                quoteTextAnimators[i].Play("QuoteText");
                quoteTexts[i].text = Quotes[Random.Range(0, 19)];
            }    

            //Debug.Log(quoteText1.text);
            yield return new WaitForSeconds(3f);
        }
       
    }

    public void IMG1()
    {
        material.SetTexture("_MainTex", Resources.Load("360IMG-1") as Texture);
    }

    public void IMG2()
    {
        material.SetTexture("_MainTex", Resources.Load("360IMG-2") as Texture);
    }

    public void IMG3()
    {
        material.SetTexture("_MainTex", Resources.Load("360IMG-3") as Texture);
    }

    public void Open360ImageViewer()
    {
        //clickActionController.enabled = false;
        backArrow.SetActive(true);
        arCam.SetActive(false);
        cam.SetActive(true);
        dialogBox.SetActive(false);
        closeButton.SetActive(false);
    }

    public void Close360ImageViewer()
    {
        //clickActionController.enabled = true;
        backArrow.SetActive(false);
        dialogBox.SetActive(true);
        closeButton.SetActive(true);
        arCam.SetActive(true);
        cam.SetActive(false);
    }

    public void CloseDialogBox()
    {
        closeButton.SetActive(false);
        dialogBox.SetActive(false);
    }
}
