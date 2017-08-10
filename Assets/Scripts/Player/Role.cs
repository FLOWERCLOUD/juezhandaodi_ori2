using UnityEngine;
using System.Collections;

public class Role : MonoBehaviour {
	private RoleProfile roleProfile;
	private int hp;
	private bool isDead = false;
	public string uiSpritePathName;
	void Awake() {
		roleProfile = new RoleProfile("风云丶一笑",0,15000000,120000,70000,30000,25000,45000,40000);
		hp = roleProfile.HP;
	}
	void SetHPPercentToSprite()
	{
		if(uiSpritePathName == null)
		{
			Debug.LogError("uiSpritePathName不能为空");
			return;
		}

		GameObject go = GameObject.Find(uiSpritePathName);
		if(go == null)
		{
			Debug.LogError(uiSpritePathName+"不存在");
			return;
		}

		UISprite sprite = go.GetComponent<UISprite>();
		if(sprite == null)
		{
			Debug.LogError(uiSpritePathName+"不存在UISprite组件");
			return;
		}
		sprite.fillAmount = GetHPPercent();
	}
	public Damage Damage(RoleProfile enemyRole)
	{
		int damage = 0;
		bool _isCrit = false;
		bool _isSunderArmor = false;

		int sunderArmorPer = (enemyRole.SunderArmor - roleProfile.Parry)/100;
		int critPer = (enemyRole.Crit - roleProfile.Toughness)/100;

		if(sunderArmorPer >= Random.value*100)
		{
			_isCrit = true;
			damage += (roleProfile.Attack - roleProfile.Defense/2);
		}
		else
		{
			damage += (roleProfile.Attack - roleProfile.Defense);
		}

		if(critPer >= Random.value*100)
		{
			_isSunderArmor = true;
			damage *= 2;
		}
		hp -= damage;
		if(hp <= 0)
		{
			hp = 0;
			isDead = true;
		}
		SetHPPercentToSprite();
		return new Damage(-1*damage,_isCrit,_isSunderArmor);
	}

	public int Health()
	{
		int preHP = hp;
		if(isDead == true)
		{
			return 0;
		}
		hp += (int)(roleProfile.HP * 0.2f);
		if(hp > roleProfile.HP)
		{
			hp = roleProfile.HP;
		}
		SetHPPercentToSprite();
		return hp - preHP;
	}

	public int GetCurrentHP()
	{
		return hp;
	}

	public RoleProfile GetRoleProfile()
	{
		return roleProfile;
	}

	public bool IsDead()
	{
		return isDead;
	}

	public float GetHPPercent()
	{
		return ((float)hp) / ((float)roleProfile.HP);
	}

	public void Reset()
	{
		hp = roleProfile.HP;
		isDead = false;
		SetHPPercentToSprite();
	}
}
