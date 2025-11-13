import { Routes, Route } from "react-router-dom";
import SignupPage from "./pages/SignupPage";
import LoginPage from "./pages/LoginPage";

export const ROUTES = {
  HOME: "/",
  SIGNUP: "/signup",
  LOGIN: "/login",
};

function App() {
  return (
    <Routes>
      <Route path={ROUTES.SIGNUP} element={<SignupPage />} />
      <Route path={ROUTES.LOGIN} element={<LoginPage />} />
    </Routes>
  )
}

export default App;
