using System.Collections;
using Unity.AppUI.UI;
using UnityEngine;
using UnityEngine.Playables;

public class ButtonsFancSettingsMenu : MonoBehaviour
{
    public GameObject[] Panels;
    public PlayableDirector director;
    public PlayableDirector mainpanelanimation;
    private bool isPlaying;
    private string[] panelsname = { "Graphics", "Audio", "Controls", "UI", "Return" };
    private string currentpanelname;
    public GameObject panelanimation;
    private bool stopdirectorplay;
    public Camera maincamera;
    public GameObject canvassettings;
    public GameObject MainPanel;
    public GameObject maincanvas;
    public void GraphicsButtonClicked()
    {
        currentpanelname = panelsname[0];
        if (!isPlaying)
        {
            isPlaying = true;
        }
    }
    public void AudioButtonClicked()
    {
        currentpanelname = panelsname[1];
        if (!isPlaying)
        {
            isPlaying = true;
        }
    }
    public void ControlsButtonClicked()
    {
        currentpanelname = panelsname[2];
        if (!isPlaying)
        {
            isPlaying = true;
        }
    }
    public void UIButtonClicked()
    {
        currentpanelname = panelsname[3];
        if (!isPlaying)
        {
            isPlaying = true;
        }
    }
    public void ReturnButtonClicked()
    {
        Panels[0].SetActive(false);
        Panels[1].SetActive(false);
        Panels[2].SetActive(false);
        Panels[3].SetActive(false);
        MainPanel.SetActive(false);
        isPlaying = false;
        panelanimation.SetActive(false);
        StartCoroutine(animationend());
    }
    private IEnumerator animationend()
    {
        if (!stopdirectorplay)
        {
            //yield return new WaitForSeconds(2.43f);
            stopdirectorplay = true;
        }
        Panels[4].SetActive(false);
        yield return new WaitForSeconds(4.24f);
        canvassettings.SetActive(false);
        StartCoroutine(SettingsCameraAnimationReturn());
    }
    private IEnumerator SettingsCameraAnimationReturn()
    {
        float duration = 1.75f;
        float elapsedTime = 0f;
        Vector3 endPosition = new Vector3(0, 1, -9.3f);
        Vector3 startPosition = new Vector3(16.54f, 1, -9.3f);
        while (elapsedTime < duration)
        {
            maincamera.GetComponent<Transform>().position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        maincamera.GetComponent<Transform>().position = endPosition;
        Debug.Log("Camera position animation completed.");
        maincanvas.SetActive(true);
    }
    private void Update()
    {
        if (isPlaying && stopdirectorplay == true)
        {
            panelanimation.SetActive(true);
            director.Play();
            stopdirectorplay = false;
        }
        if (director.state != PlayState.Playing && isPlaying)
        {
            if (currentpanelname == panelsname[0])
            {
                Panels[0].SetActive(true);
                Panels[1].SetActive(false);
                Panels[2].SetActive(false);
                Panels[3].SetActive(false);
            }
            else if (currentpanelname == panelsname[1])
            {
                Panels[0].SetActive(false);
                Panels[1].SetActive(true);
                Panels[2].SetActive(false);
                Panels[3].SetActive(false);
            }
            else if (currentpanelname == panelsname[2])
            {
                Panels[0].SetActive(false);
                Panels[1].SetActive(false);
                Panels[2].SetActive(true);
                Panels[3].SetActive(false);
            }
            else if (currentpanelname == panelsname[3])
            {
                Panels[0].SetActive(false);
                Panels[1].SetActive(false);
                Panels[2].SetActive(false);
                Panels[3].SetActive(true);
            }
        }
    }
    private void Start()
    {
        isPlaying = false;
        panelanimation.SetActive(false);
        stopdirectorplay = true;
        MainPanel.SetActive(false);
    }
}
