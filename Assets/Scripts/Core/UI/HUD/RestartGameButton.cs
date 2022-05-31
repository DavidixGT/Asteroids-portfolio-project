using UnityEngine;
using UnityEngine.SceneManagement;

namespace Asteroids.UI.HUD
{
    public class RestartGameButton : UIButton
    {
        protected override void Interact()
        {
            Debug.Log("what");
            SceneManager.LoadScene("Game", LoadSceneMode.Single);
        }
    }
}