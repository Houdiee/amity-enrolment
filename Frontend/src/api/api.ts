import axios, { isAxiosError } from "axios";

export const apiClient = axios.create({
  baseURL: import.meta.env.VITE_API_BASE_URL,
  headers: {
    "Content-Type": "application/json",
  },
  timeout: 10_000,
});

export class ApiError {
  status: number | null;
  message: string;

  constructor(status: number | null, message: string) {
    this.status = status;
    this.message = message;
  }
};

export const newApiError = (error: any): ApiError => {
  if (isAxiosError(error) && error.response) {
    return new ApiError(error.response.status, error.response.data.message);
  };
  return new ApiError(null, "An unexpected client-side error occurred");
}
