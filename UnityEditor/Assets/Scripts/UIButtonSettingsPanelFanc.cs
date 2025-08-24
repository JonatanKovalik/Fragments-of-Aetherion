using UnityEngine;

public class UIButtonSettingsPanelFanc : MonoBehaviour
{
    public static bool GraphicsButtonClicked;
    public static bool AudioButtonClicked;
    public static bool ControlsButtonClicked;
    public static bool UIButtonCliced;
    public static bool ReturnButtonClicked;
    public void GraphicsButtonClickedFanc()
    {
        GraphicsButtonClicked = true;
    }
    public void AudioButtonClickedFanc()
    {
        AudioButtonClicked = true;
    }
    public void ControlsButtonClickedFanc()
    {
        ControlsButtonClicked = true;
    }
    public void UIButtonClicedFanc()
    {
        UIButtonCliced = true;
    }
    public void ReturnButtonClickedFanc()
    {
        ReturnButtonClicked = true;
    }
    private void Start()
    {
        GraphicsButtonClicked = false;
        AudioButtonClicked = false;
        ControlsButtonClicked = false;
        UIButtonCliced = false;
        ReturnButtonClicked = false;
    }
}
