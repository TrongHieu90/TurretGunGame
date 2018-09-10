using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IDamageable<T> {

    void DamageTaken(T dmgTaken);
}
