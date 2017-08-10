// Duke Chiang.Email：dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("NGUI")]
	public class NGUISetUILabelString : FsmStateAction
	{
		[RequiredField]
		[Tooltip("控件名称。如：UI/NGUIRoot/AttackPanel/AttackButton/Label")]
		public FsmString gameObjectPathName;
		
		[RequiredField]
		public FsmString text;
		
		public override void Reset()
		{
			gameObjectPathName = null;
			
			text = null;
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
			
			UILabel label = go.GetComponent<UILabel>();
			if(label == null)
			{
				Debug.Log("您所指定控件的无UILabel组件");
				Finish();
			}

			label.text = text.Value;
			Finish();
			
		}
	}
}
