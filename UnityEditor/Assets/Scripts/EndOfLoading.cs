using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using static UnityEngine.ParticleSystem;

public class EndOfLoading : MonoBehaviour
{
    public GameObject spinerps;
    public GameObject cube;
    public AudioSource AudioSource;
    public AudioSource AudioSourceNeon;
    public Text loadinganimationtext;
    private void Start()
    {
        cube.GetComponent<Transform>().localScale = new Vector3(0,0,0);
        ParticleSystem ps = spinerps.GetComponent<ParticleSystem>();
        var mainModule = ps.main;
        mainModule.startSpeed = new ParticleSystem.MinMaxCurve(0f);
        try
        {
            StartCoroutine(EndOfLoadingCoroutine());
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error starting EndOfLoadingCoroutine: " + e.Message);
        }
    }
    private IEnumerator EndOfLoadingCoroutine()
    {
        AudioSourceNeon.Play();
        yield return new WaitForSeconds(Random.Range(8.5f, 12.2f));
        ParticleSystem ps = spinerps.GetComponent<ParticleSystem>();
        var mainModule = ps.main;
        float duration = 2.0f;
        float startSpeed = 0f;
        float endSpeed = 8f;
        float elapsedTime = 0f;
        while (elapsedTime < duration)
        {
            float currentSpeed = Mathf.Lerp(startSpeed, endSpeed, elapsedTime / duration);
            mainModule.startSpeed = new ParticleSystem.MinMaxCurve(currentSpeed);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        mainModule.startSpeed = new ParticleSystem.MinMaxCurve(endSpeed);
        AudioSourceNeon.Stop();
        Debug.Log("End of loading reached, starting cube animation.");
        try
        {
            StartCoroutine(cubeanimation());
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error during cube animation: " + e.Message);
        }
    }
    private IEnumerator cubeanimation()
    {
        loadinganimationtext.enabled = false;
        float duration = 1.0f;
        float elapsedTime = 0f;
        Vector3 startScale = new Vector3(0, 0, 0);
        Vector3 endScale = new Vector3(6, 6, 6);
        AudioSource.Play();
        while (elapsedTime < duration)
        {
            cube.GetComponent<Transform>().localScale = Vector3.Lerp(startScale, endScale, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        cube.GetComponent<Transform>().localScale = endScale;
        Debug.Log("Cube animation completed.");
        Debug.LogWarning("Change the scene to MainMenu!");
        try
        {
            SceneManager.LoadScene("MainMenuScene");
        }
        catch (System.Exception e)
        {
            Debug.LogError("Error loading MainMenu scene: " + e.Message);
        }
    }
}
