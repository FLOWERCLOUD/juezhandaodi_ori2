// Duke Chiang ,E-mail dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Attack")]
	public class RoleReset : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Role))]
		public FsmOwnerDefault gameObject;
		
		public bool everyFrame;
		public override void Reset()
		{
			gameObject = null;
			everyFrame = true;
		}
		
		public override void OnEnter()
		{
			DoReset();
			if (!everyFrame)
			{
				Finish();
			}
		}
		
		public override void OnUpdate()
		{
			DoReset();
		}
		
		void DoReset()
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
			r.Reset();
		}
		
	}
}