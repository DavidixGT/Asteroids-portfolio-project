using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids.UI.MainMenu
{
    public class QuickGameButton : UIButton
    {
        protected override void Interact()
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }
}

