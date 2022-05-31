using UnityEngine.SceneManagement;

namespace Asteroids.UI.HUD
{
    public class LeaveGameSessionButton : UIButton
    {
        protected override void Interact()
        {
            SceneManager.LoadScene("MainMenu", LoadSceneMode.Single);
        }
    }
}