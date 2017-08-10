// Duke Chiang.Email：dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("NGUI")]
	[Tooltip("伤害显示数字，在世界坐标中转换至NGUI坐标中显示")]
	public class NGUIAddStringUILabel : FsmStateAction
	{
		[RequiredField]
		[Tooltip("Prefab名称：如AttackButton")]
		public FsmString uiPrefabName;
		
		[RequiredField]
		public FsmString rootTag;
		
		[RequiredField]
		public FsmString receiveDamageTag;
		[RequiredField]
		public FsmString showString;
		
		public override void Reset()
		{
			uiPrefabName = null;
			rootTag = null;
			
			receiveDamageTag = null;
			
			showString = null;
		}
		
		public override void OnEnter()
		{		
			GameObject receiveDamageGo = GameObject.FindGameObjectWithTag(receiveDamageTag.Value);
			if(receiveDamageGo == null)
			{
				Debug.LogError("受到伤害的对象Tag或GameObject不存在");
				Finish();
				return;
			}
			GameObject rootGo = GameObject.FindGameObjectWithTag(rootTag.Value);
			if(rootGo == null)
			{
				Debug.LogError("NGUI UIRoot的Tag或UI Root不存在");
				Finish();
				return;
			}
			GameObject a  =(GameObject) GameObject.Instantiate(Resources.Load(uiPrefabName.Value));
			if(a == null)
			{
				Debug.LogError("UI Prefab不存在");
				Finish();
				return;
			}
			
			a.transform.parent = rootGo.transform;
			Vector3 aPosition = Camera.main.WorldToScreenPoint(receiveDamageGo.transform.position);
			//产生位移效果，防止重叠
			aPosition.x += (Random.value*100 - 50);
			aPosition.y += (Random.value*100 - 50);
			
			aPosition.z = 0;
			a.transform.position = UICamera.mainCamera.ScreenToWorldPoint(aPosition);
			a.transform.localScale= new Vector3(1,1,1);
			a.GetComponent<UILabel>().text = showString.Value;
			a.GetComponent<UILabel>().MakePixelPerfect();
			Finish();
		}
		
	}
}