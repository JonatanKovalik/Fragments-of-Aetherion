using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class MainMenuButtonFunc : MonoBehaviour
{
    public Button StartGameButton;
    public Button LoadGameButton;
    public Button SettingsButton;
    public Button QuitButton;
    public Camera Camera;
    private void Start()
    {
        Camera.GetComponent<Transform>().position = new Vector3(0, 1, -9.3f);
    }
    public void StartButtonClick()
    {
        StartCoroutine(CameraAnimationRotation());
        Debug.Log("Start Button Clicked");
    }

    public void LoadButtonClick()
    {
        StartCoroutine(CameraAnimationRotation());
        Debug.Log("Load Button Clicked");
    }
    public void SettingsButtonClick()
    {
        StartCoroutine(SettingsCameraAnimation());
    }
    public void QuitButtonClick()
    {
        StartCoroutine(QuitRotationCameraAnimation());
    }
    private IEnumerator QuitRotationCameraAnimation()
    {
        float duration = 1.54f;
        float elapsedTime = 0f;
        Quaternion startRotation = Quaternion.Euler(0, 0, 0);
        Quaternion endRotation = Quaternion.Euler(0, -180, 0);
        while (elapsedTime < duration)
        {
            Camera.GetComponent<Transform>().rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        Camera.GetComponent<Transform>().rotation = endRotation;
        Camera.GetComponent<Transform>().position = new Vector3(0, 1, -9.3f);
        Debug.Log("Camera rotation animation completed.");
        StartCoroutine(QuitPostionCameraAnimation());
        Debug.Log("Camera position animation started.");
    }
    private IEnumerator QuitPostionCameraAnimation()
    {
        float duration = 0.64f;
        float elapsedTime = 0f;
        Vector3 startPosition = new Vector3(0, 1, -9.3f);
        Vector3 endPosition = new Vector3(0, 9.45f, -9.3f);
        while (elapsedTime < duration)
        {
            Camera.GetComponent<Transform>().position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        Camera.GetComponent<Transform>().position = endPosition;
        Debug.Log("Camera position animation completed.");
    }
    private IEnumerator SettingsCameraAnimation()
    {
        float duration = 1.75f;
        float elapsedTime = 0f;
        Vector3 startPosition = new Vector3(0, 1, -9.3f);
        Vector3 endPosition = new Vector3(16.54f, 1, -9.3f);
        while (elapsedTime < duration)
        {
            Camera.GetComponent<Transform>().position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        Camera.GetComponent<Transform>().position = endPosition;
        Debug.Log("Camera position animation completed.");
    }
    private IEnumerator CameraAnimationPositon()
    {
        float duration = 0.64f;
        float elapsedTime = 0f;
        Vector3 startPosition = new Vector3(0, 1, -9.3f);
        Vector3 endPosition = new Vector3(0, -45.21f, -9.3f);
        while (elapsedTime < duration)
        {
            Camera.GetComponent<Transform>().position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        Camera.GetComponent<Transform>().position = endPosition;
        Debug.Log("Camera position animation completed.");
    }
    private IEnumerator CameraAnimationRotation()
    {
        float duration = 1f;
        float elapsedTime = 0f;
        Quaternion startRotation = Quaternion.Euler(0, 0, 0);
        Quaternion endRotation = Quaternion.Euler(90, 0, 0);
        while (elapsedTime < duration)
        {
            Camera.GetComponent<Transform>().rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        Camera.GetComponent<Transform>().rotation = endRotation;
        Debug.Log("Camera rotation animation completed.");
        StartCoroutine(CameraAnimationPositon());
        Debug.Log("Camera position animation started.");
    }
}

