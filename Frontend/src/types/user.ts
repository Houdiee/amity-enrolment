export type UserResponse = {
  type: "user",
  id: number,
  firstName: string,
  lastName: string,
  email: string,
  enrolmentFormId: number,
};

export type CreateUserRequest = {
  type: "user",
  firstName: string,
  lastName: string,
  email: string,
  password: string,
};
