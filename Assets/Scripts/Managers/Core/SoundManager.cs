using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class SoundManager
{
    AudioSource[] _audioSources = new AudioSource[(int)Define.Sound.MaxCount];
    Dictionary<string, AudioClip> _audioClips = new Dictionary<string, AudioClip>();

    public Action<string, Define.Sound> OnSoundEvent;
    private bool _onPlayWalkSound = false;

    // MP3 Player   -> AudioSource
    // MP3 음원     -> AudioClip
    // 관객(귀)     -> AudioListener

    private string[]    _bgmLevels;
    private uint        _prevLevel;

    public void Init()
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
            UnityEngine.Object.DontDestroyOnLoad(root);

            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));

            for (int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject go = new GameObject { name = soundNames[i] };
                _audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }

            _audioSources[(int)Define.Sound.Bgm].loop = true;
        }
    }

    public void Clear()
    {
        foreach (AudioSource audioSource in _audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }
        _audioClips.Clear();
    }

    public void StopBgm(string path, Define.Sound type = Define.Sound.Bgm)
    {
        AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
        audioSource.Stop();
    }

    public void Play(string path, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
    {
        AudioClip audioClip = GetOrAddAudioClip(path, type);
        Play(audioClip, type, pitch);
    }

	public void Play(AudioClip audioClip, Define.Sound type = Define.Sound.Effect, float pitch = 1.0f)
	{
        if (audioClip == null)
            return;

		if (type == Define.Sound.Bgm)
		{
			AudioSource audioSource = _audioSources[(int)Define.Sound.Bgm];
            if (audioSource.isPlaying)
            {
                audioSource.Stop();
                audioSource = null;
                audioSource = _audioSources[(int)Define.Sound.Bgm];
            }

            audioSource.pitch = pitch;
			audioSource.clip = audioClip;
            audioSource.volume = 0.1f;
            audioSource.Play();
		}
		else
		{
			AudioSource audioSource = _audioSources[(int)Define.Sound.Effect];
			audioSource.pitch = pitch;
			audioSource.PlayOneShot(audioClip);
		}
	}

	AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect)
    {
		if (path.Contains("Sounds/") == false)
			path = $"Sounds/{path}";

		AudioClip audioClip = null;

        switch (type)
        {
            case Define.Sound.Bgm:
                {
                    audioClip = Managers.Resource.Load<AudioClip>(path);
                }
                break;
            case Define.Sound.Effect:
                {
                    if (_audioClips.TryGetValue(path, out audioClip) == false)
                    {
                        audioClip = Managers.Resource.Load<AudioClip>(path);
                        _audioClips.Add(path, audioClip);
                    }

                    if (audioClip == null)
                        Debug.Log($"AudioClip Missing ! {path}");
                }
                break;
        }

		return audioClip;
    }

    //void PlaySound(string path, Define.Sound type)
    //{
    //    if (_onPlayWalkSound == false && type == Define.Sound.WalkSound)
    //    {
    //        _onPlayWalkSound = true;
    //        Play(path, type, 1.2f);
    //    }
    //}
}
