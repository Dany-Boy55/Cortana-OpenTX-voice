# Cortana-OpenTX-voice
A quick and dirty piece of code that produces voice commands based on windows TTS. In this repo, you can download and unzip the "en" folder, which contains system sounds, custom sounds (primarily for mini quads), and the necesary CSV file for the radio to recognize the voice pack. You can also find the VS files, including the applicationand, solution, and code.<br>

**Important note: This repo only contains english voicelines and uses metric system only!** However, you can generate other languages and use imperial if you so desire by creating your own voice lines
<br>

The "I just want to use cortana on my radio" instructions:
1. Download the repo and unzip the "en" folder
2. If you have an micro SD card reader, plug your taranis SD card to your pc and go to step 5. If you dont have an micro SD card reader, continue with the following steps
3. Enter into bootloader mode in your radio by powering it while you hold the yaw and roll trims towards the center of the radio
4. Connect your radio to your PC with a USB cable and open the SD card device
5. Open the "sounds folder", identify the "en" folder, and replace it with the one you just downloaded
6. Enjoy your new radio with a cortana Voice Pack!
<br>

If you want to create custom voice lines for your radio:
1. You will first need to add "Eva mobile" as a voice synthesyzer (That's cortana's voice TTS)
2. For that I recommend you follow [this guide](http://fieldguide.gizmodo.com/make-your-mac-feel-like-new-again-with-a-fresh-install-1697926482)
3. Go to TaranisSpeechGenerator/SpeechGenerator/bin/Debug/SpeechGenerator.exe
4. If you installed the TTS for Eva correclty, you shuold be able to select "Microsoft Eva Mobile" as a voice TTS
5. You can now type whatever you want the synthesyzer to say. Click "speak!" to hear it aloud.
6. To save it as a wav audio file, click on "save as" and follow the save prompt. The file has the recommended parameters for the Taranis X9D radio
7. Enjoy Cortana on your radio!
<br>

If you want to generate multiple voice lines at a time:
1. Use a CSV file, separated with commas, where the first values is the file name (6 letters max length), and the second values is the voice line
2. Within the app, click on "load CSV file" and select the file you want to read
3. Select a folder where to save all the audio files, and you are done!
<br>
