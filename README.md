# REST and SOAP WS Lab
The main idea of this lab is to develop and deploy an intermediary Web service (IWS) between the Velib WS and some WS clients.

# Extensions présentes
* Minimal release: Intermediary Web Service (IWS_VelibWS), Console Application (ClientConsole)
* [Graphical User Interface](#-extension:-client-gui-clientgui) (ClientGUI)
* [Caching](#-extension:-caching)
* [Monitoring](#-extension:-monitor-gui)

---

## Intermediary Web Service
Provide two services : **Service** and **MonitorService**
### Client Service : "Service"
Contains the following interface : 
```c#
string GetInfoAbout(string station, string cityName);
```
Return an output string displaying the number of bikes available and the number of free bikes stands.

```c#
Contract[] GetCities();
```
Return an array of Contract.

```c#
Station[] GetStations(string cityName);
```
Return an array of Station.

```c#
void RefreshStations(string cityName);
```
Update the stations array (check if already cached).

### Extension: Monitor Service : "MonitorService"
```c#
int GetNbRequest();
```
Return the number of external requests made (total).
```c#
int GetNbCacheRequest();
```
Return the number of requests made from the cache (total).
```c#
int GetCacheExpirationTime();
```
Return the expiration time in second of the stations cache.
```c#
int SetCacheExpirationTime(int seconds);
```
Use to change the stations cache expiration time.

## Console Client (ClientConsole)
Commands list : 
* "help": write the commands available.
* "exit": exit from the client.
* "city [name]": select a city.
* "station [name]": display the info of the given station name.

## Extension: Client GUI (ClientGUI)
The client GUI that allows the user to select a city from a list of city and displays the existing stations from this city.
By selecting a station you get information of this very station.

## Extension: Monitor GUI
Simple monitor GUI that allows the user to see the number of requests made so far as well as the possibility to change the cache expiration time.
It displays a listing of the current cities in the cache.

## Extension: Caching
Stations array from a given city is kept in cache for a defined number of seconds (10 by default). It's reduce the number of call to the JCDecaux API and improve speed.
