using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids.UI.HUD
{
    public class RestartGameButton : UIButton
    {
        protected override void Interact()
        {
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }
}