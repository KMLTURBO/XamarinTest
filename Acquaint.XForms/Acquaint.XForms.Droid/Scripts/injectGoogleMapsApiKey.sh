#!/bin/bash

# This script injects the Google Maps API key into AndroidManifest.xml.
# This script is used in continuous integration builds.

# $1 is the Google Maps API key value to inject
# $2 is the folder path of the Android project

if [ -z $1 ] || [ -z $2 ] ; then
    exit 1

sed -i '' "s/GOOGLE_MAPS_API_KEY/$2/g" "$1/Properties/AndroidManifest.xml"