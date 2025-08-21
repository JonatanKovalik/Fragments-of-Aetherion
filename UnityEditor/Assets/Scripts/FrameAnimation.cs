using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using static MainMenuBlocksAnimation;
using System.Collections;
using TMPro;

public class FrameAnimation : MonoBehaviour
{
    public GameObject[] canvas;
    public TMP_Text[] texts;
    public GameObject[] buttons;
    public GameObject Panel;
    public PlayableDirector playableDirector;
    void Start()
    {
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        texts[0].enabled = false;
        texts[1].enabled = false;
        RectTransform rectTransform = GetComponent<RectTransform>();
        canvas[1].SetActive(false);
    }
    private void Update()
    {
        if (AnimationShipModelEnd)
        {
            canvas[1].SetActive(true);
            playableDirector.Play();
            StartCoroutine(wait());
            AnimationShipModelEnd = false;
        }
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(3.5f);
        buttons[0].SetActive(true);
        buttons[1].SetActive(true);
        texts[0].enabled = true;
        texts[1].enabled = true;
    }
}
