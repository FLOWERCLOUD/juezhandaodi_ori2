// Duke Chiang.Email：dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("NGUI")]
	public class NGUIEventListener : FsmStateAction
	{
		[RequiredField]
		[Tooltip("控件名称。如：UI/NGUIRoot/AttackPanel/AttackButton")]
		public FsmString gameObjectPathName;
		
		public FsmEvent submitEvent;
		
		public FsmEvent clickEvent;

		public FsmEvent doubleClickEvent;
		
		public FsmEvent hoverIsFalseEvent;

		public FsmEvent hoverIsTrueEvent;
		
		public FsmEvent pressIsFalseEvent;

		public FsmEvent pressIsTrueEvent;
		
		public FsmEvent selectIsFalseEvent;
		
		public FsmEvent selectIsTrueEvent;
		
		public FsmEvent scrollEvent;
		
		public FsmEvent dragEvent;
		public FsmEvent dragOverEvent;
		public FsmEvent dragOutEvent;

		public FsmEvent dropEvent;
		
		public FsmEvent keyEvent;

		[UIHint(UIHint.Variable)]
		public FsmFloat storeScrollResult;

		[UIHint(UIHint.Variable)]
		public FsmVector2 storeDragResult;

		[UIHint(UIHint.Variable)]
		public FsmGameObject storeDropResult;


		[UIHint(UIHint.Variable)]
		public FsmBool storeHoverResult;
		
		[UIHint(UIHint.Variable)]
		public FsmBool storePressResult;
		
		[UIHint(UIHint.Variable)]
		public FsmBool storeSelectResult;
		
		public override void Reset()
		{
			gameObjectPathName = null;
			submitEvent = null;

			clickEvent = null;

			doubleClickEvent = null;

			hoverIsFalseEvent = null;

			hoverIsTrueEvent = null;

			pressIsFalseEvent = null;

			pressIsTrueEvent = null;

			selectIsFalseEvent = null;

			selectIsTrueEvent = null;

			scrollEvent = null;

			dragEvent = null;
			dragOverEvent = null;
			dragOutEvent = null;

			dropEvent = null;

			keyEvent = null;

			storeScrollResult = null;

			storeDragResult = null;

			storeDropResult = null;

			storeHoverResult = null;
			
			storePressResult = null;
			
			storeSelectResult = null;
		}
		
		public override void OnEnter()
		{
			if(gameObjectPathName.IsNone || gameObjectPathName == null || gameObjectPathName.Value == ""|| gameObjectPathName.Value == null)
			{
				Debug.Log("需要指定控件路径名称，否则无法获取控件");
				Finish();
			}

			GameObject go = GameObject.Find(gameObjectPathName.Value);
			if(go == null)
			{
				Debug.Log("您所指定控件的路径名称，不存在");
				Finish();
			}
			UIEventListener.Get(go).onClick = OnClick;
			UIEventListener.Get(go).onSubmit = OnSubmit;
			UIEventListener.Get(go).onDoubleClick = OnDoubleClick;
			UIEventListener.Get(go).onHover = OnHover;
			UIEventListener.Get(go).onPress = OnPress ;
			UIEventListener.Get(go).onSelect = OnSelect;
			UIEventListener.Get(go).onScroll = OnScroll;
			UIEventListener.Get(go).onDrag = OnDrag;
			UIEventListener.Get(go).onDragOver = OnDragOver;
			UIEventListener.Get(go).onDragOut = OnDragOut;
			UIEventListener.Get(go).onDrop = OnDrop;
			UIEventListener.Get(go).onKey = OnKey;

		}

		void OnSubmit (GameObject go)				{ Fsm.Event(submitEvent); }
		void OnClick (GameObject go)					{ Fsm.Event(clickEvent); }
		void OnDoubleClick (GameObject go)			{ Fsm.Event(doubleClickEvent); }
		void OnHover (GameObject go,bool isOver)
		{
			if(storeHoverResult != null)
			{
				storeHoverResult.Value = isOver;
			}

			Fsm.Event(isOver ? hoverIsTrueEvent : hoverIsFalseEvent); 
		}
		void OnPress (GameObject go,bool isPressed)	
		{ 
			if(storePressResult != null)
			{
				storePressResult.Value = isPressed;
			}

			Fsm.Event(isPressed ? pressIsTrueEvent : pressIsFalseEvent); 
		}
		void OnSelect (GameObject go,bool selected)	{
			if(storeSelectResult != null)
			{
				storeSelectResult.Value = selected;
			}

			Fsm.Event(selected ? selectIsTrueEvent : selectIsFalseEvent); 
		}
		void OnScroll (GameObject go,float delta)
		{ 
			if(storeScrollResult != null)
			{
				storeScrollResult.Value = delta;
			}
			
			Fsm.Event(scrollEvent);
		}
		void OnDrag (GameObject go,Vector2 delta)
		{ 
			if(storeDragResult != null)
			{
				storeDragResult.Value = delta;
			}
			
			Fsm.Event(dragEvent);
		}
		void OnDragOver (GameObject go)				{ Fsm.Event(dragOverEvent); }
		void OnDragOut (GameObject go)				{ Fsm.Event(dragOutEvent); }
		void OnDrop (GameObject go,GameObject dropGO)
		{ 
			if(storeDropResult != null)
			{
				storeDropResult.Value = dropGO;
			}

			Fsm.Event(dropEvent);
		}
		void OnKey (GameObject go,KeyCode key)
		{
			Fsm.Event(keyEvent);
		}
	}
}
