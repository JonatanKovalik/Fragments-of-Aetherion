using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Playables;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static MainMenuBlocksAnimation;

public class FrameAnimation : MonoBehaviour
{
    public GameObject[] canvas;
    public TMP_Text[] texts;
    public GameObject[] buttons;
    public GameObject Panel;
    public PlayableDirector playableDirectorForward;
    public GameObject StarshipControler;
    public static bool frameanimationend;
    public Camera Camera;
    public GameObject VFXPS;
    public GameObject standshipmodel;
    public GameObject iconekeybind;
    void Start()
    {
        frameanimationend = false;
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        texts[0].enabled = false;
        texts[1].enabled = false;
        texts[2].enabled = false;
        iconekeybind.SetActive(false);
        RectTransform rectTransform = GetComponent<RectTransform>();
        canvas[1].SetActive(false);
    }
    private void Update()
    {
        if (AnimationShipModelEnd)
        {
            canvas[1].SetActive(true);
            playableDirectorForward.Play();
            StartCoroutine(wait());
            AnimationShipModelEnd = false;
        }
        if(frameanimationend && Input.GetKeyDown(KeyCode.E))
        {
            canvas[1].SetActive(false);
            playableDirectorForward.Stop();
            StartCoroutine(StarShipModelPostionAnimation());
            frameanimationend = false;
        }
    }
    private IEnumerator StarShipModelPostionAnimation()
    {
        float duration = 3.2f;
        float elapsedTime = 0f;
        Vector3 endPosition = new Vector3(-1.75f, -57, 1221);
        Vector3 startPosition = new Vector3(0, -57, -7.096f);
        while (elapsedTime < duration)
        {
            StarshipControler.GetComponent<Transform>().position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        StarshipControler.GetComponent<Transform>().position = endPosition;
        yield return new WaitForSeconds(4);
        StartCoroutine(CameraAnimationRotationBack());
        VFXPS.SetActive(false);
    }
    private IEnumerator CameraAnimationRotationBack()
    {
        float duration = 1f;
        float elapsedTime = 0f;
        Quaternion endRotation = Quaternion.Euler(-90, 0, 0);
        Quaternion startRotation = Quaternion.Euler(22.583f, 0, 0);
        while (elapsedTime < duration)
        {
            Camera.GetComponent<Transform>().rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        Camera.GetComponent<Transform>().rotation = endRotation;
        Debug.Log("Camera rotation animation completed.");
        StartCoroutine(CameraAnimationPositon());
    }
    private IEnumerator CameraAnimationPositon()
    {
        float duration = 0.89f;
        float elapsedTime = 0f;
        Vector3 endPosition = new Vector3(0, 1, -9.3f);
        Vector3 startPosition = new Vector3(0, -56.38f, -9.3f);
        while (elapsedTime < duration)
        {
            Camera.GetComponent<Transform>().position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        Camera.GetComponent<Transform>().position = endPosition;
        Debug.Log("Camera position animation completed.");
        StartCoroutine(CameraAnimationRotation());
    }
    private IEnumerator CameraAnimationRotation()
    {
        float duration = 1f;
        float elapsedTime = 0f;
        Quaternion endRotation = Quaternion.Euler(0, 0, 0);
        Quaternion startRotation = Quaternion.Euler(90, 0, 0);
        while (elapsedTime < duration)
        {
            Camera.GetComponent<Transform>().rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        Camera.GetComponent<Transform>().rotation = endRotation;
        Debug.Log("Camera rotation animation completed.");
        canvas[0].SetActive(true);
        standshipmodel.GetComponent<Transform>().position = new Vector3(0, -58, -36.14f);
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        texts[0].enabled = false;
        texts[1].enabled = false;
        texts[2].enabled = false;
        iconekeybind.SetActive(false);
    }
    private IEnumerator wait()
    {
        yield return new WaitForSeconds(3.5f);
        buttons[0].SetActive(true);
        buttons[1].SetActive(true);
        texts[0].enabled = true;
        texts[1].enabled = true;
        texts[2].enabled = true;
        iconekeybind.SetActive(true);
        frameanimationend = true;
    }
}
