using System.Collections;
using Unity.AppUI.UI;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Playables;
using static MainMenuButtonFunc;

public class MainMenuBlocksAnimation : MonoBehaviour
{
    public GameObject StarshipControler;
    public GameObject StarshipStand;
    public GameObject PSVFX;
    public PlayableDirector[] playableDirectors;
    public static bool AnimationShipModelEnd;
    void Update()
    {
        if(LoadGameButtonClicked && ButtonName == "LoadGameButton")
        {
            StarshipStand.SetActive(true);
            PSVFX.SetActive(true);
            playableDirectors[1].Play();
            StartCoroutine(StarShipModelPostionAnimation());
            LoadGameButtonClicked = false;
        }
    }
    private IEnumerator StarShipModelPostionAnimation()
    {
        yield return new WaitForSeconds(1.63f);
        float duration = Random.Range(5,8);
        float elapsedTime = 0f;
        Vector3 startPosition = new Vector3(-1.75f, -57, 1221);
        Vector3 endPosition = new Vector3(0, -57, -7.096f);
        while (elapsedTime < duration)
        {
            StarshipControler.GetComponent<Transform>().position = Vector3.Lerp(startPosition, endPosition, elapsedTime / duration);
            yield return null;
            elapsedTime += Time.deltaTime;
        }
        StarshipControler.GetComponent<Transform>().position = endPosition;
        playableDirectors[0].Play();
        yield return new WaitForSeconds(10.8f);
        AnimationShipModelEnd = true;

    }
    private void Start()
    {
        StarshipStand.SetActive(false);
        PSVFX.SetActive(false);
        StarshipControler.GetComponent<Transform>().position = new Vector3(-1.75f, -57, 1221);
        StarshipControler.GetComponent<Transform>().rotation = Quaternion.Euler(0, 0, 0);
        AnimationShipModelEnd = false;
    }
}
