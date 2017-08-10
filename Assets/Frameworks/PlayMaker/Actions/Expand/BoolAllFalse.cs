// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Logic)]
	[Tooltip("Tests if all the given Bool Variables are False.")]
	public class BoolAllFalse : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("The Bool variables to check.")]
		public FsmBool[] boolVariables;
		
		[Tooltip("Event to send if all the Bool variables are False.")]
		public FsmEvent sendEvent;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Store the result in a Bool variable.")]
		public FsmBool storeResult;
		
		[Tooltip("Repeat every frame while the state is active.")]
		public bool everyFrame;
		
		public override void Reset()
		{
			boolVariables = null;
			sendEvent = null;
			storeResult = null;
			everyFrame = false;
		}
		
		public override void OnEnter()
		{
			DoIt();
			
			if (!everyFrame)
			{
				Finish();
			}		
		}
		
		public override void OnUpdate()
		{
			DoIt();
		}
		
		void DoIt()
		{
			if (boolVariables.Length == 0) return;
			
			var allFalse = true;
			
			for (var i = 0; i < boolVariables.Length; i++) 
			{
				if (boolVariables[i].Value)
				{
					allFalse = false;
					break;
				}
			}
			
			if (allFalse)
			{
				Fsm.Event(sendEvent);
			}
			
			storeResult.Value = allFalse;
		}
	}
}