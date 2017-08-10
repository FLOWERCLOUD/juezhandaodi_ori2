// Duke Chiang ,E-mail dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("EasyTouch")]
	[Tooltip("Get the value of a Vector2 Variable from EasyTouch Joystick. x and y value between -1 & 1")]
	public class GetEasyJoystickAxisVector2 : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(EasyJoystick))]
		[Tooltip("The GameObject with an EasyJoystick component.")]
		public FsmOwnerDefault gameObject;

		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmVector2 storeJoystickAxis;
		public override void Reset()
		{
			gameObject = null;
			storeJoystickAxis = null;
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
			storeJoystickAxis.Value = move.joystickAxis;
		}

		void On_JoystickMoveEnd(MovingJoystick move)
		{
			storeJoystickAxis.Value = new Vector2(0,0);
		}

		void OnExit(){
			EasyJoystick.On_JoystickMove -= On_JoystickMove;
			EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
		}
	}
}