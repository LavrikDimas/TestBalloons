using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class Balloon : MonoBehaviour
{
    [SerializeField]
    float speed;

    GameScore score;

    AudioManager audio;

    GameUI pauseButton;

    Transform destroyPoint;

    private bool isDestroyed = false;

	void Start ()
    {
        destroyPoint = GameObject.Find("BalloonDestroyPoint").transform;
        score = FindObjectOfType<GameScore>();
        audio = FindObjectOfType<AudioManager>();
        pauseButton = FindObjectOfType<GameUI>();
	}
	
	void Update ()
    {
        transform.position += Vector3.up * speed * Time.deltaTime;

        if (transform.position.y >= destroyPoint.position.y)
            DestroyBallon();
	}

    private void OnMouseDown()
    {
        if (isDestroyed || pauseButton.ifPause)
            return;

        audio.BalloonExplosion.Play();

        isDestroyed = true;

        score.ScoreGame++;

        var sequence = DOTween.Sequence();

        sequence.Append(transform.DOShakeScale(0.25f, 0.2f));
        sequence.Append(transform.DOScale(0.0f, 0.05f).SetEase(Ease.OutCubic));
        sequence.AppendCallback(DestroyBallon);
    }

    private void DestroyBallon()
    {
        Destroy(gameObject);
    }

}
