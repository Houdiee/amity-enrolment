import { AbsoluteCenter, Box } from "@chakra-ui/react";
import SignupForm from "../components/SignupForm";

function SignupPage() {
  return (
    <>
      <AbsoluteCenter w="md">
        <Box w="full" maxW={{ base: "90vw", md: "md" }}>
          <SignupForm />
        </Box>
      </AbsoluteCenter>
    </>
  )
}

export default SignupPage;
