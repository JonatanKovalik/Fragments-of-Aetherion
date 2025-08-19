using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TextChangeTips : MonoBehaviour
{
    public TextMeshPro TextMeshPro;
    List<string> tips = new List<string>
    {
        "Master the dodge, evade all harm.",
        "Your Aetherion abilities consume your soul.",
        "Parry at the perfect moment.",
        "Strike the enemy's illuminated weak point.",
        "Aetherion magic corrupts and empowers you.",
        "Light attacks chain, heavy attacks stagger.",
        "The Consortium’s ambition broke reality.",
        "Their technology fused with monstrous flesh.",
        "The world is a graveyard of dreams.",
        "Your purpose is to restore the core.",
        "The Aetherion whispers forbidden secrets.",
        "A forgotten lineage fights for restoration.",
        "Hidden paths hide in plain sight.",
        "Look for the glowing Aetherion fragments.",
        "The world's ruins hold forgotten power.",
        "Venture into the corrupted wastelands.",
        "Only the brave uncover true secrets.",
        "Your will is your greatest resource.",
        "Be wary of the corrupted flora.",
        "Every step echoes in the past."
    };

    private void Start()
    {
        StartCoroutine(AnimationTextChange());
    }

    private IEnumerator AnimationTextChange()
    {
         while (true)
        {
            int randomIndex = Random.Range(0, tips.Count+1);
            string randomTip = tips[randomIndex];
            TextMeshPro.text = randomTip;
            yield return new WaitForSeconds(Random.Range(2,3.5f));
        }
    }
}
