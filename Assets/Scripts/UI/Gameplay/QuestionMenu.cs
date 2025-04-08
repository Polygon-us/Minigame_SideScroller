using ScriptableObjects.Questions;
using GMTK.PlatformerToolkit;
using UnityEngine.UI;
using UnityEngine;
using TMPro;

namespace UI.Gameplay
{
    public class QuestionMenu : MenuBase
    {
        [SerializeField] private TMP_Text messageTxt;
        [SerializeField] private TMP_Text impressionTxt;
        [SerializeField] private Image characterImage;
        [SerializeField] private Button sendBtn;
        [SerializeField] private movementLimiter movementLimiter;
        [SerializeField] private UIManager uiManager;
        [SerializeField] private GameObject questionPrefab;
        [SerializeField] private ToggleGroup toggleGroup;
        [SerializeField] private RectTransform questionContainer;
        [SerializeField] private QuestionInfoSO questionInfo;

        private Answer _selectedAnswer;

        protected override void Awake()
        {
            base.Awake();

            sendBtn.onClick.AddListener(OnSend);
            sendBtn.interactable = false;
        }

        protected override void Start()
        {
            base.Start();

            messageTxt.text = questionInfo.questionMessage;
            impressionTxt.text = questionInfo.impression;
            characterImage.sprite = questionInfo.thinkingPoses.GetRandom();

            foreach (var answer in questionInfo.answers)
            {
                AnswerComponent newAnswer =
                    Instantiate(questionPrefab, questionContainer).GetComponent<AnswerComponent>();
                newAnswer.Initialize(answer, toggleGroup);
                newAnswer.OnClick += SetSelectedAnswer;
                toggleGroup.RegisterToggle(newAnswer.Toggle);
            }
        }

        public override void Show()
        {
            base.Show();

            uiManager.ToggleMobileInput(false);
            movementLimiter.CharacterCanMove = false;

            toggleGroup.allowSwitchOff = true;
            toggleGroup.SetAllTogglesOff(false);
        }

        public override void Hide()
        {
            base.Hide();

            uiManager.ShowResult();
        }

        private void SetSelectedAnswer(Answer answer)
        {
            sendBtn.interactable = true;
            toggleGroup.allowSwitchOff = false;
            _selectedAnswer = answer;
        }

        private void OnSend()
        {
            if (_selectedAnswer.correct)
                Hide();
        }
    }
}