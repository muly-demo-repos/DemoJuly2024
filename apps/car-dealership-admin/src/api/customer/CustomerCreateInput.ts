import { CarCreateNestedManyWithoutCustomersInput } from "./CarCreateNestedManyWithoutCustomersInput";

export type CustomerCreateInput = {
  name?: string | null;
  lastName?: string | null;
  cars?: CarCreateNestedManyWithoutCustomersInput;
};
