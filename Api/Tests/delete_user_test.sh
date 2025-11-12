#!/bin/sh

if [ -z $1 ]; then
  echo "User ID must be provided"
  exit 1
fi

http DELETE http://localhost:5000/api/users/$1
