import { AbsoluteCenter } from "@chakra-ui/react";
import LoginForm from "../components/LoginForm";

function LoginPage() {
  return (
    <>
      <AbsoluteCenter w="md">
        {<LoginForm />}
      </AbsoluteCenter>
    </>
  )
}

export default LoginPage;
