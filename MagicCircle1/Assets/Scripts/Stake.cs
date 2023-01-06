using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stake : MonoBehaviour
{
    public int state; // 0 = ���� / 1 = ���� / 2 = ���������� Ȱ��ȭ��

    public void TurnOn() {
        state = 1;

        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = Color.grey;
    }

    public void TurnOff() {
        state = 0;

        SpriteRenderer sprite = gameObject.GetComponent<SpriteRenderer>();
        sprite.color = Color.white;
    }
}
