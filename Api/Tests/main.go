package main

import (
	"net/http"
	"testing"
)

const (
	ContentTypeJson = "application/json"
)

const ApiBaseUrl = "http://localhost:5000/api"

func main() {

}

const UsersEndpoint = ApiBaseUrl + "/users"

func TestUserLifecycle(t *testing.T) {
	t.Parallel();

}

func createUser(t *testing.T) {
	type CreateUserRequest struct {
		Email    string
		Password string
	}

	requestData := CreateUserRequest {
		Email: "arminhuric@gmail.com",
		Password: "ilovemen",
	}

	resp, err := http.Post(UsersEndpoint, ContentTypeJson, )
}
