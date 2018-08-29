using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    #region

    [Header("Audio Menu")]

    [SerializeField]
    AudioSource onClickButon;

    [SerializeField]
    AudioSource balloonExplosion;

    #endregion

    public AudioSource OnClickButton { get { return onClickButon; } }
    public AudioSource BalloonExplosion { get { return balloonExplosion; } }

}
