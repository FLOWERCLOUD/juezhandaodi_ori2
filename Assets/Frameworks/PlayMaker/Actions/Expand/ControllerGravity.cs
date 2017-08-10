// Duke Chiang ,E-mail dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Character)]
	[Tooltip("A Character Controller on a Game Object touch the ground.")]
	public class ControllerGravity : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(CharacterController))]
		[Tooltip("The GameObject to check.")]
		public FsmOwnerDefault gameObject;
		public FsmFloat gravity;
		[Tooltip("Repeat every frame while the state is active.")]
		public bool everyFrame;
		
		private GameObject previousGo; // remember so we can get new controller only when it changes.
		private CharacterController controller;
		
		public override void Reset()
		{
			gameObject = null;
			gravity = 1;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			DoControllerGravity();
			
			if (!everyFrame)
			{
				Finish();
			}
		}

		public override void OnUpdate()
		{
			DoControllerGravity();
		}
		
		void DoControllerGravity()
		{
			var go = Fsm.GetOwnerDefaultTarget(gameObject);
			if (go == null)
			{
				return;
			}
		
			if (go != previousGo)
			{
				controller = go.GetComponent<CharacterController>();
				previousGo = go;
			}
			
			if (controller == null)	return;
	
			var isGrounded = controller.isGrounded;

			if(!isGrounded)
			{
				controller.SimpleMove(Vector3.up*-1*gravity.Value);
			}

		}
	}
}
