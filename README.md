# Win32Interop.WinHandles

Provides an abstraction on-top of IntPtr for Win32 windows, and provides methods for interacting with Win32 windows. Inspired by the popularity [this stackoverflow answer](http://stackoverflow.com/a/20276701/548304).

Add it [via nuget](https://www.nuget.org/packages/Win32Interop.WinHandles/)

 > Install-Package Win32Interop.WinHandles

# Quick Setup

## Finding a single win32 window

If you're looking to find a single window, use `TopLevelWindowUtils.FindWindow`:

```
var window = TopLevelWindowUtils.FindWindow(wh => wh.GetWindowText().Contains("Notepad"));
Console.WriteLine("Notepad's current title :", window.GetWindowText());
```

## Find multiple win32 windows

If you're looking to find all windows, use `TopLevelWindowUtils.FindWindows`:

```
var allNotepadWindows
   = TopLevelWindowUtils.FindWindows(wh => wh.GetWindowText().Contains("Notepad"));
```

# Library Architecture

The library provides a helpful class `WindowHandle` to represent a Win32 window.  `WindowHandle` is only a thin wrapper over an `IntPtr`, with all helper methods located in extension methods.

## Available extension methods to `WindowHandle`

The extension methods that this library provides for `WindowHandle` are:

 - `IsVisible()` to check if the window is currently visible
 - `GetWindowText()` to get the text of the given window
 - `GetClassName()` to get the name of the win32 class that owns the window
 
There's not many, but I expect to add more as time goes on.

## Retreiving instances of  `WindowHandle`

The library offers a couple ways of retreiving specific  `WindowHandle`s: 

 - `TopLevelWindowUtils.GetForegroundWindow()` gets the current window that's in the foreground (usually the active window)
 - `TopLevelWindowUtils.FindWindows(Predicate<WindowHandle> predicate)` finds all windows that pass a given predicate
 - `TopLevelWindowUtils.FindWindow(Predicate<WindowHandle> predicate)` finds a single window that pass a given predicate

Of course, if you want to construct a `WindowHandle` from an `IntPtr` that you already have, there is a constructor that accepts an `IntPtr`.

## Getting the original `IntPtr`

If for some reason you need the original `IntPtr` of a `WindowHandle`, use the `RawPtr` property.

# Contributing

Have a general-purpose method or getter that should be added?  Feel free to make a pull-request or an issue for the desired functionality!  The library is currently pretty thin, but that's only because it only includes the functionality that I (or others) have needed thus far.
