import { CarUpdateManyWithoutCustomersInput } from "./CarUpdateManyWithoutCustomersInput";

export type CustomerUpdateInput = {
  name?: string | null;
  lastName?: string | null;
  cars?: CarUpdateManyWithoutCustomersInput;
};
