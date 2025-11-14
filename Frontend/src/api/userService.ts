import type { CreateUserRequest, UserResponse } from "../types/user";
import { apiClient, newApiError } from "./api";

const endpoint = "/users";

export const getUserById = async (userId: number) => {
  try {
    const response = await apiClient.get(`${endpoint}/${userId}`);
    const userResponse: UserResponse = response.data.user;
    return userResponse;
  }
  catch (error) {
    throw newApiError(error);
  }
}

export const createUser = async (payload: CreateUserRequest) => {
  try {
    const response = await apiClient.post(endpoint, payload);
    const userResponse: UserResponse = response.data.user;
    return userResponse;
  }
  catch (error) {
    throw newApiError(error);
  }
}

export const deleteUserById = async (userId: number) => {
  try {
    await apiClient.delete(`${endpoint}/${userId}`);
  }
  catch (error) {
    throw newApiError(error);
  }
}
