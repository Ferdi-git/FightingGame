using System;
using UnityEngine;

[CreateAssetMenu(fileName = "CharaSOEvent", menuName = "ScriptableObjects/CharaSOEvent", order = 1)]
public class SOEventChara : ScriptableObject 
{
    public event Action<float> GetHit;
    public event Action<float> GetHealed;

    public void GetHitInvoke(float value) => GetHit?.Invoke(value);
    public void GetHealedInvoke(float value) => GetHealed?.Invoke(value);



}
