using UnityEngine;
using UnityEngine.UI;

public class ButtonAreaChecker : MonoBehaviour
{
    public Button[] buttons;
    public static bool MouseOverStartGameButton;
    public static bool MouseOverLoadGameButton;
    public static bool MouseOverSettingsButton;
    public static bool MouseOverQuitButton;

    private void Start()
    {
        MouseOverStartGameButton = false;
        MouseOverLoadGameButton = false;
        MouseOverSettingsButton = false;
        MouseOverQuitButton = false;
    }
    void Update()
    {
        Vector3 mousePosition = Input.mousePosition;
        foreach (Button button in buttons)
        {
            if (button != null && button.gameObject.activeInHierarchy)
            {
                RectTransform rectTransform = button.GetComponent<RectTransform>();
                Vector3[] corners = new Vector3[4];
                rectTransform.GetWorldCorners(corners);
                float minX = corners[0].x;
                float maxX = corners[2].x;
                float minY = corners[0].y;
                float maxY = corners[2].y;
                if (mousePosition.x >= minX && mousePosition.x <= maxX && mousePosition.y >= minY && mousePosition.y <= maxY)
                {
                    //Debug.Log("Mouse over: " + button.name);
                    if(button.name == "STARTGAMEButton")
                    {
                        MouseOverStartGameButton = true;
                        MouseOverLoadGameButton = false;
                        MouseOverSettingsButton = false;
                        MouseOverQuitButton = false;
                    }
                    else if (button.name == "LOADGAMEButton")
                    {
                        MouseOverStartGameButton = false;
                        MouseOverLoadGameButton = true;
                        MouseOverSettingsButton = false;
                        MouseOverQuitButton = false;
                    }
                    else if (button.name == "SETTINGSButton")
                    {
                        MouseOverStartGameButton = false;
                        MouseOverLoadGameButton = false;
                        MouseOverSettingsButton = true;
                        MouseOverQuitButton = false;
                    }
                    else if (button.name == "QUITButton")
                    {
                        MouseOverStartGameButton = false;
                        MouseOverLoadGameButton = false;
                        MouseOverSettingsButton = false;
                        MouseOverQuitButton = true;
                    }
                }
            }
        }
    }
}