using System; //For Action
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magic : MonoBehaviour {
    public float coolTime;
    public float lastUseTime;

    public Action onUse;

    private void OnEnable() {
        lastUseTime = -coolTime;//0���� �� ��, ��Ÿ�Ӹ�ŭ ��ٸ� �Ŀ��� ù ����� �� �� �ִ�
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
