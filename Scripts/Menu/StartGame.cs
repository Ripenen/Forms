using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class StartGame : MonoBehaviour
{
    public Image Panel;
    private int _iter;
    public void LoadGame()
    {
        InvokeRepeating(nameof(CountColor), 0, 0.05f);
    }

    private void CountColor()
    {
        Panel.color = new Color(0, 0, 0, Panel.color.a + 0.1f);
        _iter++;
        if(_iter == 10)
        {
            SceneManager.LoadScene(1);
            CancelInvoke();
        }
    }
}
