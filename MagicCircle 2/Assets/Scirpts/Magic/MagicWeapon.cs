using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Interface�� ����Ƽ���� Instantiate �� �� ���� ������, ��ü���� Ŭ������ ����
//���� ������ �ߵ� ȿ���� IWeaponEffect�� ����

public class MagicWeapon : MonoBehaviour {
    //GunType, HitScan �� IWeaponEffect�� ��ü Ŭ������ Start()���� �߰�
    public MagicData data;
    public Status status;
    public Sprite uiImage;

    private WeaponUI _weaponUI;
    private bool ifSelected;

    private void Awake() {
        status = new Status(data.basePower, data.baseSpeed, data.baseSize);
    }

    private void Update() {
        if (Input.GetKeyDown(KeyCode.T))
            DrawStatus();
    }

    public WeaponUI weaponUI {
        get => _weaponUI;
    }

    public void Decorate(Status status) {
        this.status.Plus(status);
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

    public void DrawStatus() {
        Debug.Log(status.StatusText());
    }
}
