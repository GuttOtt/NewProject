using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface�� ����Ƽ���� Instantiate �� �� ���� ������, ��ü���� Ŭ������ ����
//���� ������ �ߵ� ȿ���� IWeaponEffect�� ����

public class MagicWeapon : MonoBehaviour {
    //GunType, HitScan �� IWeaponEffect�� ��ü Ŭ������ Start()���� �߰�
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
        //Sprite ���� ó��
    }

    public void Deselect() {
        ifSelected = false;
        //Sprite ���� ó��
    }

    public void AssignUI(WeaponUI ui) {
        _weaponUI = ui;
    }
}
