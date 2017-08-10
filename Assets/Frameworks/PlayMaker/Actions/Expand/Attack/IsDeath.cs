// Duke Chiang ,E-mail dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Attack")]
	public class IsDeath : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Role))]
		public FsmOwnerDefault gameObject;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmBool storeIsDead;

		public bool everyFrame;
		public override void Reset()
		{
			gameObject = null;
			storeIsDead = false;
			everyFrame = true;
		}
		
		public override void OnEnter()
		{
			DoIsDead();
			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoIsDead();
		}

		void DoIsDead()
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
			if(storeIsDead != null){
				storeIsDead.Value = r.IsDead();
			}
		}
		
	}
}