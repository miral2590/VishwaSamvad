using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class SceneChanger : MonoBehaviour
{
    public GameObject mainPanel, loadingPanel;
    public Animator loadingGif;
    public TMP_Text quoteText;
  
    // Start is called before the first frame update
    void Start()
    {
        mainPanel.SetActive(true);
        loadingPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.Escape))
        {
            Application.Quit();
        }
    }
    public void ChangeTheScene()
    {
        mainPanel.SetActive(false);
        loadingPanel.SetActive(true);
        StartCoroutine("ChangeScene");   
    }

    IEnumerator ChangeScene()
    {
        loadingGif.Play("GandhijiLoading");
        quoteText.text = UIController.Quotes[Random.Range(0,19)];
        yield return new WaitForSeconds(1f);
        AsyncOperation operation = SceneManager.LoadSceneAsync("ARScene");
        while (!operation.isDone)
        {
            yield return null;
        }
    }
}
