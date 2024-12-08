import { SaleUpdateManyWithoutSalespeopleInput } from "./SaleUpdateManyWithoutSalespeopleInput";

export type SalespersonUpdateInput = {
  lastName?: string | null;
  phone?: string | null;
  firstName?: string | null;
  email?: string | null;
  sales?: SaleUpdateManyWithoutSalespeopleInput;
};
