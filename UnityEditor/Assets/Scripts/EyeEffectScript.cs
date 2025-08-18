using System.Collections;
using UnityEngine;

public class EyeEffectScript : MonoBehaviour
{
    public GameObject EyeTheRuinedTitanModel;
    private bool isEyeActive;
    public AudioSource AudioSource;
    public void Update()
    {
        while (!isEyeActive)
        {
            StartCoroutine(eyeturnoffandturnon());
            isEyeActive = true;
        }
    }
    private void Start()
    {
        EyeTheRuinedTitanModel.SetActive(false);
        isEyeActive = false;
    }
    private IEnumerator eyeturnoffandturnon()
    {
        yield return new WaitForSeconds(Random.Range(4,6));
        EyeTheRuinedTitanModel.SetActive(true);
        AudioSource.Play();
        yield return new WaitForSeconds(Random.Range(0.7f,1.4f));
        EyeTheRuinedTitanModel.SetActive(false);
        isEyeActive = false;
    }
}
