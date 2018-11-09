using UnityEngine;
using UnityEngine.UI;

public class Settings_Toggle : MonoBehaviour
{

	Toggle m_Toggle;

    void Start()
    {
        m_Toggle = GetComponent<Toggle>();
		
        m_Toggle.onValueChanged.AddListener(delegate {
                ToggleValueChanged(m_Toggle);
            });
    }

    void ToggleValueChanged(Toggle change)
    {
		if (m_Toggle.isOn == true)
		{
			Screen.SetResolution(1280, 720, true);
		}
		else
		{
			Screen.SetResolution(1280, 720, false);
		}
    }
}
