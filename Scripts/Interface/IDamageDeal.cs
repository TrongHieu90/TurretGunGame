using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageDeal<T>
{
    T DealDamage(T dmgAmount);	
	
}
