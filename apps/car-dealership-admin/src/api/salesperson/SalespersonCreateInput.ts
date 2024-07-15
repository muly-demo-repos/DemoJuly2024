import { SaleCreateNestedManyWithoutSalespeopleInput } from "./SaleCreateNestedManyWithoutSalespeopleInput";

export type SalespersonCreateInput = {
  lastName?: string | null;
  phone?: string | null;
  firstName?: string | null;
  email?: string | null;
  sales?: SaleCreateNestedManyWithoutSalespeopleInput;
};
