# Implementation of new Plex Auth in C#
This repo is impementation of new Plex Token Auth in C# as standalone class
  
In general, Plex introduced a new way to grab Token from User. Also this method gives to user more control of application.
Also your application will appear on device list.
[Detailed explanation by Plex](https://forums.plex.tv/t/authenticating-with-plex/609370)

# Installation  
Class uses a Newtonsoft Json Framework to parse JSON to objects. So it is important to install Newtonsoft.Json to you project.
# Method implementation

## Setting Application ID and Name
```c#
public void PlexAuth.Set(string ID, string name);
```
## Generating necessary PIN and code
This method open your browser construct Auth URL and receive PIN and Code to generate token.
```c#
public void PlexAuth.Generate();
```
## Generating URL to authenticate
Private method used in PlexAuth.Generate(); to generage URL from App ID and Name, also you can provide a countdown in seconds as argument.
```c#
private void PlexAuth.genUrl(int countdown);
```
## Generating Token
Public method returning Token generated from Pin and Code as string else it will return null;
```c#
public string PlexAuth.Token();
```
## 

## Printing current Token
Getter to print current saved Token
```c#
public string PlexAuth.CurrentToken();
```

## Valid Token
Check if provided token is valid, returns true or false
```c#
public bool PlexAuth.ValidToken();
```

## Saving credentials
Save pin,code and current token to file, return true or false. You need to provide a file name as string argument
```c#
public bool PlexAuth.SavePin(string filename);
```

## Loading credentials
Load pin,code and current token from file, return true or false. You need to provide a file name as string argument
```c#
public bool PlexAuth.LoadPin(string filename);
```

## Getting Server URI
Check plex resources and try to find server. Return server URI if found or null if no server was found
```c#
public string GetServer();
```
## Example
Program.cs contain basic example



### Feel free to fork or create pull request i will be happy :)
