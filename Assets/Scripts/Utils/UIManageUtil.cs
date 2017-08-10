using UnityEngine;
using System.Collections;
[RequireComponent(typeof(UIPanel))]
[RequireComponent(typeof(UIRoot))]
public class UIManageUtil : MonoBehaviour {

	public Transform GetGameObjectByName(string gameObjectName)
	{
		return transform.Find(gameObjectName);
	}
	//uiNamePrefab 格式如：Prefabs/RegisterPanel
	public GameObject LoadUIPrefabToUIRoot(string uiNamePrefab,Vector3 uiLocalPosition,Vector3 uiLocalScale)
	{
		GameObject a  =(GameObject) Instantiate(Resources.Load(uiNamePrefab));  
		a.transform.parent = transform;   
		a.transform.localPosition = uiLocalPosition;  
		a.transform.localScale= uiLocalScale;
		return a;
	}

	public GameObject LoadUIPrefabToUIRoot(string uiNamePrefab)
	{
		GameObject a  =(GameObject) Instantiate(Resources.Load(uiNamePrefab));  
		a.transform.parent = transform;   
		a.transform.localPosition = new Vector3(0,0,0);  
		a.transform.localScale= new Vector3(1,1,1);
		return a;
	}

}
