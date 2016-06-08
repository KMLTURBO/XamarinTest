# Acquaint

A simple Xamarin app named *Acquaint*. The app is a simple list of contacts, each of which can be viewed in a detail screen and modified in an edit screen. It runs on iOS 9+, Android 4.2+, and UWP (mobile and desktop).

<img src="https://github.com/xamarinhq/app-acquaint/blob/master/Screenshots/AllScreens_AllPlatforms.jpg" />

##Build Status
| Project               | master branch                                                                                              |
|-----------------------|------------------------------------------------------------------------------------------------------------|
| Acquaint.XForms.Droid | <img src="https://josau.visualstudio.com/_apis/public/build/definitions/ff9dfce3-f143-428a-9694-2fa649920fc5/7/badge" /> |
| Acquaint.XForms.iOS   | <img src="https://josau.visualstudio.com/_apis/public/build/definitions/ff9dfce3-f143-428a-9694-2fa649920fc5/6/badge" /> |
| Acquaint.XForms.UWP   | <img src="https://josau.visualstudio.com/_apis/public/build/definitions/ff9dfce3-f143-428a-9694-2fa649920fc5/5/badge" /> |
| Acquaint.Native.Droid | <img src="https://josau.visualstudio.com/_apis/public/build/definitions/ff9dfce3-f143-428a-9694-2fa649920fc5/9/badge" /> |
| Acquaint.Native.iOS   | <img src="https://josau.visualstudio.com/_apis/public/build/definitions/ff9dfce3-f143-428a-9694-2fa649920fc5/8/badge" /> |

##Cross-platform and native
The app is implemented in two ways in order to demonstrate the two different approaches to Xamarin app development:
* Xamarin.Forms cross-platform UI
* Xamarin native, with platform-specific UI implementations

##Three platforms
The app targets three platforms:
* iOS
* Android
* Universal Windows Platform (UWP)
    * UWP currently only in Forms version of app
    * UWP supported only in Visual Studio, not Xamarin Studio

##Code sharing
#####~90% code shared across platforms in Acquaint.XForms
![](https://github.com/xamarinhq/app-acquaint/blob/master/Screenshots/Acquaint.XForms_CodeSharing.png)

#####~40% code shared across platforms in Acquaint.Native
![](https://github.com/xamarinhq/app-acquaint/blob/master/Screenshots/Acquaint.Native_CodeSharing.png)

##Integrations
Includes integrations such as:
* getting directions
* making calls
* sending text messages
* email composition

## Requirements
* [Visual Studio __2015__](https://www.visualstudio.com/en-us/products/vs-2015-product-editions.aspx) (14.0 or higher) to compile C# 6 langage features (or Xamarin Studio OS X)
* Xamarin add-ons for Visual Studio (available via the Visual Studio installer)
* __Visual Studio Community Edition is fully supported!__

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
| <img src="https://github.com/xamarinhq/app-acquaint/blob/master/Screenshots/Acquaint_N_3DTouch.gif" width="300" /> | <img src="https://github.com/xamarinhq/app-acquaint/blob/master/Screenshots/Acquaint_N_SharedViewTransitions.gif" width="300" /> |


## Screens

The app has three main screens:
* a list screen
* a read-only detail screen
* an editable detail screen (currently in Forms version only)

##People

All images of people in the app come from [UIFaces.com](http://uifaces.com/authorized). In accordance with the guidelines, fictitious names have been provided. 
