// Duke Chiang .Email:dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Vector2)]
	[Tooltip("Get the XY channels of a Vector2 Variable and storew them in Float Variables.")]
	public class GetVector2XY : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmVector2 vector2Variable;
		[UIHint(UIHint.Variable)]
		public FsmFloat storeX;		
		[UIHint(UIHint.Variable)]
		public FsmFloat storeY;
		public bool everyFrame;
		
		public override void Reset()
		{
			vector2Variable = null;
			storeX = null;
			storeY = null;
			everyFrame = false;
		}

		public override void OnEnter()
		{
			DoGetVector2XY();
			
			if(!everyFrame)
				Finish();
		}
		
		public override void OnUpdate ()
		{
			DoGetVector2XY();
		}
		
		void DoGetVector2XY()
		{
			if (vector2Variable == null) return;
			
			if (storeX != null)
				storeX.Value = vector2Variable.Value.x;

			if (storeY != null)
				storeY.Value = vector2Variable.Value.y;
		}
	}
}