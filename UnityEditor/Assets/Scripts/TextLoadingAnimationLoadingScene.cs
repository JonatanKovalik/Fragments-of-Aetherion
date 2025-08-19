using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class TextLoadingAnimationLoadingScene : MonoBehaviour
{
    public Text textloading;

    private void Start()
    {
        textloading.text = "Loading";
        textloading.enabled = true;
        StartCoroutine(TextAnimation());
    }

    private IEnumerator TextAnimation()
    {
        while(true)
        {
            for (int i = 0; i <= 3; i++)
            {
                textloading.text = "Loading" + new string('.', i);
                yield return new WaitForSeconds(0.5f);
            }
        }
    }
}
