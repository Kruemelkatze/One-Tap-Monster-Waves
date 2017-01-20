using UnityEngine;

public class SoundManager : MonoBehaviour {
	public AudioSource[] efxSource;
	public AudioSource loopMusic;

	public AudioClip OnAnySound;

	public AudioClip defaultTheme;
	public float defaultThemeVolume = 1;

	public AudioClip currentTheme;
	public float currentThemeVolume = 1;

	public AudioClip StandardTheme;

	private int nextSourceToUse = 0;
	public float lowPitchRange = .95f;
	public float highPitchRange = 1.05f;

	void Awake(){
		if (efxSource.Length == 0) {
			efxSource = new AudioSource[10];

			for (int i = 0; i < efxSource.Length; i++) {
				efxSource[i] = new AudioSource();
			}
		}

		currentTheme = defaultTheme;
		PlayCurrentTheme ();

		//RegisterEvents
	}

	void OnDestroy() {
		//Unregister Events
	}

	public void PlaySingle(AudioClip clip, float volume = 1)
	{
		int index = nextSourceToUse;
		nextSourceToUse = (nextSourceToUse + 1) % efxSource.Length;
		efxSource [index].clip = clip;
		efxSource [index].volume = volume;
		efxSource [index].Play ();
	}

	public void RandomizeSfx (float volume, params AudioClip[] clips)
	{
		if (volume < 0) {
			volume = 0;
		} else if (volume > 1) {
			volume = 1;
		}
		int randomIndex = Random.Range(0, clips.Length);

		float randomPitch = Random.Range(lowPitchRange, highPitchRange);

		int index = nextSourceToUse;
		nextSourceToUse = (nextSourceToUse + 1) % efxSource.Length;

		efxSource[index].pitch = randomPitch;

		efxSource[index].clip = clips[randomIndex];
		efxSource [index].volume = volume;
		efxSource[index].Play();
	}

	//Music controller
	public void SetCurrentTheme(AudioClip clip, float volume = 0.3f) {
		bool sameTheme = clip.name.Equals (currentTheme.name);

		currentThemeVolume = volume;

		if (!sameTheme) {
			currentTheme = clip;
			PlayCurrentTheme ();
		}
	}

	public void SetDefaultThemeAsCurrentTheme() {
		SetCurrentTheme (defaultTheme, defaultThemeVolume);
	}

	public void PlayCurrentTheme() {
		PlayMusic (currentTheme, currentThemeVolume);
	}

	public void PlayMusic(AudioClip clip, float volume = 0.3f) {
		loopMusic.Stop ();
		loopMusic.loop = true;
		loopMusic.clip = clip;
		loopMusic.volume = volume;
		loopMusic.Play ();
	}
}