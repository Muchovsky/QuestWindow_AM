using Binding;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using ViewModel;

namespace Binders
{
    internal sealed class QuestViewModelBinder : Binder
    {
        [SerializeField] private TextMeshProUGUI m_desciptionLabel;

        [SerializeField] Button m_button;
        [SerializeField] Image m_checkmark;
        [SerializeField] Animator m_animator;

        protected override void RefreshBindings()
        {
            var questViewModel = Bindable as QuestViewModel;

            if (questViewModel == null)
                return;

            if (m_desciptionLabel)
                m_desciptionLabel.text = questViewModel.Description;


            if (m_button != null)
            {
                m_button.onClick.RemoveAllListeners();
                m_button.onClick.AddListener(questViewModel.OnClick);
            }

            UpdateVisual(questViewModel.IsSelected);
        }

        void UpdateVisual(bool isSelected)
        {
            if (m_animator != null)
            {
                m_animator.SetBool("IsSelected", isSelected);
            }
        }
    }
}