import { AbsoluteCenter, Box } from "@chakra-ui/react";
import LoginForm from "../components/LoginForm";

function LoginPage() {
  return (
    <>
      <AbsoluteCenter w="md">
        <Box w="full" maxW={{ base: "90vw", md: "md" }}>
          <LoginForm />
        </Box>
      </AbsoluteCenter>
    </>
  )
}

export default LoginPage;
