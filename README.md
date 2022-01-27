# Chell-Engine
Raylib_cs game engine that uses PowerShell as the scripting language.

**YOU NEED .NET version 5 i think**

# *"why?"*

I love PowerShell, and it would be cool make my own game engine, so i'm making.

# How it works

The engine itself its writen in C#, it uses Raylib_cs to do all the bullshit like rendering, input, etc ...  
Basically it works this way:

- Someone made a library for Raylib (made in C, i think)
- Someone else made C# bindings for the Raylib and distributed as a C# package, called Raylib_cs
- I made my engine in C# using Raylib_cs
- I compiled my C# engine as a Dynamic-link library
- PowerShell can use .net librarys so i can use my C# engine, writing scripts in PowerShell, with everything running inside PowerShell

# Build

To build by yourself just clone this repository and run `.\build_stuff\buildeverything.ps1`.

# Games

Asteroids: https://github.com/ussaohelcim/Asteroids  
Agario: https://github.com/ussaohelcim/agario  
PowerPong: https://github.com/ussaohelcim/PowerPong