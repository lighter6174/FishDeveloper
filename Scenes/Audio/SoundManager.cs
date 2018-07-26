
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{

    //设置单例变量
    private static SoundManager instance;
    //设置单例属性
    public static SoundManager Instance
    {
        get {
            return instance;
        }
    }

    //将声音放入字典中方便管理
    private Dictionary<string, AudioClip> _soundDictionary;

    //背景音乐和音效的音频源
    private AudioSource [] soundSources;
    private AudioSource bgSoundSouce;
    private AudioSource soundSourceEffect;

    void Awake()
    {
        instance = this;
    }
    void Start()
    {
        //加载所有音频资源
        LoadSound();
        //获取音频源,并设置音频的属性
        soundSources = this.GetComponents<AudioSource>();
        bgSoundSouce = soundSources[0];
        bgSoundSouce.playOnAwake = true;
        bgSoundSouce.loop = true;
        bgSoundSouce.Play();
        soundSourceEffect = soundSources[1];//按键音
        soundSourceEffect.playOnAwake = false;
        soundSourceEffect.loop = false;
    }
    private void LoadSound()
    {
        //初始化字典
        _soundDictionary = new Dictionary<string, AudioClip>();

        //本地加载
        AudioClip[] audioArray = Resources.LoadAll<AudioClip>("Audio");

        //存放到字典
        foreach (AudioClip item in audioArray)
        {
            _soundDictionary.Add(item.name,item);
        }

    }

    //播放背景音乐
    public void playBGSound(string soundName)
    {
        if (_soundDictionary.ContainsKey(soundName))
        {
            bgSoundSouce.clip = _soundDictionary[soundName];
            bgSoundSouce.Play();
        }

    }
    //播放音效果
    public void PlaySoundEffect(string soundEffectName)
    {
        if(_soundDictionary.ContainsKey(soundEffectName))
        {
            soundSourceEffect.clip = _soundDictionary[soundEffectName];
            soundSourceEffect.Play();
        }
    }
}
