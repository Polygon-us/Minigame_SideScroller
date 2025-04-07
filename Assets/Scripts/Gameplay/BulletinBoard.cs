using ScriptableObjects.Messages;
using UnityEngine;
using UI.Gameplay;
using Utils;

namespace Gameplay
{
    public class BulletinBoard : Triggerer
    {
        [SerializeField] private MessageMenu messageMenu;
        [SerializeField] private MessageInfoSO messageInfo;
        
        protected override void OnTriggerEnter2D(Collider2D other)
        {
            if (other.CompareTag(TagsTypes.PlayerTag))
                messageMenu.Show(messageInfo);
        }
    }
}