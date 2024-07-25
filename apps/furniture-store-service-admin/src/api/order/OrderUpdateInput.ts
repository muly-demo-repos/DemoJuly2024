import { CustomerWhereUniqueInput } from "../customer/CustomerWhereUniqueInput";
import { OrderItemUpdateManyWithoutOrdersInput } from "./OrderItemUpdateManyWithoutOrdersInput";

export type OrderUpdateInput = {
  date?: Date | null;
  status?: "Option1" | null;
  customer?: CustomerWhereUniqueInput | null;
  orderItems?: OrderItemUpdateManyWithoutOrdersInput;
};
