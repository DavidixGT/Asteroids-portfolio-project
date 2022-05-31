using UnityEngine;

namespace Asteroids.UI.MainMenu
{
    public class QuitButton : UIButton
    {
        protected override void Interact()
        {
            Application.Quit();
        }
    }
}