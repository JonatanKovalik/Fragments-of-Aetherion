using System.Collections;
using UnityEngine;


public class StartMainMenuScene : MonoBehaviour
{
    public AudioSource AudioSource;
    public GameObject cube;
    public GameObject NeonText;
    private void Start()
    {
        NeonText.SetActive(true);
        NeonText.GetComponent<Transform>().position = new Vector3(-1.889697f, 1.079377f, -8.114098f);
        NeonText.GetComponent<Transform>().localScale = new Vector3(0.4f, 0.4f, 0.4f);
        NeonText.GetComponent<Transform>().rotation = Quaternion.Euler(5.553f, 181.049f, 0);
        cube.GetComponent<Transform>().localScale = new Vector3(6, 6, 6);
        StartCoroutine(cubeanimation());
    }
    private IEnumerator cubeanimation()
    {
        float duration = 1.0f;
        float elapsedTime = 0f;
        Vector3 startScale = new Vector3(6, 6, 6);
        Vector3 endScale = new Vector3(0, 0, 0);
        AudioSource.Play();
        while (elapsedTime < duration)
        {
            cube.GetComponent<Transform>().localScale = Vector3.Lerp(startScale, endScale, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        cube.GetComponent<Transform>().localScale = endScale;
        Debug.Log("Cube animation completed.");
        yield return new WaitForSeconds(1.2f);
        StartCoroutine(NeonTextPositonAnimation());
        StartCoroutine(NeonTextRotationAnimation());
        StartCoroutine(NeonTextScaleAnimation());
    }
    private IEnumerator NeonTextScaleAnimation()
    {
        float duration = 2.3f;
        float elapsedTime = 0f;
        Vector3 startScale = new Vector3(0.4f, 0.4f, 0.4f);
        Vector3 endScale = new Vector3(1.4f, 1.4f, 1.4f);
        while (elapsedTime < duration)
        {
            NeonText.GetComponent<Transform>().localScale = Vector3.Lerp(startScale, endScale, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        NeonText.GetComponent<Transform>().localScale = endScale;
        Debug.Log("Neon text animation completed.");
    }
    private IEnumerator NeonTextPositonAnimation()
    {
        float duration = 2.3f;
        float elapsedTime = 0f;
        Vector3 startPosition = new Vector3(-1.889697f, 1.079377f, -8.114098f);
        Vector3 endPosition = new Vector3(-9.21f, 3.45f, -1.01f);
        while (elapsedTime < duration)
        {
            NeonText.GetComponent<Transform>().position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        NeonText.GetComponent<Transform>().position = endPosition;
        Debug.Log("Neon text position animation completed.");
    }
    private IEnumerator NeonTextRotationAnimation()
    {
        float duration = 2.3f;
        float elapsedTime = 0f;
        Quaternion startRotation = Quaternion.Euler(5.553f, 181.049f, 0);
        Quaternion endRotation = Quaternion.Euler(13.902f, 178.353f, 0.006f);
        while (elapsedTime < duration)
        {
            NeonText.GetComponent<Transform>().rotation = Quaternion.Lerp(startRotation, endRotation, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        NeonText.GetComponent<Transform>().rotation = endRotation;
        Debug.Log("Neon text rotation animation completed.");
    }
}
