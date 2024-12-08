import { Decimal } from "decimal.js";
import { Customer } from "../customer/Customer";

export type Car = {
  id: string;
  createdAt: Date;
  updatedAt: Date;
  licenseNumber: string | null;
  mileage: Decimal | null;
  customer?: Customer | null;
};
