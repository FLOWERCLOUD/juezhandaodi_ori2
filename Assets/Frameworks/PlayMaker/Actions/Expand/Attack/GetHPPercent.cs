// Duke Chiang ,E-mail dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Attack")]
	public class GetHPPercent : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Role))]
		public FsmOwnerDefault gameObject;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmFloat storeHPPercent;
		
		public bool everyFrame;
		public override void Reset()
		{
			gameObject = null;
			storeHPPercent = 0f;
			everyFrame = true;
		}
		
		public override void OnEnter()
		{
			DoGetHPPercent();
			if (!everyFrame)
			{
				Finish();
			}
		}
		
		public override void OnUpdate()
		{
			DoGetHPPercent();
		}
		
		void DoGetHPPercent()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if(go == null)
			{
				Finish();
				return;
			}
			
			Role r = go.GetComponent<Role>();
			if(r == null)
			{
				Finish();
				return;
			}
			if(storeHPPercent != null){
				storeHPPercent.Value = r.GetHPPercent();
			}
		}
		
	}
}