using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class InteractionController : MonoBehaviour
{
    public GameObject m_personPrefab;

	public UnityEngine.UI.Text outText;

	public void OnButtonClicked()
	{
		if (outText != null)
		{
			outText.text = "<b>Last Interaction:</b>\nUI Button clicked";
		}
	}

	public void OnSliderChanged(float value)
	{
		if (outText != null)
		{
			outText.text = "<b>Last Interaction:</b>\nUI Slider value: " + value;
		}
	}

	public void OnToggleChanged(bool value)
	{
		if (outText != null)
		{
			outText.text = "<b>Last Interaction:</b>\nUI toggle value: " + value;
		}
	}

	public void OnClearText()
	{
		if (outText != null)
		{
			outText.text = "";
		}
	}

	public void OnBackToMenu()
	{
		SceneManager.LoadScene("main", LoadSceneMode.Single);
	}
}
