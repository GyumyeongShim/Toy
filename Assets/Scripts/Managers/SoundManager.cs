using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager
{
    //json, xml등 테이블에 필요한 오디오파일들을 입력해두고 초기에 읽어오는 방향으로
    //UnityEngine.Audio.AudioMixer를 통해 특수한 효과 등을 할수있음, cpu를 많이 먹는다함
    //play,stop bgm(),fx(),ambient(),voice() 등등
    //get,set volume()을 통한 음량 변경 오디오소스.volume = float
    // MP3 Player   -> AudioSource
    // MP3 음원     -> AudioClip
    // 관객(귀)     -> AudioListener
    AudioSource[] m_audioSources = new AudioSource[(int)Define.Sound.MaxCount];
    Dictionary<string, AudioClip> m_audioClips = new Dictionary<string, AudioClip>();

    public void Init()
    {
        GameObject root = GameObject.Find("@Sound");
        if (root == null)
        {
            root = new GameObject { name = "@Sound" };
            Object.DontDestroyOnLoad(root);

            string[] soundNames = System.Enum.GetNames(typeof(Define.Sound));
            for (int i = 0; i < soundNames.Length - 1; i++)
            {
                GameObject go = new GameObject { name = soundNames[i] };
                m_audioSources[i] = go.AddComponent<AudioSource>();
                go.transform.parent = root.transform;
            }

           m_audioSources[(int)Define.Sound.Bgm].loop = true;
        }
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
            AudioSource audioSource = m_audioSources[(int)Define.Sound.Bgm];
            if (audioSource.isPlaying)
                audioSource.Stop();

            audioSource.pitch = pitch;
            audioSource.clip = audioClip;
            audioSource.Play();
        }
        else
        {
            AudioSource audioSource = m_audioSources[(int)Define.Sound.Effect];
            audioSource.pitch = pitch;
            audioSource.PlayOneShot(audioClip);
        }
    }

    AudioClip GetOrAddAudioClip(string path, Define.Sound type = Define.Sound.Effect)
    {
        if (path.Contains("Sounds/") == false)
            path = $"Sounds/{path}";

        AudioClip audioClip = null;

        if (type == Define.Sound.Bgm)
        {
            audioClip = Managers.Resource.Load<AudioClip>(path);
        }
        else
        {
            if (m_audioClips.TryGetValue(path, out audioClip) == false)
            {
                audioClip = Managers.Resource.Load<AudioClip>(path);
                m_audioClips.Add(path, audioClip);
            }
        }

        if (audioClip == null)
            Debug.Log($"AudioClip Missing ! {path}");

        return audioClip;
    }

    public void Clear()
    {
        foreach (AudioSource audioSource in m_audioSources)
        {
            audioSource.clip = null;
            audioSource.Stop();
        }

        m_audioClips.Clear();
    }
}
