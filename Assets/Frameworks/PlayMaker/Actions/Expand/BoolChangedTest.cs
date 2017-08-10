// (c) Copyright HutongGames, LLC 2010-2013. All rights reserved.

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Logic)]
	public class BoolChangedTest : FsmStateAction
	{
		[RequiredField]
		[UIHint(UIHint.Variable)]
		[Tooltip("The Bool variable to watch for changes.")]
		public FsmBool boolVariable;
		
		[Tooltip("Event to send if the variable changes.")]
		public FsmEvent changedEvent;

		public FsmEvent trueEvent;

		public FsmEvent falseEvent;
		
		[UIHint(UIHint.Variable)]
		[Tooltip("Set to True if changed.")]
		public FsmBool storeResult;
		
		bool previousValue;
		
		public override void Reset()
		{
			boolVariable = null;
			changedEvent = null;
			trueEvent = null;
			falseEvent = null;
			storeResult = null;
		}
		
		public override void OnEnter()
		{
			if (boolVariable.IsNone)
			{
				Finish();
				return;
			}
			
			previousValue = boolVariable.Value;
		}
		
		public override void OnUpdate()
		{
			bool currentBool = boolVariable.Value;
			storeResult.Value = false;
			
			if (currentBool != previousValue)
			{
				storeResult.Value = true;
				Fsm.Event(changedEvent);
				Fsm.Event(currentBool ? trueEvent : falseEvent);
			}
		}
	}
}

