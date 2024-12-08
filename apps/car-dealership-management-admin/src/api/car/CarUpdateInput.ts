import { SaleUpdateManyWithoutCarsInput } from "./SaleUpdateManyWithoutCarsInput";

export type CarUpdateInput = {
  make?: string | null;
  year?: number | null;
  model?: string;
  sales?: SaleUpdateManyWithoutCarsInput;
  price?: number | null;
  licenseNumber?: string | null;
};
