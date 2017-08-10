// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Navigation")]
	public class GetNavAgentIsMove : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(UnityEngine.AI.NavMeshAgent))]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmBool storeValue;
		public bool everyFrame;
		
		GameObject goLastFrame;
		PlayMakerFSM fsm;
		
		public override void Reset()
		{
			gameObject = null;
			storeValue = null;
		}
		
		public override void OnEnter()
		{
			DoGetFsmBool();
			
			if (!everyFrame)
				Finish();
		}
		
		public override void OnUpdate()
		{
			DoGetFsmBool();
		}
		
		void DoGetFsmBool()
		{
			if (storeValue == null) return;
			
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null) return;

			storeValue.Value = !(go.GetComponent<UnityEngine.AI.NavMeshAgent>().velocity == Vector3.zero);
		}
		
	}
}