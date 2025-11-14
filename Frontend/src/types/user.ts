export type LoginRequest =  {
  email: string,
  password: string,
};

export type UserResponse = {
  id: number,
  firstName: string,
  lastName: string,
  email: string,
  enrolmentFormId: number,
};

export type CreateUserRequest = {
  firstName: string,
  lastName: string,
  email: string,
  password: string,
};
