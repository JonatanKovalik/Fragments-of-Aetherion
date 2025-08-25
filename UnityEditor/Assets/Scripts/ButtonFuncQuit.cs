using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Playables;
using UnityEngine.UI;
using static PanelAnimationQuit;

public class ButtonFuncQuit : MonoBehaviour
{
    public Button QuitButton;
    public Button ReturnButton;
    public void QuitButtonPressed()
    {
        Debug.Log("Quit Button Pressed");
        Debug.LogWarning("Quitting from the game");
        Application.Quit();
    }
    public void ReturnButtonPressed()
    {
        Debug.Log("Return Button Pressed");
        IsReturnButtonPressed = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        if (eventData.pointerEnter != QuitButton.gameObject)
        {
            Debug.Log("Mouse exited the Quit Button area!");
        }
        if (eventData.pointerEnter != ReturnButton.gameObject)
        {
            Debug.Log("Mouse exited the Return Button area!");
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if (eventData.pointerEnter == QuitButton.gameObject)
        {
            Debug.Log("Mouse entered the Quit Button!");
            GUI.skin.settings.cursorColor = Color.red;
        }
        else if (eventData.pointerEnter == ReturnButton.gameObject)
        {
            Debug.Log("Mouse entered the Return Button!");
            GUI.skin.settings.cursorColor = Color.darkCyan;
        }
    }

}
