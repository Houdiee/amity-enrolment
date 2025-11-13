import { AbsoluteCenter } from "@chakra-ui/react";
import SignupForm from "../components/SignupForm";

function SignupPage() {
  return (
    <>
      <AbsoluteCenter w="sm">
        {<SignupForm />}
      </AbsoluteCenter>
    </>
  )
}

export default SignupPage;
