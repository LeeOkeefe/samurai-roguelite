﻿using UnityEngine;

internal sealed class Torch : MonoBehaviour
{
    private ParticleSystem m_Torch;
    private AudioSource m_Audio;

    private void Start()
    {
        m_Torch = GetComponentInChildren<ParticleSystem>();
        m_Audio = GetComponentInChildren<AudioSource>();

        DayNightCycle.Instance.RegisterEndOfDayEvent(() => Toggle(false));
        DayNightCycle.Instance.RegisterStartOfDayEvent(() => Toggle(true));
    }

    private void Toggle(bool on)
    {
        if (on)
        {
            m_Torch.Play();
            m_Audio.Play();
        }
        else
        {
            m_Torch.Stop();
            m_Audio.Stop();
        }
    }
}