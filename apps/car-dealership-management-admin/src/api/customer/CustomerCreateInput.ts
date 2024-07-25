import { SaleCreateNestedManyWithoutCustomersInput } from "./SaleCreateNestedManyWithoutCustomersInput";

export type CustomerCreateInput = {
  name?: string | null;
  email?: string | null;
  phone?: string | null;
  address?: string | null;
  sales?: SaleCreateNestedManyWithoutCustomersInput;
};
