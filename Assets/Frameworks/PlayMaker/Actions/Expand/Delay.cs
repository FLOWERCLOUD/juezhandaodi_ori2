// Duke Chiang,E-mail:dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Time")]
	public class Delay : FsmStateAction
	{
		public FsmFloat delay;
		private float time;
		public override void Reset()
		{
			delay = 0f;
		}
		
		public override void OnEnter()
		{
			time = Time.time;
		}
		
		
		public override void OnUpdate()
		{
			if(Time.time > time + delay.Value)
			{
				Finish();
			}
		}
	}
}