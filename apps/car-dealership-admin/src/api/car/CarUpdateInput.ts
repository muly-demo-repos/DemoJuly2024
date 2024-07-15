import { Decimal } from "decimal.js";
import { CustomerWhereUniqueInput } from "../customer/CustomerWhereUniqueInput";

export type CarUpdateInput = {
  licenseNumber?: string | null;
  mileage?: Decimal | null;
  customer?: CustomerWhereUniqueInput | null;
};
