import { JsonValue } from "type-fest";
import { Customer } from "../customer/Customer";

export type Order = {
  id: string;
  createdAt: Date;
  updatedAt: Date;
  orderDate: Date | null;
  status?: "Option1" | null;
  products: JsonValue;
  customer?: Customer | null;
};
