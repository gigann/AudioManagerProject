# AudioManager
 An Audio Manager singleton for playing and managing sound effects, music, and ambience in Unity.

Setup:
1. Add AudioManager.cs and AudioMixer.mixer to your project.
2. Create an empty gameobject and attach AudioManager.cs to it.
3. Set Master Mixer to AudioMixer.
4. Add 3 AudioSource objects to the gameobject for sound, music, and ambience.
5. For each, disable Play on Awake.
6. Set the sound AudioSource's Output to the AudioMixier's Sound channel.
7. Set the music AudioSource's Output to the AudioMixier's Music channel.
8. Set the ambience AudioSource's Output to the AudioMixier's Ambience channel.
9. Drag the sound AudioSource into the AudioManager's sourceSound, music into sourceMusic, and ambience into sourceAmbience.

Adding Audio Files:
1. Go to the gameobject with AudioManager.cs attached.
2. Create a new item in the gameobject's  SoundEffects, MusicTracks, or AmbienceTracks collections.
3. In the name field, set the name to any valid string. This is what you will reference the audio file as in code.
4. In the file field, drag and drop an audio file from your Assets to associate with the name.

Playing Audio Files:
   For playing sound effects, call AudioManager.instance.PlaySound() and pass it an array of strings.
   Each string in the array contains a audio file name which will be randomly chosen and played.

   For playing music, call AudioManager.instance.PlayMusic() and pass it true if you want the song to loop; false otherwise,
   and also an array of strings, in the same manner as sound effects.

   For playing ambience, call AudioManager.instance.PlayAmbience(), and pass it params in the same way as .PlayMusic().

Adjusting Volume:
   Call AdjustMasterVolume(), AdjustSoundVolume(), AdjustMusicVolume(), or AdjustAmbienceVolume(), and
   pass a float for the new volume.

See the sample project ExampleScene for an example on setting up volume sliders.
