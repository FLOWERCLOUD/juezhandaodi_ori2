// Duke Chiang ,E-mail dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("EasyTouch")]
	[Tooltip("Sends an Event when a EasyTouch On_JoystickMove is pressed.")]
	public class GetEasyJoystickMove : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(EasyJoystick))]
		[Tooltip("The GameObject with an EasyJoystick component.")]
		public FsmOwnerDefault gameObject;
		public FsmEvent sendEvent;
		[UIHint(UIHint.Variable)]
		public FsmBool storeResult;
		public override void Reset()
		{
			sendEvent = null;
			storeResult = null;
		}
		
		
		public override void OnEnter()
		{
			DoIt();
		}

		void DoIt()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);
			if(go != null){
				EasyJoystick joystick = go.GetComponent<EasyJoystick>();
				if(joystick!=null){
					EasyJoystick.On_JoystickMove += On_JoystickMove;
					EasyJoystick.On_JoystickMoveEnd += On_JoystickMoveEnd;
				}else{
					Finish();
				}
			}else{
				Finish();
			}
		}
		
		void On_JoystickMove(MovingJoystick move)
		{
			Fsm.Event(sendEvent);
			
			storeResult.Value = true;
		}
		
		void On_JoystickMoveEnd(MovingJoystick move)
		{
			storeResult.Value = false;
		}

		void OnExit(){
			EasyJoystick.On_JoystickMove -= On_JoystickMove;
			EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
		}

	}
}