using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class SceneChangeButton : MonoBehaviour
{
    public enum SceneName
    {
        SampleScene,
        FamilyHouse,
        River,
        Dock,
        VillageSquare,
        FarmHouse,
        Tree,
        ClanLeaderHouse
    }

    [SerializeField] private Button button;
    [SerializeField] private SceneName scene;

    private void Awake()
    {
        button.onClick.AddListener(LoadScene);
    }

    private void LoadScene()
    {
        // Convert enum to string and load scene
        SceneManager.LoadScene(scene.ToString());
    }
}
