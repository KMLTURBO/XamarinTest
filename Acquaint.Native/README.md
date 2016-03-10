# Acquaint (N)
<img src="https://github.com/xamarinhq/app-acquaint-native/blob/master/Screenshots/Acquaint_N_Screens.png" />

A simple Xamarin app called Acquaint. This is the __native Xamarin__ version of Acquaint, known as Acquaint N.

You may find the __Xamarin.Forms version__ (Acquaint XF) here: https://github.com/xamarinhq/app-acquaint-forms

The app has two main screens:
* a list screen
* a read-only detail screen

_(A third editable detail screen is coming soon to Acquaint N)_

Includes integrations such as:

* getting directions
* making calls
* sending text messages
* email composition

## Native UI Features
| 3D Touch Previewing (iOS) | Shared View Transitions (Android) |
| --- | --- |
| <img src="https://github.com/xamarinhq/app-acquaint-native/blob/master/Screenshots/Acquaint_N_3DTouch.gif" width="300" /> | <img src="https://github.com/xamarinhq/app-acquaint-native/blob/master/Screenshots/Acquaint_N_SharedViewTransitions.gif" width="300" /> |

## Google Maps API key (Android)
For Android, you'll need to obtain a Google Maps API key:
https://developer.xamarin.com/guides/android/platform_features/maps_and_location/maps/obtaining_a_google_maps_api_key/

Insert it in `~/Acquaint.Native.Droid/Properties/AndroidManifest.xml`:

    <application android:theme="@style/AcquaintTheme" android:label="Acquaint N">
      ...
      <meta-data android:name="com.google.android.geo.API_KEY" android:value="GOOGLE_MAPS_API_KEY" />
      ...
    </application>

## Screens
<img src="https://github.com/xamarinhq/app-acquaint-native/blob/master/Screenshots/Acquaint_N_ListPage.png" width="600" />
<img src="https://github.com/xamarinhq/app-acquaint-native/blob/master/Screenshots/Acquaint_N_DetailPage.png" width="600" />
<img src="https://github.com/xamarinhq/app-acquaint-native/blob/master/Screenshots/Acquaint_N_GetDirections.png" width="600" />
