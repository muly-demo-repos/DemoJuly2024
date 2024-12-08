import { SaleCreateNestedManyWithoutCarsInput } from "./SaleCreateNestedManyWithoutCarsInput";

export type CarCreateInput = {
  make?: string | null;
  year?: number | null;
  model: string;
  sales?: SaleCreateNestedManyWithoutCarsInput;
  price?: number | null;
  licenseNumber?: string | null;
};
