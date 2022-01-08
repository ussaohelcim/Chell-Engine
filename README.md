# Chell-Engine
Raylib_cs game engine that uses PowerShell as the scripting language.

**YOU NEED .NET version 5 i think**

# *"why"*?

I love PowerShell, and it would be cool make my own game engine, so i'm making.

# How it works

The engine itself its writen in C#, it uses Raylib_cs to do all the bullshit like rendering, input, etc ...  
Basically it works this way:
- Someone made a library for Raylib (made in C, i think)
- Someone else C# bindingss for the Raylib and distributed as a C# package, called Raylib_cs
- I made my engine in C# using 
- I compiled my C# engine as a Dynamic-link library
- PowerShell can use .net librarys so i can use my C# engine, writing scripts in PowerShell, with everything running inside PowerShell

# Contribution

This engine is made by me for me, so I'm not accepting pull requests, feel free to open issues tho. 

# Ball Mouse demonstration

https://user-images.githubusercontent.com/57050328/148623945-079607ff-a5dd-4c5e-9d81-9136c6621bcb.mp4
