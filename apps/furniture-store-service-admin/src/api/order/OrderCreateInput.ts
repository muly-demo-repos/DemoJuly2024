import { CustomerWhereUniqueInput } from "../customer/CustomerWhereUniqueInput";
import { OrderItemCreateNestedManyWithoutOrdersInput } from "./OrderItemCreateNestedManyWithoutOrdersInput";

export type OrderCreateInput = {
  date?: Date | null;
  status?: "Option1" | null;
  customer?: CustomerWhereUniqueInput | null;
  orderItems?: OrderItemCreateNestedManyWithoutOrdersInput;
};
