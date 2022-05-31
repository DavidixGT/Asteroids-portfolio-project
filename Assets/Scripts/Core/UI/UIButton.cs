using UnityEngine;
using UnityEngine.UI;

namespace Asteroids.UI
{
    [RequireComponent(typeof(Button))]
    public abstract class UIButton : MonoBehaviour
    {
        private Button _button;
        private void OnEnable()
        {
            _button = GetComponent<Button>();
            _button.onClick.AddListener(Interact);
        }
        private void OnDisable()
        {
            _button.onClick.RemoveListener(Interact);
        }
        protected abstract void Interact();
    }
}