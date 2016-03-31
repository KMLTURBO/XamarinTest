# Acquaint
<img src="https://github.com/xamarinhq/app-acquaint/blob/master/Screenshots/Acquaint_XF_Screens.png" />

A simple Xamarin app named *Acquaint*. The app is a simple list of contacts, each of which can be viewed in a detail screen and modified in an edit screen.

##Cross-platform and native
The app is implemented in two ways: 
* Xamarin.Forms cross-platform UI
* Xamarin native, with platform-specific UI implementations

The app is implemented in to two ways in order to demonstrate the two different approaches to Xamarin app development.

##Three platforms
The app targets three platforms:
* iOS
* Android
* Universal Windows Platform (Forms version only, coming soon)

##Integrations
Includes integrations such as:
* getting directions
* making calls
* sending text messages
* email composition

## Google Maps API key (Android)
For Android, you'll need to obtain a Google Maps API key:
https://developer.xamarin.com/guides/android/platform_features/maps_and_location/maps/obtaining_a_google_maps_api_key/

Insert it in the Android project: `~/Properties/AndroidManifest.xml`:

    <application ...>
      ...
      <meta-data android:name="com.google.android.geo.API_KEY" android:value="GOOGLE_MAPS_API_KEY" />
      ...
    </application>


## Platform-specific UI Features (in native version only)
| 3D Touch Previewing (iOS) | Shared View Transitions (Android) |
| --- | --- |
| <img src="https://github.com/xamarinhq/app-acquaint/blob/master/Screenshots/Acquaint_N_3DTouch.gif" width="300" /> <br /> *** Physical device required for 3D Touch *** | <img src="https://github.com/xamarinhq/app-acquaint/blob/master/Screenshots/Acquaint_N_SharedViewTransitions.gif" width="300" /> |


## Screens

The app has three main screens:
* a list screen
* a read-only detail screen
* an editable detail screen (currently in Forms version only)

Also pictured is the external maps application providing navigation that has been initiated from within the app.

<img src="https://github.com/xamarinhq/app-acquaint/blob/master/Screenshots/Acquaint_XF_ListPage.png?raw=true" width="600" />
<img src="https://github.com/xamarinhq/app-acquaint/blob/master/Screenshots/Acquaint_XF_DetailPage.png?raw=true" width="600" />
<img src="https://github.com/xamarinhq/app-acquaint/blob/master/Screenshots/Acquaint_XF_EditPage.png?raw=true" width="600" />
<img src="https://github.com/xamarinhq/app-acquaint/blob/master/Screenshots/Acquaint_XF_GetDirections.png?raw=true" width="600" />

##People

All images of people in the app come from [UIFaces.com](http://uifaces.com/authorized). In accordance with the guidelines, fictitious names have been provided.
