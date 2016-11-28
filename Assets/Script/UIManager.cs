using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class UIManager : MonoBehaviour
{
    // 싱글톤 ---
    private static UIManager _instance;
    
    public static UIManager Instance
    {
        get
        {
            if (!_instance)
            {
                _instance = (UIManager)GameObject.FindObjectOfType(typeof(UIManager));
                
                if (!_instance)
                {
                    GameObject container = new GameObject();
                    container.name = "UIManager";
                    _instance = container.AddComponent(typeof(UIManager)) as UIManager;
                }
            }
            
            return _instance;
        }
    }

    void OnDestroy()
    {
        _instance = null;
    }

    void OnApplicationQuit()
    {
        _instance = null;
    }

    // 씬 전환 및 UI 띄우기.

    public GameObject popups;

    public void OnPopup(GameObject popup)
    {
        popups.SetActive(true);
        currentPopup = popup;
        currentPopup.SetActive(true);
    }

    GameObject currentPopup;

    public void OffPopup()
    {
        popups.SetActive(false);
        currentPopup.SetActive(false);
    }
}
