# FM:Systems

> `Submission by Jason Fedler on April 27, 2019`  
> Jason.Fedler@gmail.com     
> https://github.com/Three97/20190427

## To Run Locally

Open `Fms.Jpf.Submission.sln` in Visual Studio 2017/9 and Run using IIS Express. It will be running at http://localhost:51836/api/locations. If you go this route, the only other change to make is to include your secret key for the [Dark Sky][DarkSky] API. See section [File Changes](#Angular-File-Changes).

Alternatively, you can navigate to the root directory of the API project on the command line, and run `dotnet run`. This will require one more change in the Angular file `location.service.ts`. Line 10 will need to be updated to `http://localhost:5000/api/locations`.

Navigate to `Fms.Jpf.Submission.UI/weather-history` and `npm install` to get all the client-side dependencies installed. Then run the Angular app by executing `ng serve` in the `weather-history` directory.

> NOTE: You will need to update the Dark Sky API secret key before the Angular application will execute properly.

## Angular File Changes

### Secret Key Update

In the file `darksky.service.ts` file, update line 15 to be the secret key for your particular Dark Sky API secret key.

In the `location.service.ts` file, you may need to update the URL for the Location Service as it's dependent upon how you run the API (as explained in the [To Run Locally](#To-Run-Locally) section).

## CORS Workaround For Local Testing

This application uses a CORS workaround that is hosted [here][HerokuCorsAnywhere]. This bypasses the necessity for setting up a proxy for development purposes and works for testing locally.

> **NOTE:** This project is not intended to be production mode. It's simply a proof of concept.

[DarkSky]: https://darksky.net/dev/docs
[HerokuCorsAnywhere]: https://cors-anywhere.herokuapp.com/

