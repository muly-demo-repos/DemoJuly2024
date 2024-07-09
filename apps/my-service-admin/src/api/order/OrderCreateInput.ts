import { InputJsonValue } from "../../types";
import { CustomerWhereUniqueInput } from "../customer/CustomerWhereUniqueInput";

export type OrderCreateInput = {
  orderDate?: Date | null;
  status?: "Option1" | null;
  products?: InputJsonValue;
  customer?: CustomerWhereUniqueInput | null;
};
