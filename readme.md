# FM:Systems

> `Submission by Jason Fedler on April 27, 2019`  
> Jason.Fedler@gmail.com     
> https://github.com/Three97/20190427

## Design Decisions

### API

Originally, I had built the API portion of the application with an additional .Service and a .DAL project. Each with their own interfaces. However, it felt like overkill for the task at hand, so I opted for the MVP approach.   
Additionally, I considered designing the API such that it had one call to get the locations and another call to get the latitude/longitude for the given location, but that felt a little too chatty, and over-engineered for the task at hand. A single call to the API solves the chattiness. Since there was really no other need for a call specific for the latitude/longitude, I decided to just make it one call with each object containing all the information it needed.

### Front End

For the front end, I went with a simple approach to get the location information (along with latitude/longitude for each) when the page loaded, and then when the selected index changed, it would make a call to the DarkSky API.

Originally, I had used epoch time, but I didn't feel like that was very obvious. And when it was clear to me that I was actually using July 4, 2018 @ 12:00**AM** instead of **PM**, I decided to swap that out with a more obvious datestamp. I coded that up with a string. Perhaps a Date converted to a string would have been more clear, but for this case, we're only using a single date, so I didn't feel like that extra overhead was necessary.

## To Run Locally

Open `Fms.Jpf.Submission.sln` in Visual Studio 2017/9 and Run using IIS Express. It will be running at http://localhost:51836/api/locations. If you go this route, the only other change to make is to include your secret key for the [Dark Sky][DarkSky] API. See section [File Changes](#Angular-File-Changes).

Alternatively, you can navigate to the root directory of the API project on the command line, and run `dotnet run`. This will require one more change in the Angular file `location.service.ts`. Line 10 will need to be updated to `http://localhost:5000/api/locations`.

Navigate to `Fms.Jpf.Submission.UI/weather-history` and `npm install` to get all the client-side dependencies installed. Then run the Angular app by executing `ng serve` in the `weather-history` directory.

> NOTE: You will need to update the Dark Sky API secret key before the Angular application will execute properly.

## Angular File Changes

### Secret Key Update

In the file `darksky.service.ts` file, update line 15 to be the secret key for your particular Dark Sky API secret key.

In the `location.service.ts` file, you may need to update the URL for the Location Service as it's dependent upon how you run the API (as explained in the [To Run Locally](#To-Run-Locally) section).

## Lessons Learned

I found the CORS issue to be the largest blocker. I hadn't experienced that before, so it took a little sluething. At first, I tried using a proxy server (hadn't done that before, either) but didn't get very far. At last I found the [CORS workaround](#CORS-Workaround-For-Local-Testing) explained below.

I need to get more familiar with Angular syntax. I knew what needed to be done but not necessarily the syntax to pull it off, so there was a little extra time spent there.

## CORS Workaround For Local Testing

This application uses a CORS workaround that is hosted [here][HerokuCorsAnywhere]. This bypasses the necessity for setting up a proxy for development purposes and works for testing locally.

> **NOTE:** This project is not intended to be production code. It's simply a proof of concept.

_This code has been successfully tested on a Windows 10 Pro machine and a MacBook Pro._

[DarkSky]: https://darksky.net/dev/docs
[HerokuCorsAnywhere]: https://cors-anywhere.herokuapp.com/

