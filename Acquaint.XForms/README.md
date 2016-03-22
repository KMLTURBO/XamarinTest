# Acquaint (XF)
<img src="https://github.com/xamarinhq/app-acquaint-forms/blob/master/Screenshots/Acquaint_XF_Screens.png" />

A simple Xamarin app called Acquaint. This is the __Xamarin.Forms version__ of Acquaint, known as Acquaint XF.

The app has three main screens:
* a list screen
* a read-only detail screen
* an editable detail screen

Includes integrations such as:

* getting directions
* making calls
* sending text messages
* email composition

##Build Status
[![Build Status](https://www.bitrise.io/app/914cf8ce4ef481fc.svg?token=DpNs6koe-PuApiaDQAi2mA)](https://www.bitrise.io/app/914cf8ce4ef481fc)

## Google Maps API key (Android)
For Android, you'll need to obtain a Google Maps API key:
https://developer.xamarin.com/guides/android/platform_features/maps_and_location/maps/obtaining_a_google_maps_api_key/

Insert it in `~/Acquaint.XForms.Droid/Properties/AndroidManifest.xml`:

    <application android:theme="@style/AcquaintTheme" android:label="Acquaint XF">
      ...
      <meta-data android:name="com.google.android.geo.API_KEY" android:value="GOOGLE_MAPS_API_KEY" />
      ...
    </application>

## Screens
<img src="https://github.com/xamarinhq/app-acquaint-forms/blob/master/Screenshots/Acquaint_XF_ListPage.png?raw=true" width="600" />
<img src="https://github.com/xamarinhq/app-acquaint-forms/blob/master/Screenshots/Acquaint_XF_DetailPage.png?raw=true" width="600" />
<img src="https://github.com/xamarinhq/app-acquaint-forms/blob/master/Screenshots/Acquaint_XF_EditPage.png?raw=true" width="600" />
<img src="https://github.com/xamarinhq/app-acquaint-forms/blob/master/Screenshots/Acquaint_XF_GetDirections.png?raw=true" width="600" />

