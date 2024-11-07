using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class BGM : MonoBehaviour
{
    List<AudioSource> musicSongs;
    int _currentSong = -1;
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        if(GameObject.FindObjectsOfType(typeof(BGM)).Length > 1) Destroy(gameObject);

        musicSongs = GetComponents<AudioSource>().ToList();

        GetNewRandomSong();
        musicSongs[_currentSong].Play();
    }

    private void GetNewRandomSong()
    {
        int newSong = _currentSong;
        while(newSong == _currentSong)
        {
            newSong = Random.Range(0, musicSongs.Count);
        }
        _currentSong = newSong;
    }


    private void Update()
    {
        if (!musicSongs[_currentSong].isPlaying)
        {
            GetNewRandomSong();
            musicSongs[_currentSong].Play();
        }
    }

}
