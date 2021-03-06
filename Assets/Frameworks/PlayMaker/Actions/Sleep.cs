// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Physics)]
	[Tooltip("Forces a Game Object's Rigid Body to Sleep at least one frame.")]
	public class Sleep : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(Rigidbody))]
		public FsmOwnerDefault gameObject;

		public override void Reset()
		{
			gameObject = null;
		}

		public override void OnEnter()
		{
			DoSleep();
			Finish();
		}

		void DoSleep()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null) return;
			if (go.GetComponent<Rigidbody>() == null) return;
			
			go.GetComponent<Rigidbody>().Sleep();
		}
	}
}