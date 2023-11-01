using System.Collections;
using System.Collections.Generic;
using UnityEngine.Video;
using UnityEngine.UI;
using UnityEngine;

public class VideoInStreamingAssets : MonoBehaviour
{
    [Header("Video Seleccionado")]
    [SerializeField] VideoClip videoActual;
    [SerializeField] private string videoFileName;

    [Header("Lista de videos")]
    [Tooltip("Para ejecutar algo tras terminar el video que debe estar duplicado en otra carpeta distinta a StreamingAssets")]
    [SerializeField] VideoClip video1;
    [SerializeField] VideoClip video2;
    [SerializeField] RawImage lienzo;


    [Space(10)]
    [Header("Campos automaticos")]
    [SerializeField] private float duracionVideo;
    [SerializeField] private float tiempoTranscurrido;
    VideoPlayer videoPlayer;


    void Awake()
    {
        videoPlayer = GetComponent<VideoPlayer>();
    }

    private void Update()
    {
        if (tiempoTranscurrido >= duracionVideo)
        {
            //Hacer algo cuando el video acabe
            OcultarVideo();
        }
        else tiempoTranscurrido += Time.deltaTime;
    }

    public void GetVideoDuration(string _videoFileName)
    {
        //Si tus videos tienen otro nombre, cambialo aquí
        if (_videoFileName == "video_1.mp4") videoActual = video1;
        else if (_videoFileName == "video_2.mp4") videoActual = video2;
        duracionVideo = (float)videoActual.length;
    }

    public void PlayVideo(string _videoFileName)
    {
        tiempoTranscurrido = 0;
        GetVideoDuration(_videoFileName);
        lienzo.gameObject.SetActive(true);
        videoFileName = _videoFileName;//Incluye la extensión del video (ej: .mp4)
        videoPlayer.url = System.IO.Path.Combine(Application.streamingAssetsPath, videoFileName);
        videoPlayer.Play();
    }

    public void OcultarVideo()
    {
        if (lienzo.gameObject.activeSelf)
        {
            lienzo.gameObject.SetActive(false);
        }
    }
}