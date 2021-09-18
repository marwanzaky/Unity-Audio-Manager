# Unity Audio Manager Tool

## Features
1. Easy to manage all your audios in one Scriptable Object file
2. Easy to access via code
3. Offering even more methods, and each of them with its own use case

## Usage
1. Download this project, and add them to your own one
1. Create a new empty gameObject named "AudioManager", and attach an AudioManager component to it
2. Go to "Assets > Create > Scriptable Objects > Audio Manager Data" to create a new file to manage your audios' data
3. Next, add a new audio to the array list providing as well all the information needed for the audio
4. Go to AudioManager gameObject, and add the reference to the AudioManager Data you just created
5. Finally, simply play the audio with this line of code

```
string audioName = "Button";
AudioManager.Instance.Play(audioName);
```
<img width="715" alt="Screen Shot 2021-09-18 at 00 51 21" src="https://user-images.githubusercontent.com/64248203/133864413-20362fde-5e96-4906-944b-bde6c16ead08.png">
