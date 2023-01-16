using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : Singleton<GameManager> {
    public bool isGameOver = false;
    public bool isUIOn = true;

    void Update() {
        if (Input.GetKeyDown(KeyCode.M)) {
            ControlMDUI();
        }
    }

    private void ControlMDUI() {
        if (MapUIManager.Instance.gameObject.activeSelf) {
            MapUIManager.Instance.gameObject.SetActive(false);
            isUIOn = false;
        }
        else {
            MapUIManager.Instance.gameObject.SetActive(true);
            MapUIManager.Instance.Centering();
            isUIOn = true;
        }

        
        /*
        if (DesignUIManager.Instance.gameObject.activeSelf) {
            DesignUIManager.Instance.gameObject.SetActive(false);
        }
        else {
            DesignUIManager.Instance.gameObject.SetActive(true);
        }
        */
    }

    public void MoveToSpace(Space space) {
        StartCoroutine(LoadSceneCoroutine(space));
    }

    private IEnumerator LoadSceneCoroutine(Space space) {
        AsyncOperation asyncLoad = SceneManager.LoadSceneAsync("SampleScene");

        while (!asyncLoad.isDone) {
            yield return null;
        }

        MapManager.Instance.MoveToSpace(space);
    }

    /*
    public bool isGameOver;
    public List<Magic> ownedMagic = new List<Magic>();

    public Action onLoadNewScene;

    protected override void Awake() {
        base.Awake();
        ownedMagic.Add(Resources.Load<Magic>("BasicMagic"));
    }
    
    public void LoadNewScene() {
        SceneManager.LoadScene("SampleScene");
        onLoadNewScene();
    }
    */
}