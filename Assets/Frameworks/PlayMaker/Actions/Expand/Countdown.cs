// Duke Chiang.Email：dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Time)]
	[Tooltip("Delays a State from finishing by the specified time. NOTE: Other actions continue, but FINISHED can't happen before Time.")]
	public class Countdown : FsmStateAction
	{
		[RequiredField]
		public FsmFloat time;
		public FsmEvent finishEvent;
		[UIHint(UIHint.Variable)]
		public FsmFloat currentTime;
		[UIHint(UIHint.Variable)]
		public FsmFloat currentTimePercent;
		public bool realTime;
		
		private float startTime;
		private float timer;
		
		public override void Reset()
		{
			time = 1f;
			finishEvent = null;
			realTime = false;
		}
		
		public override void OnEnter()
		{
			if (time.Value <= 0)
			{
				Fsm.Event(finishEvent);
				Finish();
				return;
			}
			
			startTime = FsmTime.RealtimeSinceStartup;
			timer = 0f;
		}
		
		public override void OnUpdate()
		{
			
			if (realTime)
			{
				timer = FsmTime.RealtimeSinceStartup - startTime;
			}
			else
			{
				timer += Time.deltaTime;
			}
			
			if(currentTime != null)
			{
				currentTime.Value = time.Value - timer;
			}
			
			if(currentTimePercent != null)
			{
				currentTimePercent.Value = (time.Value - timer)/time.Value;
			}

			if (timer >= time.Value)
			{
				Finish();
				if (finishEvent != null)
				{
					Fsm.Event(finishEvent);
				}
			}
		}
		
	}
}
