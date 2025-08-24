using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using static MainMenuButtonFunc;

public class SettingsUIAnimation : MonoBehaviour
{
    public GameObject[] canvas;
    public PlayableDirector playableDirectorForward;
    public GameObject[] Panels;
    private void Update()
    {
        if (SettingsAnimationend)
        {
            canvas[0].SetActive(true);
            Panels[0].SetActive(false);
            playableDirectorForward.Play();
            StartCoroutine(WaitForAnimation());
            SettingsAnimationend = false;
        }
    }
    private IEnumerator WaitForAnimation()
    {
        yield return new WaitForSeconds(4.24f);
        Panels[0].SetActive(true);
    }
    private void Start()
    {
        canvas[0].SetActive(false);
    }
}
