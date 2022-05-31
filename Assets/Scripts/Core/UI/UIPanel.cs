using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Asteroids.UI
{
    public class UIPanel : MonoBehaviour
    {
        public void Show()
        {
            gameObject.SetActive(true);
        }
        public void Hide()
        {
            gameObject.SetActive(false);
        }
    }
}