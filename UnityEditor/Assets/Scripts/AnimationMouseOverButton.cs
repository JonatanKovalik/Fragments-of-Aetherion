using System.Collections;
using UnityEngine;
using UnityEngine.Playables;
using UnityEngine.UI;
using static ButtonAreaChecker;

public class AnimationMouseOverButton : MonoBehaviour
{
    public Button[] buttons;
    public PlayableDirector startGameButtonAnimation;
    public PlayableDirector loadGameButtonAnimation;
    public PlayableDirector settingsButtonAnimation;
    public PlayableDirector quitButtonAnimation;

    private void Update()
    {
        if (MouseOverStartGameButton)
        {
            startGameButtonAnimation.enabled = false;
        }
        else if (!MouseOverStartGameButton)
        {
            startGameButtonAnimation.enabled = true;
        }
        if(MouseOverLoadGameButton)
        {
            loadGameButtonAnimation.enabled = false;
        }
        else if (!MouseOverLoadGameButton)
        {
            loadGameButtonAnimation.enabled = true;
        }
        if(MouseOverSettingsButton)
        {
            settingsButtonAnimation.enabled = false;
        }
        else if (!MouseOverSettingsButton)
        {
            settingsButtonAnimation.enabled = true;
        }
        if(MouseOverQuitButton)
        {
            quitButtonAnimation.enabled = false;
        }
        else if (!MouseOverQuitButton)
        {
            quitButtonAnimation.enabled = true;
        }
    }
}
