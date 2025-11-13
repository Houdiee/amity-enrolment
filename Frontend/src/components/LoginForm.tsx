import { useForm } from "react-hook-form";
import { Button, Card, Field, HStack, Input, Stack } from "@chakra-ui/react"
import { PasswordInput } from "../components/ui/password-input"
import { Link as Href } from "react-router-dom";
import { Link } from "@chakra-ui/react";

type LoginForm = {
  email: string,
  password: string,
};

function LoginForm() {
  const { register, handleSubmit, formState: { errors, isValid } } = useForm<LoginForm>({ mode: "onChange" });

  const onSubmit = handleSubmit(data => {
    console.log(data);
  });

  return (
    <Card.Root shadow="md" w="full">
      <Card.Header>
        <Card.Title fontSize="2xl">Log In</Card.Title>
      </Card.Header>
      <form onSubmit={onSubmit}>
        <Card.Body>
          <Stack>
            <Field.Root invalid={!!errors.email}>
              <Field.Label>Email</Field.Label>
              <Input type="email" placeholder="example@email.com" {...register("email", {
                required: "This field is required",
                pattern: {
                  value: /^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$/,
                  message: "Invalid email address",
                }
              })} />
              <Field.ErrorText>{errors.email?.message}</Field.ErrorText>
            </Field.Root>

            <Field.Root invalid={!!errors.password}>
              <Field.Label>Password</Field.Label>
              <PasswordInput {...register("password", {
                required: "This field is required", minLength: {
                  value: 8,
                  message: "Must be at least 8 characters long"
                }
              })} />
              <Field.ErrorText>{errors.password?.message}</Field.ErrorText>
            </Field.Root>
          </Stack>
        </Card.Body>
        <Card.Footer>
          <Stack w="full" gap={6}>
            <Link justifyContent="center" fontSize="sm" color="blue.500" as="div">
              <Href to="/signup">
                Don't have an account? Sign up
              </Href>
            </Link>
            <HStack>
              <Button flexGrow={1} size="lg" variant="subtle">
                <Href to="/">Cancel</Href>
              </Button>
              <Button flexGrow={1} size="lg" variant="solid" color="white" bgColor="primary" type="submit" disabled={!isValid}>Log In</Button>
            </HStack>
          </Stack>
        </Card.Footer>
      </form>
    </Card.Root>
  );
}

export default LoginForm;
