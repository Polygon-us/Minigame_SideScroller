using ScriptableObjects.Messages;
using UnityEngine;
using UI.Gameplay;

namespace Gameplay.Trigger
{
    public class BulletinBoard : Trigger
    {
        [SerializeField] private MessageMenu messageMenu;
        [SerializeField] private MessageInfoSO messageInfo;

        private void OnEnable()
        {
            TriggerEnter.AddListener(ShowMessage);
        }

        private void OnDisable()
        {
            TriggerEnter.RemoveListener(ShowMessage);
        }
        
        private void ShowMessage()
        {
            messageMenu.Show(messageInfo);
        }
    }
}