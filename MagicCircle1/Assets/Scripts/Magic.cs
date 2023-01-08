using System; //For Action
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour {
    public float coolTime;
    public float lastUseTime;

    public Action onUse;

    private void OnEnable() {
        lastUseTime = -coolTime;//0으로 할 시, 쿨타임만큼 기다린 후에야 첫 사용을 할 수 있다
    }

    public void TryToUse() {
        if (lastUseTime + coolTime <= Time.time){
            Use();
        }
    }

    private void Use() {
        onUse();
        lastUseTime = Time.time;
    }
}
