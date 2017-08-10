// Duke Chiang.Email:dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Vector3)]
	[Tooltip("Sends Events based on the comparison of 2 Vector3.")]
	public class Vector3Compare : FsmStateAction
	{
		[RequiredField]
		[Tooltip("The first Vector3 variable.")]
		public FsmVector3 vector1;
		
		[RequiredField]
		[Tooltip("The second Vector3 variable.")]
		public FsmVector3 vector2;
		
		[RequiredField]
		[Tooltip("Tolerance for the Equal test (almost equal).")]
		public FsmVector3 tolerance;
		
		[Tooltip("Event sent if Vector3 1 equals Vector3 2 (within Tolerance)")]
		public FsmEvent equal;
		
		[Tooltip("Event sent if Vector3 1 doesn't equal Vector3 2 (within Tolerance)")]
		public FsmEvent notEqual;
		
		[Tooltip("Repeat every frame. Useful if the variables are changing and you're waiting for a particular result.")]
		public bool everyFrame;
		
		public override void Reset()
		{
			vector1 = new FsmVector3{UseVariable = true};
			vector2 = new FsmVector3{UseVariable = true};
			tolerance = new FsmVector3{UseVariable = true};
			equal = null;
			notEqual = null;
			everyFrame = false;
		}
		
		public override void OnEnter()
		{
			DoCompare();
			
			if (!everyFrame)
			{
				Finish();
			}
		}
		
		public override void OnUpdate()
		{
			DoCompare();
		}
		
		void DoCompare()
		{
			
			if (Mathf.Abs(vector1.Value.x - vector2.Value.x) <= tolerance.Value.x && Mathf.Abs(vector1.Value.y - vector2.Value.y) <= tolerance.Value.y && Mathf.Abs(vector1.Value.z - vector2.Value.z) <= tolerance.Value.z)
			{
				Fsm.Event(equal);
			}else{
				Fsm.Event(notEqual);
			}
			
		}
		
		public override string ErrorCheck()
		{
			if (FsmEvent.IsNullOrEmpty(equal) &&
			    FsmEvent.IsNullOrEmpty(notEqual))
				return "Action sends no events!";
			return "";
		}
	}
}