using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickActionController : MonoBehaviour
{
    UnityEngine.Video.VideoPlayer vp;
    //public GameObject dialogBox, closeButton;
    GameObject playButton, pauseButton;
    string hitTag;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit, 1000f))
            {
                if (hit.transform)
                {
                    hitTag = hit.transform.gameObject.tag;
                    if (hitTag.Equals("Sponsors"))
                    {
                        Debug.Log(hit.transform.gameObject.name);
                        Application.OpenURL(hit.transform.gameObject.name);
                    }
                    else if(hitTag.Equals("Video") || hitTag.Equals("PlayButton"))
                    {
                        vp = hit.transform.gameObject.GetComponentInParent<UnityEngine.Video.VideoPlayer>();
                        playButton = hit.transform.GetChild(0).gameObject;
                        pauseButton = hit.transform.GetChild(1).gameObject;
                        if (vp.isPlaying)
                        {
                            vp.Pause();
                            pauseButton.SetActive(true);
                            playButton.SetActive(false);
                        }
                        else
                        {
                            vp.Play();
                            pauseButton.SetActive(false);
                            playButton.SetActive(false);
                        }
                    }
                    /*else if(hitTag.Equals("Billboard"))
                    {
                        Debug.Log(hitTag);
                        dialogBox.SetActive(true);
                        closeButton.SetActive(true);
                    }
                    else if(hitTag.Equals("Web"))
                    {
                        Application.OpenURL("https://www.gujarattourism.com/");
                    }

                    else if (hitTag.Equals("Phone"))
                    {
                        Application.OpenURL("tel:+91 79 23977200");
                    }

                    else if (hitTag.Equals("Map"))
                    {
                        Application.OpenURL("https://goo.gl/maps/TCmar384r6xcbVKp9");
                    }
                    else if(hit.transform.gameObject.tag.Equals("PlayButton"))
                    {
                       vp = hit.transform.gameObject.GetComponentInParent<UnityEngine.Video.VideoPlayer>();
                        if (vp.isPlaying)
                        {
                            vp.Pause();
                            pauseButton.SetActive(true);
                            playButton.SetActive(false);
                        }
                        else
                        {
                            vp.Play();
                            pauseButton.SetActive(false);
                            playButton.SetActive(false);
                        }
                    }*/


                }
            }
        }
    }

    
}
