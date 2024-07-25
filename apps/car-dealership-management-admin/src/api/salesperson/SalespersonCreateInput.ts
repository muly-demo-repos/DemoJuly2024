import { SaleCreateNestedManyWithoutSalespeopleInput } from "./SaleCreateNestedManyWithoutSalespeopleInput";

export type SalespersonCreateInput = {
  name?: string | null;
  email?: string | null;
  phone?: string | null;
  sales?: SaleCreateNestedManyWithoutSalespeopleInput;
};
