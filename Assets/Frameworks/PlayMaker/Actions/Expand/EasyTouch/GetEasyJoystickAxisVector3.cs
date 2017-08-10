// Duke Chiang.Email：dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("EasyTouch")]
	[Tooltip("Gets a world direction Vector from 2 Input Axis. Typically used for a third person controller with Relative To set to the camera.")]
	public class GetEasyJoystickAxisVector3 : FsmStateAction
	{

		[RequiredField]
		[CheckForComponent(typeof(EasyJoystick))]
		[Tooltip("The GameObject with an EasyJoystick component.")]
		public FsmOwnerDefault gameObject;

		public enum AxisPlane
		{
			XZ,
			XY,
			YZ
		}
		
		[Tooltip("Input axis are reported in the range -1 to 1, this multiplier lets you set a new range.")]
		public FsmFloat multiplier;
		
		[RequiredField]
		[Tooltip("The world plane to map the 2d input onto.")]
		public AxisPlane mapToPlane;
		
		[Tooltip("Make the result relative to a GameObject, typically the main camera.")]
		public FsmGameObject relativeTo;
		
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the direction vector.")]
		public FsmVector3 storeVector;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the length of the direction vector.")]
		public FsmFloat storeMagnitude;
		public override void Reset()
		{
			multiplier = 1.0f;
			mapToPlane = AxisPlane.XZ;
			storeVector = null;
			storeMagnitude = null;
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
			DoGetEasyJoystickAxisVector(move);
		}

		void On_JoystickMoveEnd(MovingJoystick move)
		{
			storeVector.Value = new Vector3(0,0,0);
		}

		void DoGetEasyJoystickAxisVector(MovingJoystick move)
		{
			var forward = new Vector3();
			var right = new Vector3();
			
			if (relativeTo.Value == null)
			{
				switch (mapToPlane) 
				{
				case AxisPlane.XZ:
					forward = Vector3.forward;
					right = Vector3.right;
					break;
					
				case AxisPlane.XY:
					forward = Vector3.up;
					right = Vector3.right;
					break;
					
				case AxisPlane.YZ:
					forward = Vector3.up;
					right = Vector3.forward;
					break;
				}
			}
			else
			{
				var transform = relativeTo.Value.transform;
				
				switch (mapToPlane) 
				{
				case AxisPlane.XZ:
					forward = transform.TransformDirection(Vector3.forward);
					forward.y = 0;
					forward = forward.normalized;
					right = new Vector3(forward.z, 0, -forward.x);
					break;
					
				case AxisPlane.XY:
				case AxisPlane.YZ:
					// NOTE: in relative mode XY ans YZ are the same!
					forward = Vector3.up;
					forward.z = 0;
					forward = forward.normalized;
					right = transform.TransformDirection(Vector3.right);
					break;
				}
				
				// Right vector relative to the object
				// Always orthogonal to the forward vector
				
			}
			
			// get individual axis
			// leaving an axis blank or set to None sets it to 0
			
			var h =  move.joystickAxis.x;
			var v =  move.joystickAxis.y;
			
			// calculate resulting direction vector
			
			var direction = h * right + v * forward;
			direction *= multiplier.Value;
			
			storeVector.Value = direction;
			
			if (!storeMagnitude.IsNone)
			{
				storeMagnitude.Value = direction.magnitude;
			}

	}

		void OnExit(){
			EasyJoystick.On_JoystickMove -= On_JoystickMove;
			EasyJoystick.On_JoystickMoveEnd -= On_JoystickMoveEnd;
		}
}
}

