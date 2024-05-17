using UnityEngine;

namespace SpaceInvaders.UI.UI
{
    public class UIViewRoot : MonoBehaviour
    {
        [SerializeField] private Transform _uiViewsParent;

        public Transform UIViewsParent => _uiViewsParent;
    }
}