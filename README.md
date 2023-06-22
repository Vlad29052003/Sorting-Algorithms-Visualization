# Sorting Algorithms Visualization

This is an application that was created in Visual Studio 2022. It is written C# and it uses a .NET framework for the UI. It was part of my Professional Certificate that attests my computer science knowledge. The project was called "Sorting Algorithms. Comparative Analysis" and it cosisted of this application and a written document which described C# programming language in brief, some functionalities of the application, the idea behind each algorithm and a bit abut their complexity. It can be found in the directory "Other files" and it is written in Romanian. The application is named "Vizualizare Sortari" ("Sorting Algorithms Visualization"). 9 of the most common sorting algorithms are implemented in the application (the files can be found in the directory "Vizualizare Sortari").

# About the Application

The application has a simple and intuitive user interface. At the top of the page, in the left corner, there are 2 buttons: "File" - whick displayes an "Exit" button when clicked, and a "Help" button which describes the button. The main menu strip of the application can be found just below these 2 button. It consistes of a dropdown menu from which the user can select the desired sorting algorithm, a "Delay" input which allows the user to enter a value which represents the amount of miliseconds that the program will wait after each swap operation in the sorting algorithm. After it, there is another input which allows the user to specify a number which represents the width of the bars (whose height represent the value of the numbers) that are displayed. Finally, there are 3 button: "Reset" - which will (re)fill the vector with random numbers and display them on the screen, "Start" - which starts the algorithm, and finally "Pause/Resume" - which pauses and resumes the sorting algorithms (it only works for a couple of them). Under the buttons there is the display screen, the final component of the application.

# Technology

C# is an object-oriented programming language and this can be seen in the application. Each of the sorting algorithms is implemented in its own class. Each of these classes inherit from the class Vizualization which contains the common methods: the Swap method and DrawBar which displays the numbers when they are swapped. These classes also inherit from Interface1, forcing them to implement the NextStep() method which is used in order to enable the pause/resume functionality.

The sorting algorithms are executed on a different thread using the BackgroundWorker class. This enables the control bar of the application to be usable during the execution of an algorithm. Without this feature, the user would have been forced to wait until the execution finished and the pause/resume would be unusable.

I also used a bit of functional programming. It was used to populate the dropdown menu with the name of the classes.

# Download Link

This is a link to the Directory on my Google Drive account:

```js
https://drive.google.com/drive/folders/1R9sLieuFH11cFAd0uhV7Qzwu3RLimNBm?usp=share_link
```

It features the self-contained release designed for 64-bit processors.
