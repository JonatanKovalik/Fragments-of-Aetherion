using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MainMenuButtonFunc : MonoBehaviour
{
    public Button StartGameButton;
    public Button LoadGameButton;
    public Button SettingsButton;
    public Button QuitButton;
    public GameObject canvas;
    public static bool LoadGameButtonClicked;
    public static string ButtonName;
    public Camera Camera;
    private void Start()
    {
        Camera.GetComponent<Transform>().position = new Vector3(0, 1, -9.3f);
        ButtonName = "";
        LoadGameButtonClicked = false;
        Camera.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
    }
    public void StartButtonClick()
    {
        canvas.SetActive(false);
        StartCoroutine(CameraAnimationRotation());
        ButtonName = "StartGameButton";
        Debug.Log("Start Button Clicked");
    }

    public void LoadButtonClick()
    {
        canvas.SetActive(false);
        StartCoroutine(CameraAnimationRotation());
        ButtonName = "LoadGameButton";
        Debug.Log("Load Button Clicked");
    }
    public void SettingsButtonClick()
    {
        canvas.SetActive(false);
        StartCoroutine(SettingsCameraAnimation());
        ButtonName = "SettingsButton";
    }
    public void QuitButtonClick()
    {
        canvas.SetActive(false);
        StartCoroutine(QuitRotationCameraAnimation());
        ButtonName = "QuitButton";
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
        float duration = 0.89f;
        float elapsedTime = 0f;
        Vector3 startPosition = new Vector3(0, 1, -9.3f);
        Vector3 endPosition = new Vector3(0, -56.38f, -9.3f);
        while (elapsedTime < duration)
        {
            Camera.GetComponent<Transform>().position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        Camera.GetComponent<Transform>().position = endPosition;
        Debug.Log("Camera position animation completed.");
        if(ButtonName == "StartGameButton")
        {
            SceneManager.LoadScene("_");//Replace name scene later
        }
        else if (ButtonName == "LoadGameButton")
        {
            StartCoroutine(CameraAnimationRotationBack());
        }
    }
    private IEnumerator CameraAnimationRotationBack()
    {
        float duration = 1f;
        float elapsedTime = 0f;
        Quaternion startRotation = Quaternion.Euler(90, 0, 0);
        Quaternion endRotation = Quaternion.Euler(22.583f, 0, 0);
        while (elapsedTime < duration)
        {
            Camera.GetComponent<Transform>().rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        Camera.GetComponent<Transform>().rotation = endRotation;
        Debug.Log("Camera rotation animation completed.");
        LoadGameButtonClicked = true;
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

