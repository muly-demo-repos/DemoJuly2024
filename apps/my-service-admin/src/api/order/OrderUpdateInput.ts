import { InputJsonValue } from "../../types";
import { CustomerWhereUniqueInput } from "../customer/CustomerWhereUniqueInput";

export type OrderUpdateInput = {
  orderDate?: Date | null;
  status?: "Option1" | null;
  products?: InputJsonValue;
  customer?: CustomerWhereUniqueInput | null;
};
