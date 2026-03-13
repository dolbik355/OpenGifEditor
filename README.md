OpenGifEditor — GIF Animation Editor
OpenGifEditor is a powerful and intuitive C#-based Windows application designed for frame-by-frame editing of GIF files. The application supports a full processing cycle: from resolution adjustments to managing frame delays.
Key Features
1. Getting Started and Interface
Upon launching the application, users are greeted by a modern dark-themed interface. The main menu allows for quickly opening the desired GIF file for further work.
![alt text](images/image1.png)

Figure 1 – Application Start Screen
2. Navigation and Frame Selection
After opening a file, the animation is broken down frame by frame. Users can navigate through frames using a slider. A frame counter (displaying current and total frames) is located in the lower-left corner.
![alt text](images/image3.png)

Figure 2 – Program window after opening a file
3. Editing Toolkit
Resolution Cropping (Crop)
This tool allows users to crop the animation from all sides.
Visual Feedback: Areas to be removed are highlighted in red.
Transparency: Overlapping areas do not layer opaque colors, allowing users to clearly see the editing boundaries.
![alt text](images/image4.png)

Figure 3 – Resolution/Format Editing
Trim by Length
This feature allows users to delete unnecessary frames by specifying a range for the start and end frames to be kept. Values can be entered manually or set based on the currently selected frame.
Adding Frames
Users can insert new images anywhere within the existing animation by selecting the specific frame number after which the insertion will occur.
![alt text](images/image8.png)

Figure 4 – Adding a new frame
4. Preview System
Before applying any changes, a preview window opens. It allows users to:
View the result dynamically (via the "Play" button).
Scroll through the result frame by frame.
Confirm ("Apply") or discard ("Cancel") the edits.
![alt text](images/image5.png)

Figure 5 – Preview window and interaction
5. Frame Timing Adjustments
The application allows users to set individual delays for each frame in milliseconds (1/1000 sec), providing full control over the animation speed.
![alt text](images/image10.png)

Figure 6 – Frame timing settings window
6. History Management (Undo/Redo)
The application features an integrated undo and redo system. If an edit does not meet the user's expectations, they can click the "Undo" button to revert to the previous state.
7. Safe Saving
If a user attempts to exit the program without saving changes, the system issues a warning. This prevents accidental loss of progress.
![alt text](images/image15.png)

Figure 7 – Save confirmation window
