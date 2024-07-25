import { SaleUpdateManyWithoutSalespeopleInput } from "./SaleUpdateManyWithoutSalespeopleInput";

export type SalespersonUpdateInput = {
  name?: string | null;
  email?: string | null;
  phone?: string | null;
  sales?: SaleUpdateManyWithoutSalespeopleInput;
};
