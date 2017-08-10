// Duke Chiang.Email：dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Raycast")]
	[Tooltip("Tests if a Raycast on a Game Object was hiting.")]
	public class RaycastIsHit : FsmStateAction
	{
		[RequiredField]
		public FsmOwnerDefault fromGameObject;
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

		public bool isDebugDrawLine;

		public override void Reset()
		{
			toGameObjectOffset = new FsmVector3();
			toGameObjectOffset.Value = new Vector3(0,0,0);
			fromGameObject = null;
			toGameObject = null;
			trueEvent = null;
			falseEvent = null;
			storeResult = null;
			everyFrame = false;
			isDebugDrawLine = false;
		}
		
		public override void OnEnter()
		{
			DoRaycastIsHit();
			
			if (!everyFrame)
			{
				Finish();
			}
		}
		
		public override void OnUpdate()
		{
			DoRaycastIsHit();
		}
		
		void DoRaycastIsHit()
		{
			var fromGo = Fsm.GetOwnerDefaultTarget(fromGameObject);
			if (fromGo == null || toGameObject == null)
			{
				return;
			}

			RaycastHit hit;
			var isHit = false;
			Vector3 relativePosition = toGameObjectOffset.Value + toGameObject.Value.transform.position - fromGo.transform.position;
			if(Physics.Raycast(fromGo.transform.position,relativePosition,out hit,2*relativePosition.magnitude)){
				if(hit.transform == toGameObject.Value.transform){
					isHit = true;
				}
			}

			
			
			if(isDebugDrawLine){
				Debug.DrawLine(fromGo.transform.position,toGameObjectOffset.Value + toGameObject.Value.transform.position);
			}

			if(storeResult != null){
				storeResult.Value = isHit;
			}
			
			Fsm.Event(isHit ? trueEvent : falseEvent);
		}
	}
}
