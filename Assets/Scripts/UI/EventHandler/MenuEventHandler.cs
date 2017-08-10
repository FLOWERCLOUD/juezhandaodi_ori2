using UnityEngine;
using System.Collections;

public class MenuEventHandler : MonoBehaviour {
	UIManageUtil uiManageUtil;
	GameObject menu;
	GameObject playerInfoPanel;
	void Start()
	{
		uiManageUtil = GameObject.FindGameObjectWithTag("UIRoot").GetComponent<UIManageUtil>();
		menu = uiManageUtil.GetGameObjectByName("Menu").gameObject;
		playerInfoPanel = uiManageUtil.GetGameObjectByName("PlayerInfoPanel").gameObject;
	}
	public void StartOnClick()
	{
		if(menu == null || playerInfoPanel == null){
			return;
		}
		menu.SetActive(false);
		playerInfoPanel.SetActive(false);
	}
}
