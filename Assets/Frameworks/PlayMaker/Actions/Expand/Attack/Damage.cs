// Duke Chiang ,E-mail dukechiang@qq.com

using UnityEngine;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Attack")]
	public class Damage : FsmStateAction
	{
		[RequiredField]
		public FsmString sendDamageTag;
		[RequiredField]
		public FsmString receiveDamageTag;

		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmInt storeDamage;

		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmBool storeIsCrit;

		[RequiredField]
		[UIHint(UIHint.Variable)]
		public FsmBool storeIsSunderArmor;

		public override void Reset()
		{
			sendDamageTag = null;
			receiveDamageTag = null;
		}
		
		public override void OnEnter()
		{
			GameObject sendDamageGo = GameObject.FindGameObjectWithTag(sendDamageTag.Value);
			if(sendDamageGo == null)
			{
				Finish();
				return;
			}
			GameObject receiveDamageGo = GameObject.FindGameObjectWithTag(receiveDamageTag.Value);
			if(receiveDamageGo == null)
			{
				Finish();
				return;
			}
			Role roleSendDamage = sendDamageGo.GetComponent<Role>();
			Role roleReceiveDamage = receiveDamageGo.GetComponent<Role>();
			if(roleSendDamage == null || roleReceiveDamage == null)
			{
				Finish();
				return;
			}
			global::Damage damage = roleReceiveDamage.Damage(roleSendDamage.GetRoleProfile());
			if(storeDamage != null){
				storeDamage.Value = damage._Damage;
			}

			if(storeIsCrit != null){
				storeIsCrit.Value = damage.IsCrit;
			}

			if(storeIsSunderArmor != null){
				storeIsSunderArmor.Value = damage.IsSunderArmor;
			}
			Finish();
		}
		
	}
}