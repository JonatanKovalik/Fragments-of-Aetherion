using System.Collections;
using UnityEngine;
using UnityEngine.Playables;

public class PanelAnimationQuit : MonoBehaviour
{
    public GameObject[] Canvas;
    public GameObject[] Panels;
    public Camera Camera;
    public PlayableDirector director;
    public static bool HasQuitAnimationEnded;
    public static bool IsReturnButtonPressed;
    private void Start()
    {
        Canvas[0].SetActive(false);
        Canvas[1].SetActive(true);
        Canvas[2].SetActive(false);
        Canvas[3].SetActive(false);
        Panels[1].SetActive(false);
        HasQuitAnimationEnded = false;
        IsReturnButtonPressed = false;
    }
    private void Update()
    {
        if (HasQuitAnimationEnded)
        {
            Canvas[1].SetActive(false);
            Canvas[0].SetActive(true);
            Canvas[2].SetActive(false);
            Canvas[3].SetActive(false);
            Panels[0].SetActive(true);
            director.Play();
            StartCoroutine(WaitForDirectorToFinish());
            HasQuitAnimationEnded = false;
        }
        if (IsReturnButtonPressed)
        {
            Panels[1].SetActive(false);
            Panels[0].SetActive(false);
            StartCoroutine(WaitForDirectorToFinishReturnAnimation());
            IsReturnButtonPressed = false;
        }
    }
       private IEnumerator WaitForDirectorToFinish()
    {
        yield return new WaitUntil(() => director.state != PlayState.Playing);
        Debug.Log("Director has stopped playing.");
        Panels[1].SetActive(true);
    }
    private IEnumerator WaitForDirectorToFinishReturnAnimation()
    {
        yield return new WaitUntil(() => director.state != PlayState.Playing);
        StartCoroutine(QuitPostionCameraAnimation());

    }
    private IEnumerator QuitRotationCameraAnimation()
    {
        float duration = 1.54f;
        float elapsedTime = 0f;
        Quaternion endRotation = Quaternion.Euler(0, 0, 0);
        Quaternion startRotation = Quaternion.Euler(0, -180, 0);
        while (elapsedTime < duration)
        {
            Camera.GetComponent<Transform>().rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        Camera.GetComponent<Transform>().rotation = endRotation;
        Camera.GetComponent<Transform>().position = new Vector3(0, 1, -9.3f);
        Canvas[0].SetActive(false);
        Canvas[1].SetActive(true);
        Canvas[2].SetActive(false);
        Canvas[3].SetActive(false);
        Panels[0].SetActive(false);
        Panels[1].SetActive(false);
        HasQuitAnimationEnded = false;
        IsReturnButtonPressed = false;
    }
    private IEnumerator QuitPostionCameraAnimation()
    {
        float duration = 0.64f;
        float elapsedTime = 0f;
        Vector3 endPosition = new Vector3(0, 1, -9.3f);
        Vector3 startPosition = new Vector3(0, 9.45f, -9.3f);
        while (elapsedTime < duration)
        {
            Camera.GetComponent<Transform>().position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        Camera.GetComponent<Transform>().position = endPosition;
        Debug.Log("Camera position animation completed.");
        StartCoroutine(QuitRotationCameraAnimation());
    }
}
