using UnityEngine;
using System.Collections;

public class LoginPanelEventHandler : MonoBehaviour {
	UIManageUtil uiManageUtil;
	GameObject registerPanel;
	GameObject usernameInputField;
	GameObject passwordInputField;
	GameObject noticeTextField;
	void Start()
	{
		uiManageUtil = GameObject.FindGameObjectWithTag("UIRoot").GetComponent<UIManageUtil>();
		usernameInputField = uiManageUtil.GetGameObjectByName("LoginPanel/UsernameInputField").gameObject;
		passwordInputField = uiManageUtil.GetGameObjectByName("LoginPanel/PasswordInputField").gameObject;
		noticeTextField = uiManageUtil.GetGameObjectByName("NoticeTextField").gameObject;
	}

	public void LoginButtonOnClick()
	{
		if(usernameInputField.GetComponent<UIInput>().value.Equals(""))
		{
			noticeTextField.SetActive(true);
			noticeTextField.GetComponentInChildren<UILabel>().text = "帐号不能为空";
			return;
		}

		if(passwordInputField.GetComponent<UIInput>().value.Equals(""))
		{
			noticeTextField.SetActive(true);
			noticeTextField.GetComponentInChildren<UILabel>().text = "密码不能为空";
			return;
		}
		if(usernameInputField.GetComponent<UIInput>().value.Equals("Duke") && passwordInputField.GetComponent<UIInput>().value.Equals("Duke"))
		{
			Destroy(gameObject);
		}
		else
		{
			noticeTextField.SetActive(true);
			noticeTextField.GetComponentInChildren<UILabel>().text = "帐号或密码错误";
		}

	}

	public void RegisterButtonOnClick()
	{
		uiManageUtil.LoadUIPrefabToUIRoot("UI/RegisterPanel");
	}

	public void QuitButtonOnClick()
	{
		Application.Quit();
	}
}
