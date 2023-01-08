using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {
    public bool isGameOver;
    public List<Magic> ownedMagic = new List<Magic>();

    public Action onLoadNewScene;

    protected override void Awake() {
        base.Awake();
        ownedMagic.Add(Resources.Load<Magic>("BasicMagic"));
    }

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            ControlMDUI();
        }
    }
    
    private void ControlMDUI() {
        if (MapUIManager.Instance.gameObject.activeSelf) {
            MapUIManager.Instance.gameObject.SetActive(false);
        }
        else {
            MapUIManager.Instance.gameObject.SetActive(true);
        }

        
        if (DesignUIManager.Instance.gameObject.activeSelf) {
            DesignUIManager.Instance.gameObject.SetActive(false);
        }
        else {
            DesignUIManager.Instance.gameObject.SetActive(true);
        }
    }
    
    public void LoadNewScene() {
        SceneManager.LoadScene("SampleScene");
        onLoadNewScene();
    }
}
