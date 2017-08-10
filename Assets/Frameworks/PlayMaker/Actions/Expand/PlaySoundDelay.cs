// Duke Chiang,E-mail:dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.Audio)]
	[Tooltip("Plays an Audio Clip at a position defined by a Game Object or Vector3. If a position is defined, it takes priority over the game object. This action doesn't require an Audio Source component, but offers less control than Audio actions.")]
	public class PlaySoundDelay : FsmStateAction
	{
		public FsmOwnerDefault gameObject;
		
		public FsmVector3 position;
		
		[RequiredField]
		[Title("Audio Clip")]
		[ObjectType(typeof(AudioClip))]
		public FsmObject clip;
		
		[HasFloatSlider(0, 1)]
		public FsmFloat volume = 1f;

		public FsmFloat delay;
		private float time;
		public override void Reset()
		{
			gameObject = null;
			position = new FsmVector3 { UseVariable = true };
			clip = null;
			volume = 1;
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
				DoPlaySound();
				Finish();
			}
		}
		
		
		void DoPlaySound()
		{
			var audioClip = clip.Value as AudioClip;
			
			if (audioClip == null)
			{
				LogWarning("Missing Audio Clip!");
				return;
			}
			
			if (!position.IsNone)
			{
				AudioSource.PlayClipAtPoint(audioClip, position.Value, volume.Value);
			}
			else
			{
				var go = Fsm.GetOwnerDefaultTarget(gameObject);
				if (go == null)
				{
					return;
				}
				AudioSource.PlayClipAtPoint(audioClip, go.transform.position, volume.Value);
			}
		}
		
		
	}
}