import { AbsoluteCenter } from "@chakra-ui/react";
import SignupForm from "../components/SignupForm";

function SignupPage() {
  return (
    <>
      <AbsoluteCenter w="md">
        {<SignupForm />}
      </AbsoluteCenter>
    </>
  )
}

export default SignupPage;
