# Implementation of new Plex Auth in C#
This repo is example of implementation Plex Auth in C#, mostly it is just Proof of Concept  
  
In general, Plex introduced a new way to grab Token from User. Also this method gives to user more control of application.
Also your application will appear on device list.

## How it works
For a getting new plex token for first time you need generate a pin/id and code. This can be accomplished via sending POST request with ID of your application, and name. This first request will gives you ID and code of pin. Next step is generate auth link. Auth link have a template where you need provide ID of your application, code of pin and name. This will link your application to your plex account. You can get good old Token now via another GET request.
When you finish this process you don't need generate new pin after next launch, You can reuse pin id and code that you generated.
[Detailed explanation by Plex](https://forums.plex.tv/t/authenticating-with-plex/609370)


### Feel free to fork or create pull request i will be happy :)
