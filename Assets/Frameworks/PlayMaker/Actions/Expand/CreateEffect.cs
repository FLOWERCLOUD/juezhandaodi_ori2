// Duke Chiang ,E-mail dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory(ActionCategory.GameObject)]
	[Tooltip("Creates a Game Effect, usually from a Prefab.")]
	public class CreateEffect : FsmStateAction
	{
		[RequiredField]
		[Tooltip("GameObject to create. Usually a Prefab.")]
		public FsmGameObject effectPrefab;
		
		[Tooltip("Optional Spawn Point.")]
		public FsmGameObject effectPlayer;

		public FsmFloat distance;
		
		public override void Reset()
		{
			effectPrefab = null;
			effectPlayer = null;
			distance = 1;
		}
		
		public override void OnEnter()
		{
			Vector3 effectPos =  effectPlayer.Value.transform.TransformPoint( effectPlayer.Value.transform.localPosition + new Vector3(0,0,distance.Value)); 
			Object.Instantiate ( effectPrefab.Value, effectPos, Quaternion.identity);
			Finish();
		}
		
	}
}