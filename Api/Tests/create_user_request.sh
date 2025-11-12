#!/bin/sh

echo '{
  "email": "arminhuric14@gmail.com",
  "password": "ilovemen123"
}' | http POST http://localhost:5000/api/users
