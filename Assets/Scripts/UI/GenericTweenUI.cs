﻿using DG.Tweening;
using UnityEngine;

namespace ShotMergerClone.UI
{
    [RequireComponent(typeof(RectTransform))]
    public class GenericTweenUI : MonoBehaviour
    {
        private RectTransform rectTransform;

        private Sequence sequence;

        private void Awake()
        {
            rectTransform = GetComponent<RectTransform>();
            sequence = DOTween.Sequence();
        }

        [SerializeField] private bool isIndependentFromTimeScale = false;
        [SerializeField] private float animationTime = 1;
        [SerializeField] private Ease animationEase = Ease.Linear;
        [SerializeField] private bool canLoop = false;
        
        [SerializeField]  private int loopCount = -1;
        [SerializeField]  private LoopType loopType = LoopType.Yoyo;
        [SerializeField] private bool posChange = true;
        [SerializeField]  private Vector2 startPos = Vector3.zero;
        [SerializeField] private Vector2 endPos = Vector3.zero;
       
        [SerializeField] private bool scaleChange = false;
        [SerializeField]  private Vector3 startScale = Vector3.one;
        [SerializeField]  private Vector3 endScale = Vector3.one;
        [SerializeField] private bool rotChange = false;
        [SerializeField]  private Vector3 startRot = Vector3.zero;
        [SerializeField]  private Vector3 endRot = Vector3.zero;


        private void Start()
        {
            if (isIndependentFromTimeScale)
                sequence.SetUpdate(true);

            if (posChange)
                sequence.Join(rectTransform.DOAnchorPos(endPos, animationTime).From(startPos).SetEase(animationEase));

            if (scaleChange)
                sequence.Join(rectTransform.DOScale(endScale, animationTime).From(startScale).SetEase(animationEase));

            if (rotChange)
                sequence.Join(rectTransform.DORotate(startRot, animationTime).From(endRot).SetEase(animationEase));

            if (canLoop)
                sequence.SetLoops(loopCount, loopType);
        }

        private void OnDestroy()
        {
            sequence.Kill();
        }
    }
}
