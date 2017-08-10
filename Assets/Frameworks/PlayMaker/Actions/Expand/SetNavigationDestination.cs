// Duke Chiang .Email:dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Navigation")]
	[Tooltip("Sets the value of a Game Object Variable.")]
	public class SetNavigationDestination : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(UnityEngine.AI.NavMeshAgent))]
		public FsmGameObject gameObject;
		public FsmGameObject destination;
		public bool everyFrame;
		private UnityEngine.AI.NavMeshAgent agent;
		
		public override void Reset()
		{
			destination = null;
			gameObject = null;
			everyFrame = false;
		}
		
		public override void OnEnter()
		{
			agent = gameObject.Value.GetComponent<UnityEngine.AI.NavMeshAgent>();
			agent.SetDestination(destination.Value.transform.position);
			
			if (!everyFrame)
			{
				Finish();		
			}
		}
		
		public override void OnUpdate()
		{
			agent.destination = destination.Value.transform.position;
		}
	}
}