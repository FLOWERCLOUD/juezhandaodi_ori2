using UnityEngine;
using System.Collections;

public class RoleProfile{
	//角色名
	private string role;
	public string Role
	{
		get { return role; }
		set { role = value; }
	}
	//职业ID
	private int roleCateId;
	public int RoleCateId
	{
		get { return roleCateId; }
		set { roleCateId = value; }
	}
	//HP
	private int hp;
	public int HP
	{
		get { return hp; }
		set { hp = value; }
	}
	//攻击力
	private int attack;
	public int Attack
	{
		get { return attack; }
		set { attack = value; }
	}
	//防御
	private int defense;
	public int Defense
	{
		get { return defense; }
		set { defense = value; }
	}
	//暴击
	private int crit;
	public int Crit
	{
		get { return crit; }
		set { crit = value; }
	}
	//韧性
	private int toughness;
	public int Toughness
	{
		get { return toughness; }
		set { toughness = value; }
	}
	//破甲
	private int sunderArmor;
	public int SunderArmor
	{
		get { return sunderArmor; }
		set { sunderArmor = value; }
	}
	//格挡
	private int parry;
	public int Parry
	{
		get { return parry; }
		set { parry = value; }
	}
	
	public RoleProfile(string role,int roleCateId,int hp,int attack,int defense,int crit,int toughness,int sunderArmor,int parry)
	{
		this.Role = role;
		this.RoleCateId = roleCateId;
		this.HP = hp;
		
		this.Attack =attack;
		this.Defense = defense;
		
		this.Crit = crit;
		this.Toughness = toughness;
		
		this.SunderArmor = sunderArmor;
		this.Parry = parry;
	}
}