// Duke Chiang.Email：dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Raycast")]
	[Tooltip("Tests if a Raycast on a Game Object was hiting.")]
	public class RaycastIsHitFromPosition : FsmStateAction
	{
		[RequiredField]
		public FsmVector3 fromPosition;
		[RequiredField]
		public FsmGameObject toGameObject;
		public FsmVector3 toGameObjectOffset;
		[Tooltip("Event to send if hiting the go.")]
		public FsmEvent trueEvent;
		
		[Tooltip("Event to send if not hiting the go.")]
		public FsmEvent falseEvent;
		
		[Tooltip("Sore the result in a bool variable.")]
		[UIHint(UIHint.Variable)]
		public FsmBool storeResult;
		
		[Tooltip("Repeat every frame while the state is active.")]
		public bool everyFrame;

		[UIHint(UIHint.Layer)]
		[Tooltip("Pick only from these layers.")]
		public FsmInt[] layerMask;
		
		[Tooltip("Invert the mask, so you pick from all layers except those defined above.")]
		public FsmBool invertMask;

		public bool isDebugDrawLine;
		
		public override void Reset()
		{			toGameObjectOffset = new FsmVector3();
			toGameObjectOffset.Value = new Vector3(0,0,0);
			fromPosition = null;
			toGameObject = null;
			trueEvent = null;
			falseEvent = null;
			storeResult = null;
			everyFrame = false;
			layerMask = new FsmInt[0];
			invertMask = false;
			isDebugDrawLine = false;
		}
		
		public override void OnEnter()
		{
			DoRaycastIsHitFromPosition();
			
			if (!everyFrame)
			{
				Finish();
			}
		}
		
		public override void OnUpdate()
		{
			DoRaycastIsHitFromPosition();
		}
		
		void DoRaycastIsHitFromPosition()
		{
			if (fromPosition == null || toGameObject == null)
			{
				return;
			}
			
			RaycastHit hit;
			var isHit = false;
			Vector3 relativePosition = toGameObjectOffset.Value + toGameObject.Value.transform.position - fromPosition.Value;
			if(Physics.Raycast(fromPosition.Value,relativePosition,out hit,2*relativePosition.magnitude,ActionHelpers.LayerArrayToLayerMask(layerMask, invertMask.Value))){
				if(hit.transform == toGameObject.Value.transform){
					isHit = true;
				}
			}
			
			if(isDebugDrawLine){
				Debug.DrawLine(fromPosition.Value, toGameObjectOffset.Value + toGameObject.Value.transform.position);
			}
			
			if(storeResult != null){
				storeResult.Value = isHit;
			}
			
			Fsm.Event(isHit ? trueEvent : falseEvent);
		}
	}
}
