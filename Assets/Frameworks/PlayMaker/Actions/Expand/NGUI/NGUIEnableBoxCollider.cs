// Duke Chiang.Email：dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("NGUI")]
	public class NGUIEnableBoxCollider : FsmStateAction
	{
		[RequiredField]
		[Tooltip("控件名称。如：UI/NGUIRoot/AttackPanel/AttackButton")]
		public FsmString gameObjectPathName;
		
		[RequiredField]
		public FsmBool enable;
		
		public override void Reset()
		{
			gameObjectPathName = null;
			
			enable = true;
		}
		
		public override void OnEnter()
		{
			if(gameObjectPathName.IsNone || gameObjectPathName == null || gameObjectPathName.Value == ""|| gameObjectPathName.Value == null)
			{
				Debug.Log("需要指定控件路径名称，否则无法获取控件");
				Finish();
			}
			
			GameObject go = GameObject.Find(gameObjectPathName.Value);
			if(go == null)
			{
				Debug.Log("您所指定控件的路径名称，不存在");
				Finish();
			}
			
			BoxCollider box = go.GetComponent<BoxCollider>();
			if(box == null)
			{
				Debug.Log("您所指定控件的无UILabel组件");
				Finish();
			}
			
			box.enabled = enable.Value;
			Finish();
			
		}
	}
}
