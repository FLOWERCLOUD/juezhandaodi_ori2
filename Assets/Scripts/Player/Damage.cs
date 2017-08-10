using UnityEngine;
using System.Collections;

public class Damage{
	private int _damage;
	public int _Damage
	{
		get { return _damage; }
	}

	private bool isCrit;
	public bool IsCrit
	{
		get { return isCrit; }
	}

	private bool isSunderArmor;
	public bool IsSunderArmor
	{
		get { return isSunderArmor; }
	}

	public Damage(int _damage,bool isCrit,bool isSunderArmor)
	{
		this._damage = _damage;
		this.isCrit = isCrit;
		this.isSunderArmor = isSunderArmor;
	}
}
