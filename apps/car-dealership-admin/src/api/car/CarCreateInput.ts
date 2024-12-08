import { Decimal } from "decimal.js";
import { CustomerWhereUniqueInput } from "../customer/CustomerWhereUniqueInput";

export type CarCreateInput = {
  licenseNumber?: string | null;
  mileage?: Decimal | null;
  customer?: CustomerWhereUniqueInput | null;
};
