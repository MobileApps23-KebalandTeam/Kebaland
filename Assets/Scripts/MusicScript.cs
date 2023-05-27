using System;
using Core;
using Model;
using UnityEngine;
using UnityEngine.UI;

public class MusicScript : MonoBehaviour
{
    public static bool isMusicEnabled = true;

    [SerializeField] private GameObject speaker;

    private void Start()
    {
        isMusicEnabled = new GameStateService().loadProgress().sound;
        handleImage();
    }

    public void clicked()
    {
        isMusicEnabled = !isMusicEnabled;
        MGameState model = ServiceLocator.Get<GameStateService>().loadProgress();
        model.sound = isMusicEnabled;
        ServiceLocator.Get<GameStateService>().saveProgress(model);
        handleImage();
    }

    private void handleImage()
    {
        if (isMusicEnabled)
        {
            speaker.GetComponent<RawImage>().texture = Resources.Load<Texture>("Textures/s1");
        }
        else
        {
            speaker.GetComponent<RawImage>().texture = Resources.Load<Texture>("Textures/s2");
        }
    }
}
