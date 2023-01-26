using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface는 유니티에서 Instantiate 할 수 없기 때문에, 구체적인 클래스로 생성
//마법 무기의 발동 효과는 IWeaponEffect로 구분

public class MagicWeapon : MonoBehaviour {
    //GunType, HitScan 등 IWeaponEffect의 구체 클래스의 Start()에서 추가
    public MagicData data;
    public IMagicStatus status;
    public Sprite uiImage;
    
    private WeaponUI _weaponUI;
    private bool ifSelected;

    public WeaponUI weaponUI {
        get => _weaponUI;
    }

    public void Decorate(IMagicStatus stauts) {

    }

    public void Select() {
        ifSelected = true;
        //Sprite 관련 처리
    }

    public void Deselect() {
        ifSelected = false;
        //Sprite 관련 처리
    }

    public void AssignUI(WeaponUI ui) {
        _weaponUI = ui;
    }
}
