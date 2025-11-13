import axios from "axios";

const apiClient = axios.create({
  baseURL: "",
  headers: {
    "Content-Type": "application/json",
  },
  timeout: 10_000,
});
