import { Button, Card, Field, HStack, Input, Stack } from "@chakra-ui/react"
import { PasswordInput, PasswordStrengthMeter } from "../components/ui/password-input"
import { useForm } from "react-hook-form";
import { useMemo } from "react";
import { zxcvbn, type Score } from "@zxcvbn-ts/core";
import { Link as Href } from "react-router-dom";
import { Link } from "@chakra-ui/react";

type SignupForm = {
  firstName: string,
  lastName: string,
  email: string,
  password: string,
  passwordConfirm: string,
}

function SignupForm() {
  const {
    register,
    watch,
    handleSubmit,
    formState: { errors, isValid }
  } = useForm<SignupForm>({ mode: "onChange" });

  const passwordValue = watch("password") ?? "";
  const passwordStrength: Score = useMemo(() => {
    const result = zxcvbn(passwordValue);
    return result.score;
  }, [passwordValue]);

  const onSubmit = handleSubmit(data => {
    console.log(data);
  });

  return (
    <Card.Root shadow="md" w="full">
      <Card.Header>
        <Card.Title fontSize="2xl">Sign Up</Card.Title>
        <Card.Description>Fill in the fields below to get started</Card.Description>
      </Card.Header>
      <form onSubmit={onSubmit}>
        <Card.Body>
          <Stack>
            <Field.Root invalid={!!errors.firstName}>
              <Field.Label>First Name</Field.Label>
              <Input placeholder="John" {...register("firstName", { required: "This field is required" })} />
              <Field.ErrorText>{errors.firstName?.message}</Field.ErrorText>
            </Field.Root>

            <Field.Root invalid={!!errors.lastName}>
              <Field.Label>Last Name</Field.Label>
              <Input placeholder="Doe" {...register("lastName", { required: "This field is required" })} />
              <Field.ErrorText>{errors.lastName?.message}</Field.ErrorText>
            </Field.Root>

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
              {passwordValue.length > 0 && (
                <PasswordStrengthMeter w="full" value={passwordStrength} />
              )}
            </Field.Root>

            <Field.Root invalid={!!errors.passwordConfirm}>
              <Field.Label>Confirm Password</Field.Label>
              <PasswordInput
                {...register("passwordConfirm", {
                  required: "This field is required",
                  validate: (value) => value === passwordValue || "Passwords do not match",
                })}
              />
              <Field.ErrorText>{errors.passwordConfirm?.message}</Field.ErrorText>
            </Field.Root>
          </Stack>
        </Card.Body>
        <Card.Footer>
          <Stack w="full" gap={6}>
            <Link justifyContent="center" fontSize="sm" color="blue.500" as="div">
              <Href to="/login">
                Already have an account? Log in
              </Href>
            </Link>
            <HStack>
              <Button flexGrow={1} size="lg" variant="subtle">
                <Href to="/">Cancel</Href>
              </Button>
              <Button flexGrow={1} size="lg" variant="solid" color="white" bgColor="primary" type="submit" disabled={!isValid}>Sign Up</Button>
            </HStack>
          </Stack>
        </Card.Footer>
      </form>
    </Card.Root>
  )
}

export default SignupForm;
