using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GamePanelManager : MonoBehaviour
{
    public void EndGamePressed()
    {
        if (SceneManagement.Instance != null)
        {
            SceneManagement.Instance.EndGame();
        }
    }
}
