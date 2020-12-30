# OBSLyrics
Lyric generator for OBS Studio

This app allows you to paste in lyrics for a song video. It will then place the lyrics 2, 3 or 4 lines at a time into a text file which can be used with the OBS Text Source to show the lyric lines.

Using the record facility of OBS this allows lyric videos to be quickly made.

## Setting up OBS

1. Run OBSLyrics and paste in the lyrics you want to show. 
2. Click "Top" to generate the first 2 lines.
3. Create a scene in OBS with the video you want to title as a Media Source.
4. Create a Text(GDI+) source in the same scene.
5. Right click the Text source and select Properties.
6. Tick the Read From File box and select the file on the desktop thqat OBSLyrics has made (shown in the box at the top of the OBSLyrics window)
7. Select a suitable font and size, and alignment
8. You should see the first 2 lines of lyrics appear in the Text item. The buttons on the app should move through the lines (there is a slight delay as OBS polls the file for changes)

You need to do some fiddling to keep the text centred on the screen as the text size changes:

1. In the preview window, right click on the text and select Transform -> Edit Transform
2. Select Bounding Box Type = Maximum Size Only
3. Select Alignment In Bounding Box = Centre
4. Set Bounding Box Size = 1280 x (suitable height)




##Drop shadow
OBS does not currently have the ability to do drop shadow on text.
You can duplicate the Text source (right click, Copy, Paste(Duplicate)) and make the lower text black, then use the Transform -> Edit Transform menu to offset one of them by a few pixels.
