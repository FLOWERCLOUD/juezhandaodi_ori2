// Duke Chiang.Email：dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("NGUI")]
	public class NGUISetUISpriteFillAmount : FsmStateAction
	{
		[RequiredField]
		[Tooltip("控件名称。如：UI/NGUIRoot/AttackPanel/AttackButton/Cooling")]
		public FsmString gameObjectPathName;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmFloat fillAmount;

		public FsmBool everyFrame;
		
		public override void Reset()
		{
			gameObjectPathName = null;
			fillAmount = 1;
			everyFrame = true;
		}

		void DoIt()
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
			
			UISprite sprite = go.GetComponent<UISprite>();
			if(sprite == null)
			{
				Debug.Log("您所指定控件的无UILabel组件");
				Finish();
			}
			sprite.fillAmount = fillAmount.Value;
		}

		public override void OnUpdate()
		{
			DoIt();
		}

		public override void OnEnter()
		{
			DoIt();
			if(!everyFrame.Value)
			{
				Finish();
			}
		}
	}
}
