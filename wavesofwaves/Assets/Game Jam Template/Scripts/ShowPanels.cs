using UnityEngine;
using UnityEngine.UI;

public class ShowPanels : MonoBehaviour
{
	public GameObject optionsPanel;							//Store a reference to the Game Object OptionsPanel 
	public GameObject optionsTint;							//Store a reference to the Game Object OptionsTint 
	public GameObject menuPanel;							//Store a reference to the Game Object MenuPanel 
	public GameObject pausePanel;							//Store a reference to the Game Object PausePanel 

    bool isMenu = false;
    bool isPauseMenu = false;

	//Call this function to activate and display the Options panel during the main menu
	public void ShowOptionsPanel()
	{
		optionsPanel.SetActive(true);
		optionsTint.SetActive(true);
        optionsPanel.GetComponentInChildren<Selectable>().Select();
	}

	//Call this function to deactivate and hide the Options panel during the main menu
	public void HideOptionsPanel()
	{
		optionsPanel.SetActive(false);
		optionsTint.SetActive(false);
	}

	//Call this function to activate and display the main menu panel during the main menu
	public void ShowMenu()
	{
        if (isMenu)
        {
            menuPanel.SetActive(true);
            menuPanel.GetComponentInChildren<Selectable>().Select();
            isMenu = false;
        }
	}

	//Call this function to deactivate and hide the main menu panel during the main menu
	public void HideMenu()
	{
		menuPanel.SetActive (false);
        isMenu = true;
	}
	
	//Call this function to activate and display the Pause panel during game play
	public void ShowPausePanel()
	{
        if (isPauseMenu)
        {
            pausePanel.SetActive(true);
            pausePanel.GetComponentInChildren<Selectable>().Select();
            optionsTint.SetActive(true);
            isPauseMenu = false;
        }
	}

	//Call this function to deactivate and hide the Pause panel during game play
	public void HidePausePanel()
	{
		pausePanel.SetActive (false);
		optionsTint.SetActive(false);
        isPauseMenu = true;
	}
}
