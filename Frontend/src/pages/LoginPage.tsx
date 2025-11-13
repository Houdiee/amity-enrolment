import { AbsoluteCenter } from "@chakra-ui/react";
import LoginForm from "../components/LoginForm";

function LoginPage() {
  return (
    <>
      <AbsoluteCenter w="sm">
        {<LoginForm />}
      </AbsoluteCenter>
    </>
  )
}

export default LoginPage;
