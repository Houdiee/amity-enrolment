#!/bin/sh

if [ -z $1 ]; then
  echo "User ID must be provided"
  exit 1
fi

echo '[
  {
    "op": "replace",
    "path": "/StudentDetails/FamilyName",
    "value": "Kerim"
  }
]' | http PATCH http://localhost:5000/api/users/$1/forms/enrolment
