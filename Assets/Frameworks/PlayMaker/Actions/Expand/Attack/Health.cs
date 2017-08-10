// Duke Chiang ,E-mail dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Attack")]
	public class Health : FsmStateAction
	{
		[RequiredField]
		public FsmString healthGameObjectTag;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmInt storeHealth;

		
		public override void Reset()
		{
			healthGameObjectTag = null;
			storeHealth = 0;
		}
		
		public override void OnEnter()
		{
			GameObject healthGameObjectGo = GameObject.FindGameObjectWithTag(healthGameObjectTag.Value);
			if(healthGameObjectGo == null)
			{
				Finish();
				return;
			}
			Role healthGameObjectRole = healthGameObjectGo.GetComponent<Role>();
			if(healthGameObjectRole == null)
			{
				Finish();
				return;
			}

			if(storeHealth != null){
				storeHealth.Value = healthGameObjectRole.Health();
			}
			Finish();
		}
		
	}
}