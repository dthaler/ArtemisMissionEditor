# Artemis Mission Editor

## About

**Artemis Mission Editor** is a program developed by players (not affiliated 
with Artemis author Thom Robertson).  It is designed to be a complete 
mission editing environment for 
[Artemis: Space Bridge Simulator](https://artemisspaceshipbridge.com/), 
providing graphical space map interface, interactive command and condition
editing with input suggestion and context help, while presenting commands
and conditions in plain English text.

**This program will allow you to:**

* Create and edit missions in a Windows Forms interface 
* Edit your commands and conditions in a graphical user interface with 
  drop down input suggestion, context help and lots of keyboard hotkeys for 
  fast operation 
* See and operate mission conditions and statements as plain English text, 
  meaning you don't have to study the help files to know what commands or 
  conditions are available to you or what the exact command or condition 
  you encountered in mission file will actually do in game, you just choose
  commands or conditions from the list, and see everything in plain English,
  like "Create enemy at point (x, y, z) bearing 35 degrees with name..." 
* Structure your mission's events into folders, making it MUCH easier to 
  navigate bigger missions 
* Convert deprecated statements (like "direct") into their new versions
  (direct => add\_ai point\_throttle/target\_throttle) 
* Edit "create object" statements in events and start blocks using a
  graphical space map, which tremendously helps positioning objects around 
* Edit coordinates / spheres / rectangles on space map too (used in
  statements like direct, add\_ai, if\_inside/outside\_sphere/box,
  destroy\_near, ...) 
* See the logic flow and event dependency (which event triggers which event
  or requires which event to be triggered, etc.) 
* Quickly find errors in your mission, like missing attributes that will
  crash the game, etc. 
* Use all the quality-of-life features you expect to have: 
  * Copy/paste (you can even copy/paste to/from a text editor)
  * Undo/redo
  * Autosave into a separate file so you don't lose unsaved work in the
    case of unexpected shutdown
  * Find/replace (smart, meaning you can look or replace inside specific 
    attributes etc.)
* Tweak it to your liking by modifying an extensive settings list.

## Download and Install

This program is made for Microsoft Windows operation system and requires
.Net Framework 4.0.  

You can download a ready-to-install version from the links at
[http://artemiswiki.pbworks.com/w/page/53389687/Mission%20Editor](http://artemiswiki.pbworks.com/w/page/53389687/Mission%20Editor)

* By default, the program expects to be located inside a subfolder of the 
  Artemis folder, like Artemis\Editor

  * However, you can manually specify a path to the vesselData.xml, and
    keep the program where you want. 

  * Command line syntax is: ArtemisMissionEditor.exe [ _missionfilename_ ]
    [ -v _vesseldatafilename_ ]

* The program will store its settings file and autosave files in your
  %appdata%\ArtemisMissionEditor folder, and store registry information 
  in current user's Software\ArtemisMissionEditor registry key.

## Tutorial Videos
 
There are videos available at YouTube, describing the functionality of 
the editor and showing how to use it:
 
* [www.youtube.com/watch?v=lX69QaoZyRA](www.youtube.com/watch?v=lX69QaoZyRA) - Introduction
* [www.youtube.com/watch?v=M14GG6WI5m8](www.youtube.com/watch?v=M14GG6WI5m8) - 01 - Interface and basic editing
* [www.youtube.com/watch?v=4nL6tBnoISY](www.youtube.com/watch?v=4nL6tBnoISY) - 02 - Space map
* [www.youtube.com/watch?v=RaW-gu0H33Q](www.youtube.com/watch?v=RaW-gu0H33Q) - 03 - Advanced editing
* [www.youtube.com/watch?v=wVcHsntVdk4](www.youtube.com/watch?v=wVcHsntVdk4) - 04 - Dependencies

## Interface Overview and Hotkeys

You can read basic information about the Artemis Mission Editor's
interface and hotkeys [on a stand-alone page here](http://artemiswiki.pbworks.com/w/page/53390043/Mission%20Editor%20-%20Interface%20Overview).

![Main Form](http://artemiswiki.pbworks.com/w/file/fetch/53389784/MissionEditor_MainForm.png "Main Form")
![Space Map Form](http://artemiswiki.pbworks.com/w/file/fetch/53389921/MissionEditor_SpaceMapForm.png "Space Map Form")

## Other Documentation

* [Changelog](ArtemisMissionEditor/zzz_Changelog.txt)
* [Documentation](ArtemisMissionEditor/zzz_Documentation.txt)
* [Future Plans](ArtemisMissionEditor/zzz_Future_Plans.txt)
* [Release Instructions](ArtemisMissionEditor/zzz_Release_Instructions.txt)

## Questions? Feedback?

Your user feedback is much appreciated! You can provide feedback in the
Artemis Forums in the topic dedicated to the editor 
[https://artemis.forumchitchat.com/post?id=8115862](https://artemis.forumchitchat.com/post?id=8115862)
