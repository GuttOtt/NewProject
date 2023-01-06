using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stake : MonoBehaviour
{
    public int state; // 0 = ²¨Áü / 1 = ÄÑÁü / 2 = ¸¶¹ýÁøÀ¸·Î È°¼ºÈ­µÊ

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
