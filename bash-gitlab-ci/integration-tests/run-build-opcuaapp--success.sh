#!/bin/bash

set -euo pipefail

mkdir build-opcuaapp--success
cd    build-opcuaapp--success

oppo new opcuaapp -n "my-app"
rm --force "oppo.log"

if [ "${1}" = "verbose" ];
then
  oppo build --name "my-app"
else
  oppo build -n "my-app"
fi

if [ ! -f "my-app/build/app" ];
then
  echo "deployable application file does not exist ..."
  exit 1
fi

if [[ ! -x "my-app/build/app" ]]
then
  echo "deployable application file is not executable ..."
  exit 1
fi

if [ ! -f "oppo.log" ];
then
  echo "no log entry was created ..."
  exit 1
fi

cd ..
rm -rf build-opcuaapp--success