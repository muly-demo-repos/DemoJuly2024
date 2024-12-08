import { SaleUpdateManyWithoutCustomersInput } from "./SaleUpdateManyWithoutCustomersInput";

export type CustomerUpdateInput = {
  name?: string | null;
  email?: string | null;
  phone?: string | null;
  address?: string | null;
  sales?: SaleUpdateManyWithoutCustomersInput;
};
